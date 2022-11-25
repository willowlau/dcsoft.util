﻿using System;

namespace DCSoft.Web.Core.Attributes
{
    /// <summary>
    /// 启用登录
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LoginAttribute : Attribute
    {
    }
}