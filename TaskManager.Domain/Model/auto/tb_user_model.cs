using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskManager.Domain.Model
{
    /// <summary>
    /// tb_user Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_user_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// Ա������
        /// </summary>
        public string userstaffno { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        
        /// <summary>
        /// Ա����ɫ���鿴����ö�٣�������Ա������Ա
        /// </summary>
        public Byte userrole { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime usercreatetime { get; set; }
        
        /// <summary>
        /// Ա���ֻ�����
        /// </summary>
        public string usertel { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string useremail { get; set; }
        
    }
}