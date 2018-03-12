﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSF.BaseService.TaskManager.Model;
using BSF.Db;

namespace BSF.BaseService.TaskManager.Dal
{
    public class tb_log_dal
    {
        public int Add(DbConn PubConn, tb_log_model model)
        {
            return SqlHelper.Visit(ps =>
            {
					ps.Add("@msg",    model.msg);
					ps.Add("@logtype",    model.logtype);
					ps.Add("@logcreatetime",    model.logcreatetime);
                    ps.Add("@taskid", model.taskid);
                    ps.Add("@nodeid", model.nodeid);
                return PubConn.ExecuteSql(@"insert into tb_log(msg,logtype,logcreatetime,taskid,nodeid)
										   values(@msg,@logtype,@logcreatetime,@taskid,@nodeid)", ps.ToParameters());
            });
        }
    }
}
