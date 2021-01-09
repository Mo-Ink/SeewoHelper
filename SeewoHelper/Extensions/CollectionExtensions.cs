﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SeewoHelper
{
    /// <summary>
    /// 提供 <see cref="System.Collections"/> 命名空间下相关的扩展方法
    /// </summary>
    internal static class CollectionExtensions
    {
        /// <summary>
        /// 添加元素至目标集合，并返回所添加的元素
        /// </summary>
        /// <typeparam name="TCollection"><see cref="ICollection{T}"/> 的泛型类型</typeparam>
        /// <typeparam name="TElement">元素类型</typeparam>
        /// <param name="collection">目标集合</param>
        /// <param name="element">元素</param>
        /// <returns>所添加的元素</returns>
        public static TElement AddElement<TCollection, TElement>(this ICollection<TCollection> collection, TElement element)
            where TElement : TCollection
        {
            collection.Add(element);
            return element;
        }

        /// <summary>
        /// 通过 Value 获取对应 Key
        /// </summary>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <param name="dictionary"><see cref="Dictionary{TKey, TValue}"/> 实例</param>
        /// <param name="value">指定 Value</param>
        /// <returns></returns>
        public static TKey GetKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value) => dictionary.Where(x => x.Value.Equals(value)).Single().Key;

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logger">日志记录器</param>
        /// <param name="content">内容</param>
        /// <param name="level">等级</param>
        public static void Add(this Logger logger, string content, LogLevel level = LogLevel.Info) => logger.Add(new Log(content, level));

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logger">日志记录器</param>
        /// <param name="content">内容</param>
        /// <param name="time">时间</param>
        /// <param name="level">等级</param>
        public static void Add(this Logger logger, string content, DateTime time, LogLevel level = LogLevel.Info) => logger.Add(new Log(content, time, level));
    }
}
