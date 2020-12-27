﻿using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace SeewoHelper
{
    public class Keyword
    {
        [JsonProperty(PropertyName = "pattern")]
        public string Pattern { get; set; }

        [JsonProperty(PropertyName = "matchingWay")]
        public KeywordMatchingWay MatchingWay { get; set; }

        public bool IsMatch(string input) => MatchingWay switch
        {
            KeywordMatchingWay.Normal => input.Contains(Pattern),
            KeywordMatchingWay.CaseInsensitive => input.ToLower().Contains(Pattern.ToLower()),
            KeywordMatchingWay.Regex => new Regex(Pattern).IsMatch(input),
            _ => throw new InvalidOperationException()
        };

        [JsonConstructor]
        public Keyword(string pattern, KeywordMatchingWay matchingWay)
        {
            Pattern = pattern;
            MatchingWay = matchingWay;
        }
    }

    public enum KeywordMatchingWay
    {
        Normal,
        CaseInsensitive,
        Regex
    }
}
