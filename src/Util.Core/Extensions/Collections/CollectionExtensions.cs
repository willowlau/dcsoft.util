﻿using System;
using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Util.Utils;

// ReSharper disable once CheckNamespace
namespace Util.Extensions
{
    /// <summary>
    /// 集合(<see cref="ICollection{T}"/>) 扩展
    /// </summary>
    public static class CollectionExtensions
    {
        #region RemoveAll(移除项)

        /// <summary>
        /// 移除项。指定集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">集合</param>
        /// <param name="items">集合项</param>
        public static void RemoveAll<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(items, nameof(items));

            foreach (var item in items)
                source.Remove(item);
        }

        /// <summary>
        /// 移除项。按条件移除
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">集合</param>
        /// <param name="predicate">条件</param>
        public static IList<T> RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(predicate, nameof(predicate));

            var items = source.Where(predicate).ToList();
            foreach (var item in items)
                source.Remove(item);
            return items;
        }

        #endregion

        #region AddRange(添加批量项)

        /// <summary>
        /// 添加批量项。
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="enumerable">元素集合</param>
        /// <exception cref="ArgumentNullException">源集合对象为空、添加的集合项为空</exception>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), $@"源{typeof(T).Name}集合对象不可为空！");
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable), $@"要添加的{typeof(T).Name}集合项不可为空！");
            enumerable.ForEach(collection.Add);
        }

        #endregion

        #region Sort(排序)

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="comparer">比较器</param>
        public static void Sort<T>(this ICollection<T> collection, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var list = new List<T>(collection);
            list.Sort(comparer);
            collection.ReplaceItems(list);
        }

        #endregion

        #region ReplaceItems(替换项)

        /// <summary>
        /// 替换项
        /// </summary>
        /// <typeparam name="TItem">项类型</typeparam>
        /// <typeparam name="TNewItem">新项类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="newItems">新项集合</param>
        /// <param name="createItemAction">创建项操作</param>
        public static void ReplaceItems<TItem, TNewItem>(this ICollection<TItem> collection,
            IEnumerable<TNewItem> newItems, Func<TNewItem, TItem> createItemAction)
        {
            collection.CheckNotNull(nameof(collection));
            newItems.CheckNotNull(nameof(newItems));
            createItemAction.CheckNotNull(nameof(createItemAction));

            collection.Clear();
            var convertedNewItems = newItems.Select(createItemAction);
            collection.AddRange(convertedNewItems);
        }

        /// <summary>
        /// 替换项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="newItems">新项集合</param>
        public static void ReplaceItems<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            collection.CheckNotNull(nameof(collection));
            newItems.CheckNotNull(nameof(newItems));

            collection.ReplaceItems(newItems, x => x);
        }

        #endregion
    }
}