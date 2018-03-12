using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TaskManager.Domain.Model
{
    /// <summary>
    /// tb_category Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_category_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// ������
        /// </summary>
        public string categoryname { get; set; }
        
        /// <summary>
        /// ���ഴ��ʱ��
        /// </summary>
        public DateTime categorycreatetime { get; set; }
        
    }
}