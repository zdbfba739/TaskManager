﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;
using TaskManager.Domain.Dal;
using TaskManager.Domain.Model;
using TaskManager.Node.Commands;
using TaskManager.Node.Tools;
using BSF.Log;
using BSF.Db;
using TaskManager.Core;
using TaskManager.Core.Redis;
using BSF.Extensions;

namespace TaskManager.Node
{
    /// <summary>
    /// 命令消息循环处理器
    /// </summary>
    public class CommandQueueProcessor
    {
        private static object _lockRunLoop = new object();

        private static System.Threading.Thread thread;
        /// <summary>
        /// 上一次日志扫描的最大id
        /// </summary>
        public static int lastMaxID = -1;
        static CommandQueueProcessor()
        {
            thread = new System.Threading.Thread(Running);
            thread.IsBackground = true;
            thread.Start();
        }
        /// <summary>
        /// 运行处理循环
        /// </summary>
        public static void Run()
        { }

        static void Running()
        {
            //lastMaxID = 0;//仅测试
            RecoveryStartTasks();

            RedisHelper.RedisListner((channel, msg) =>
            {
                try
                {
                    RedisCommondInfo redisCommondInfo = null;
                    try { redisCommondInfo = new BSF.Serialization.JsonProvider().Deserialize<RedisCommondInfo>(msg); } catch { }
                    if (redisCommondInfo != null)
                    {
                        if (redisCommondInfo.CommondType == EnumCommondType.TaskCommand && redisCommondInfo.NodeId == GlobalConfig.NodeID)
                        {
                            RunCommond();
                        }
                        if (redisCommondInfo.CommondType == EnumCommondType.ConfigUpdate)
                        {
                            RedisHelper.RefreashRedisServerIP();
                        }
                    }
                    else
                    {
                        throw new Exception("redis命令无法识别");
                    }
                }
                catch (Exception exp)
                {
                    LogHelper.AddNodeError("Redis命令处理出错,msg:" + msg.NullToEmpty(), exp);
                }
            }, (info) =>
            {
                if (info != null)
                { LogHelper.AddNodeError("Redis订阅出错," + info.Message.NullToEmpty(), info.Exception); }
            });

            RuningCommandLoop();


        }
        /// <summary>
        /// 恢复已开启的任务
        /// </summary>
        static void RecoveryStartTasks()
        {
            try
            {
                LogHelper.AddNodeLog("当前节点启动成功,准备恢复已经开启的任务...");
                List<int> taskids = new List<int>();
                SqlHelper.ExcuteSql(GlobalConfig.TaskDataBaseConnectString, (c) =>
                {
                    tb_task_dal taskdal = new tb_task_dal();
                    taskids = taskdal.GetTaskIDsByState(c, (int)EnumTaskState.Running, GlobalConfig.NodeID);
                });
                foreach (var taskid in taskids)
                {
                    try
                    {
                        CommandFactory.Execute(new tb_command_model()
                        {
                            command = "",
                            commandcreatetime = DateTime.Now,
                            commandname = EnumTaskCommandName.StartTask.ToString(),
                            commandstate = (int)EnumTaskCommandState.None,
                            nodeid = GlobalConfig.NodeID,
                            taskid = taskid,
                            id = -1
                        });
                    }
                    catch (Exception exp)
                    {
                        LogHelper.AddTaskError(string.Format("恢复已经开启的任务{0}失败", taskid), taskid, exp);
                    }
                }
                LogHelper.AddNodeLog(string.Format("恢复已经开启的任务完毕，共{0}条任务重启", taskids.Count));
            }
            catch (Exception exp)
            {
                LogHelper.AddNodeError("恢复已经开启的任务失败", exp);
            }
        }

        /// <summary>
        /// 运行消息循环
        /// </summary>
        static void RuningCommandLoop()
        {
            LogHelper.AddNodeLog("准备接受命令并运行消息循环...");
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                RunCommond();
                System.Threading.Thread.Sleep(5000);
            }
        }

        static void RunCommond()
        {
            lock (_lockRunLoop)
            {
                try
                {
                    List<tb_command_model> commands = new List<tb_command_model>();
                    try
                    {
                        SqlHelper.ExcuteSql(GlobalConfig.TaskDataBaseConnectString, (c) =>
                        {
                            tb_command_dal commanddal = new tb_command_dal();
                            if (lastMaxID < 0)
                                lastMaxID = commanddal.GetMaxCommandID(c);
                            commands = commanddal.GetNodeCommands(c, GlobalConfig.NodeID, lastMaxID);
                        });
                    }
                    catch (Exception exp2)
                    {
                        LogHelper.AddNodeError("获取当前节点命令集错误", exp2);
                    }
                    if (commands.Count > 0)
                        LogHelper.AddNodeLog("当前节点扫描到" + commands.Count + "条命令,并执行中....");
                    foreach (var c in commands)
                    {
                        try
                        {
                            CommandFactory.Execute(c);
                            SqlHelper.ExcuteSql(GlobalConfig.TaskDataBaseConnectString, (conn) =>
                            {
                                new tb_command_dal().UpdateCommandState(conn, c.id, (int)EnumTaskCommandState.Success);
                            });
                            LogHelper.AddNodeLog(string.Format("当前节点执行命令成功! id:{0},命令名:{1},命令内容:{2}", c.id, c.commandname, c.command));
                        }
                        catch (Exception exp1)
                        {
                            try
                            {
                                SqlHelper.ExcuteSql(GlobalConfig.TaskDataBaseConnectString, (conn) =>
                                {
                                    new tb_command_dal().UpdateCommandState(conn, c.id, (int)EnumTaskCommandState.Error);
                                });
                            }
                            catch { }
                            LogHelper.AddTaskError("执行节点命令失败", c.taskid, exp1);
                        }
                        lastMaxID = Math.Max(lastMaxID, c.id);
                    }
                }
                catch (Exception exp)
                {
                    LogHelper.AddNodeError("系统级不可恢复严重错误", exp);
                }
            }
        }
    }
}
