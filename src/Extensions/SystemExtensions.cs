﻿using SeewoHelper.Utilities;
using System;

namespace SeewoHelper
{
    /// <summary>
    /// 提供 <see cref="System"/> 命名空间下相关的扩展方法
    /// </summary>
    public static class SystemExtensions
    {
        /// <summary>
        /// 使用 <see cref="MessageBoxUtilities.Show(string, string, bool, Sunny.UI.UIMessageBoxButtons)"/> 友好界面显示并在日志记录器中记录异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="terminating">是否终止程序</param>
        public static Exception ShowAndLog(this Exception ex, Logger logger, bool terminating = false)
        {
            logger.Add(new Log(ex.ToString(), terminating ? LogLevel.Fatal : LogLevel.Error));
            MessageBoxUtilities.ShowError($"程序给你抛出了异常，异常消息：\n{ex.Message}\n详细信息请查看日志，并提交 Issue，有能力的话也可以发 Pull Request 哦");

            return ex;
        }

        public static string NotEmptyOrDefault(this string str) => string.IsNullOrEmpty(str) ? null : str;
    }
}
