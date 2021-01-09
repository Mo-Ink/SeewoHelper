﻿using System.Windows.Forms;

namespace SeewoHelper
{
    /// <summary>
    /// 提供 <see cref="System.Windows.Forms"/> 命名空间下相关的扩展方法
    /// </summary>
    internal static class FormsExtensions
    {
        /// <summary>
        /// 设置 <see cref="LinkLabel"/> 实例的文本，若文本为 <see langword="null"/> 时显示默认文本并设置 <see cref="Control.Enabled"/> 为 <see langword="false"/>
        /// </summary>
        /// <param name="linkLabel"><see cref="LinkLabel"/> 实例</param>
        /// <param name="text">文本</param>
        /// <param name="nullText">文本为 <see langword="null"/> 时显示的默认文本</param>
        public static void SetText(this LinkLabel linkLabel, string text, string nullText)
        {
            linkLabel.Text = text ?? nullText;
            linkLabel.Enabled = text != null;
        }
    }
}
