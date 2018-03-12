using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BSF.Extensions;
using BSF.Db;
using TaskManager.Domain.Model;

namespace TaskManager.Domain.Dal
{
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
	public partial class tb_command_dal
    {
        public virtual bool Add(DbConn PubConn, tb_command_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//����json
					new ProcedureParameter("@command",    model.command),
					//���������ο�����ö��
					new ProcedureParameter("@commandname",    model.commandname),
					//����ִ��״̬���ο�����ö��
					new ProcedureParameter("@commandstate",    model.commandstate),
					//����id
					new ProcedureParameter("@taskid",    model.taskid),
					//�ڵ�id
					new ProcedureParameter("@nodeid",    model.nodeid),
					//�����ʱ��
					new ProcedureParameter("@commandcreatetime",    model.commandcreatetime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_command(command,commandname,commandstate,taskid,nodeid,commandcreatetime)
										   values(@command,@commandname,@commandstate,@taskid,@nodeid,@commandcreatetime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_command_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//����json
					new ProcedureParameter("@command",    model.command),
					//���������ο�����ö��
					new ProcedureParameter("@commandname",    model.commandname),
					//����ִ��״̬���ο�����ö��
					new ProcedureParameter("@commandstate",    model.commandstate),
					//����id
					new ProcedureParameter("@taskid",    model.taskid),
					//�ڵ�id
					new ProcedureParameter("@nodeid",    model.nodeid),
					//�����ʱ��
					new ProcedureParameter("@commandcreatetime",    model.commandcreatetime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_command set command=@command,commandname=@commandname,commandstate=@commandstate,taskid=@taskid,nodeid=@nodeid,commandcreatetime=@commandcreatetime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_command where id=@id";
            int rev = PubConn.ExecuteSql(Sql, Par);
            if (rev == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public virtual tb_command_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_command s where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_command_model CreateModel(DataRow dr)
        {
            var o = new tb_command_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//����json
			if(dr.Table.Columns.Contains("command"))
			{
				o.command = dr["command"].Tostring();
			}
			//���������ο�����ö��
			if(dr.Table.Columns.Contains("commandname"))
			{
				o.commandname = dr["commandname"].Tostring();
			}
			//����ִ��״̬���ο�����ö��
			if(dr.Table.Columns.Contains("commandstate"))
			{
				o.commandstate = dr["commandstate"].ToByte();
			}
			//����id
			if(dr.Table.Columns.Contains("taskid"))
			{
				o.taskid = dr["taskid"].Toint();
			}
			//�ڵ�id
			if(dr.Table.Columns.Contains("nodeid"))
			{
				o.nodeid = dr["nodeid"].Toint();
			}
			//�����ʱ��
			if(dr.Table.Columns.Contains("commandcreatetime"))
			{
				o.commandcreatetime = dr["commandcreatetime"].ToDateTime();
			}
			return o;
        }
    }
}