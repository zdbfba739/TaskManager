using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskManager.Domain.Model
{
    /// <summary>
    /// tb_command Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_command_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// ����json
        /// </summary>
        public string command { get; set; }
        
        /// <summary>
        /// ���������ο�����ö��
        /// </summary>
        public string commandname { get; set; }
        
        /// <summary>
        /// ����ִ��״̬���ο�����ö��
        /// </summary>
        public Byte commandstate { get; set; }
        
        /// <summary>
        /// ����id
        /// </summary>
        public int taskid { get; set; }
        
        /// <summary>
        /// �ڵ�id
        /// </summary>
        public int nodeid { get; set; }
        
        /// <summary>
        /// �����ʱ��
        /// </summary>
        public DateTime commandcreatetime { get; set; }
        
    }
}