﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Node.SystemRuntime;

namespace TaskManager.Node.Commands
{
    /// <summary>
    /// 关闭任务命令
    /// </summary>
    public class StopTaskCommand:BaseCommand
    {
        public override void Execute()
        {
            TaskProvider tp = new TaskProvider();
            tp.Stop(this.CommandInfo.taskid);
        }
    }
}
