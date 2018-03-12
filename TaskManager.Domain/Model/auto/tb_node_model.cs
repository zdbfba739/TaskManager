using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskManager.Domain.Model
{
    /// <summary>
    /// tb_node Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_node_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string nodename { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime nodecreatetime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string nodeip { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime nodelastupdatetime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ifcheckstate { get; set; }
        
    }
}