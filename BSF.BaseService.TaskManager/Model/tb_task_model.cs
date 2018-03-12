using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace BSF.BaseService.TaskManager.Model
{
    /// <summary>
    /// tb_task Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_task_model
    {
        /*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string taskname { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        public int categoryid { get; set; }

        /// <summary>
        /// �ڵ�id
        /// </summary>
        public int nodeid { get; set; }

        /// <summary>
        /// ���񴴽�ʱ��
        /// </summary>
        public DateTime taskcreatetime { get; set; }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime taskupdatetime { get; set; }

        /// <summary>
        /// ������һ��ִ��ʱ��
        /// </summary>
        public DateTime tasklaststarttime { get; set; }

        /// <summary>
        /// ������һ�ν���ʱ��
        /// </summary>
        public DateTime tasklastendtime { get; set; }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime tasklasterrortime { get; set; }

        /// <summary>
        /// ���������������
        /// </summary>
        public int taskerrorcount { get; set; }

        /// <summary>
        /// �����ܳɹ����д���
        /// </summary>
        public int taskruncount { get; set; }

        /// <summary>
        /// ���񴴽���id
        /// </summary>
        public int taskcreateuserid { get; set; }

        /// <summary>
        /// ����ִ��״̬���鿴����ö��
        /// </summary>
        public Byte taskstate { get; set; }

        /// <summary>
        /// ����汾��
        /// </summary>
        public int taskversion { get; set; }

        /// <summary>
        /// ����app�����ֵ�
        /// </summary>
        public string taskappconfigjson { get; set; }

        /// <summary>
        /// ����ִ��Ƶ��cron���ʽ
        /// </summary>
        public string taskcron { get; set; }

        /// <summary>
        /// ������ں���dll�ļ���
        /// </summary>
        public string taskmainclassdllfilename { get; set; }

        /// <summary>
        /// �������ִ�к�����·��
        /// </summary>
        public string taskmainclassnamespace { get; set; }

        /// <summary>
        /// ����ע
        /// </summary>
        public string taskremark { get; set; }

    }
}