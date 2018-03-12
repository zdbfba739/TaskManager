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
	public partial class tb_user_dal
    {
        public virtual bool Add(DbConn PubConn, tb_user_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//Ա������
					new ProcedureParameter("@userstaffno",    model.userstaffno),
					//
					new ProcedureParameter("@username",    model.username),
					//Ա����ɫ���鿴����ö�٣�������Ա������Ա
					new ProcedureParameter("@userrole",    model.userrole),
					//
					new ProcedureParameter("@usercreatetime",    model.usercreatetime),
					//Ա���ֻ�����
					new ProcedureParameter("@usertel",    model.usertel),
					//
					new ProcedureParameter("@useremail",    model.useremail)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_user(userstaffno,username,userrole,usercreatetime,usertel,useremail)
										   values(@userstaffno,@username,@userrole,@usercreatetime,@usertel,@useremail)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_user_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//Ա������
					new ProcedureParameter("@userstaffno",    model.userstaffno),
					//
					new ProcedureParameter("@username",    model.username),
					//Ա����ɫ���鿴����ö�٣�������Ա������Ա
					new ProcedureParameter("@userrole",    model.userrole),
					//
					new ProcedureParameter("@usercreatetime",    model.usercreatetime),
					//Ա���ֻ�����
					new ProcedureParameter("@usertel",    model.usertel),
					//
					new ProcedureParameter("@useremail",    model.useremail)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_user set userstaffno=@userstaffno,username=@username,userrole=@userrole,usercreatetime=@usercreatetime,usertel=@usertel,useremail=@useremail where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_user where id=@id";
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

        public virtual tb_user_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_user s where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_user_model CreateModel(DataRow dr)
        {
            var o = new tb_user_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//Ա������
			if(dr.Table.Columns.Contains("userstaffno"))
			{
				o.userstaffno = dr["userstaffno"].Tostring();
			}
			//
			if(dr.Table.Columns.Contains("username"))
			{
				o.username = dr["username"].Tostring();
			}
			//Ա����ɫ���鿴����ö�٣�������Ա������Ա
			if(dr.Table.Columns.Contains("userrole"))
			{
				o.userrole = dr["userrole"].ToByte();
			}
			//
			if(dr.Table.Columns.Contains("usercreatetime"))
			{
				o.usercreatetime = dr["usercreatetime"].ToDateTime();
			}
			//Ա���ֻ�����
			if(dr.Table.Columns.Contains("usertel"))
			{
				o.usertel = dr["usertel"].Tostring();
			}
			//
			if(dr.Table.Columns.Contains("useremail"))
			{
				o.useremail = dr["useremail"].Tostring();
			}
			return o;
        }
    }
}