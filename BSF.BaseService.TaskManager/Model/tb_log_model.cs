using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace BSF.BaseService.TaskManager.Model
{
    /// <summary>
    /// tb_log Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_log_model
    {
        /*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte logtype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime logcreatetime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int taskid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int nodeid { get; set; }

    }
}