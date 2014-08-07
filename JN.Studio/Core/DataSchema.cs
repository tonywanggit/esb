using System;
using System.Collections.Generic;
using System.Text;
using JN.Studio.Entity;
using NewLife.Log;
using XCode.DataAccessLayer;
using NewLife.Threading;
using System.Threading;

namespace JN.Studio.Core
{
    /// <summary>
    /// 数据库架构初始化状态枚举
    /// </summary>
    internal enum DataSchemaInitStatus
    {
        /// <summary>
        /// 正在初始化
        /// </summary>
        Initializing,
        /// <summary>
        /// 初始化完成
        /// </summary>
        Initialized,
        /// <summary>
        /// 初始化发生异常
        /// </summary>
        Error
    }

    /// <summary>
    /// 状态改变时传递的事件参数
    /// </summary>
    internal class StatusChangeEventArgs : EventArgs
    {
        private readonly DataSchemaInitStatus m_curStatus;

        public StatusChangeEventArgs(DataSchemaInitStatus curStatus)
        {
            m_curStatus = curStatus;
        }

        /// <summary>
        /// 架构的当前状态
        /// </summary>
        public DataSchemaInitStatus CurrentStatus { get { return m_curStatus; } }

    }

    /// <summary>
    /// 数据库架构获取类
    /// </summary>
    internal class DataSchema
    {
        #region 成员及构造
        private UserConn m_conn;
        private DAL m_dal;
        private Int32 m_tableCount;
        private Int32 m_viewCount;
        private DataSchemaInitStatus m_initStatus;
        private String m_initError;

        private DataSchema(UserConn conn)
        {
            m_conn = conn;
            m_initStatus = DataSchemaInitStatus.Initializing;
            m_initError = String.Empty;

            ThreadPoolX.QueueUserWorkItem(x => InitDataSchema());
        }
        #endregion

        #region 状态改变事件
        /// <summary>
        /// 公开状态改变事件
        /// </summary>
        private event EventHandler<StatusChangeEventArgs> StatusChange;

        /// <summary>
        /// 触发状态改变事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStatusChange(StatusChangeEventArgs e)
        {
            //--处于线程安全考虑，将委托字段的引用复制到一个临时字段中
            EventHandler<StatusChangeEventArgs> temp = 
                Interlocked.CompareExchange<EventHandler<StatusChangeEventArgs>>(ref StatusChange, null, null);
            
            //--任何方法登记了对事件的关注，就通知它们
            if (temp != null)
                temp(this, e);
        }

        /// <summary>
        /// 增加状态改变事件处理程序，保证只增加一次
        /// </summary>
        /// <param name="handler"></param>
        public void AddStatusChangeHandler(EventHandler<StatusChangeEventArgs> handler)
        {
            if (!m_hasStatusChangeHandler)
            {
                m_hasStatusChangeHandler = true;
                StatusChange += handler;
            }
        }
        #endregion

        #region 初始化数据架构
        /// <summary>
        /// 初始化数据库结构
        /// </summary>
        private void InitDataSchema()
        {
            try
            {
                XTrace.WriteLine(String.Format("开始对数据库[{0}]的架构加载...", m_conn.Database.DatabaseName));

                DAL.AddConnStr(m_conn.Database.ConnName, m_conn.ConnString, null, m_conn.Database.Provider);
                DAL dal = DAL.Create(m_conn.Database.ConnName);

                dal.Session.QuickTest();

                m_dal = dal;
                m_tableCount = dal.Tables.FindAll(x => !x.IsView).Count;
                m_viewCount = dal.Tables.FindAll(x => x.IsView).Count;

                m_initStatus = DataSchemaInitStatus.Initialized;

                XTrace.WriteLine(String.Format("完成对数据库[{0}]的架构加载...", m_conn.Database.DatabaseName));
            }
            catch (Exception ex)
            {
                m_initStatus = DataSchemaInitStatus.Error;
                m_initError = ex.Message;
            }
            finally
            {
                OnStatusChange(new StatusChangeEventArgs(m_initStatus));
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 初始化状态
        /// </summary>
        public DataSchemaInitStatus InitStatus { get { return m_initStatus; } }

        /// <summary>
        /// 获取到数据库中的表数量
        /// </summary>
        public Int32 TableCount {
            get {
                return m_tableCount;
            }
        }

        /// <summary>
        /// 获取到数据库中的视图数量
        /// </summary>
        public Int32 ViewCount {
            get
            {
                return m_viewCount;
            }
        }

        /// <summary>
        /// 获取到数据访问层
        /// </summary>
        public DAL DAL { get { return m_dal; } }

        /// <summary>
        /// 是否存在事件的订阅者
        /// </summary>
        private Boolean m_hasStatusChangeHandler = false;

        #endregion

        #region 静态成员
        private static Dictionary<UserConn, DataSchema> s_dataSchemaDict = new Dictionary<UserConn, DataSchema>();

        /// <summary>
        /// 根据用户连接获取到数据库架构
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataSchema GetInstance(UserConn conn)
        {
            if (!s_dataSchemaDict.ContainsKey(conn))
            {
                s_dataSchemaDict.Add(conn, new DataSchema(conn));
            }
            return s_dataSchemaDict[conn];
        }

        /// <summary>
        /// 初始化数据库架构
        /// </summary>
        /// <param name="conn"></param>
        public static void InitDataSchema(UserConn conn)
        {
            GetInstance(conn);
        }

        /// <summary>
        /// 判断架构中是否包含指定的连接
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static Boolean Contains(UserConn conn)
        {
            return s_dataSchemaDict.ContainsKey(conn);
        }

        /// <summary>
        /// 清空所有缓存的数据库架构
        /// </summary>
        public static void Clear()
        {
            s_dataSchemaDict.Clear();
        }
        #endregion
    }
}
