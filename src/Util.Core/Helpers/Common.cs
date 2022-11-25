﻿using System;
using System.Runtime.InteropServices;

namespace Util.Helpers {
    /// <summary>
    /// 公共操作
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 是否Linux操作系统
        /// </summary>
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// 是否Windows操作系统
        /// </summary>
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// 是否苹果操作系统
        /// </summary>
        public static bool IsOsx => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// 当前操作系统
        /// </summary>
        public static string OS => IsWindows ? "Windows" : IsLinux ? "Linux" : IsOsx ? "OSX" : string.Empty;
        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => System.Environment.NewLine;

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>() {
            return GetType( typeof( T ) );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType( Type type ) {
            return Nullable.GetUnderlyingType( type ) ?? type;
        }
    }
}