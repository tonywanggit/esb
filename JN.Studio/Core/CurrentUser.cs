using System;
using System.Collections.Generic;
using System.Text;
using JN.Studio.Entity;

namespace JN.Studio.Core
{
    /// <summary>
    /// 当前用户
    /// </summary>
    public class CurrentUser
    {
        static UserInfo userInfo = null;
        public static UserInfo UserInfo { 
            get{
                if(userInfo == null) return UserInfo.FindByLoginName("admin");
                else return userInfo;
            }
            set
            {
                userInfo = value;
            }
        }
    }
}
