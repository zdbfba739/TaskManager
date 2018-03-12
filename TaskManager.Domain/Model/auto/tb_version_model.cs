using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskManager.Domain.Model
{
    /// <summary>
    /// tb_version Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_version_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int taskid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int version { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime versioncreatetime { get; set; }
        
        /// <summary>
        /// ѹ���ļ��������ļ�
        /// </summary>
        public byte[] zipfile { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string zipfilename { get; set; }
        
    }
}