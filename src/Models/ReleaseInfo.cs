﻿using System.Text.Json.Serialization;

namespace SeewoHelper
{
    /// <summary>
    /// 表示 Release 信息
    /// </summary>
    public record ReleaseInfo
    {
        /// <summary>
        /// 页面 Url
        /// </summary>
        [JsonPropertyName("html_url")]
        public string Url { get; init; }

        /// <summary>
        /// Release 名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        /// Tag 名称
        /// </summary>
        [JsonPropertyName("tag_name")]
        public string Tag { get; init; }

        /// <summary>
        /// 是否为 Pre-Release
        /// </summary>
        [JsonPropertyName("prerelease")]
        public bool IsPrerelease { get; init; }

        /// <summary>
        /// Release 资源
        /// </summary>
        [JsonPropertyName("assets")]
        public AssetInfo[] Assets { get; init; }

        /// <summary>
        /// 创建 <see cref="ReleaseInfo"/> 实例
        /// </summary>
        /// <param name="url">页面 Url</param>
        /// <param name="name">Release 名称</param>
        /// <param name="assets">Release 资源</param>
        /// <param name="tag">Tag 名称</param>
        /// <param name="isPrerelease">是否为 Pre-Release</param>
        [JsonConstructor]
        public ReleaseInfo(string url, string name, string tag, bool isPrerelease, AssetInfo[] assets)
        {
            Url = url;
            Name = name;
            Tag = tag;
            IsPrerelease = isPrerelease;
            Assets = assets;
        }
    }
}
