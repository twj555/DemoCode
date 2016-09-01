﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Example
{

    internal class Pin
    {

        [JsonProperty("pin_id")]
        public int? PinId { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("board_id")]
        public int? BoardId { get; set; }

        [JsonProperty("file_id")]
        public int? FileId { get; set; }

        [JsonProperty("file")]
        public File File { get; set; }

        [JsonProperty("media_type")]
        public int? MediaType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("raw_text")]
        public string RawText { get; set; }

        [JsonProperty("text_meta")]
        public TextMeta TextMeta { get; set; }

        [JsonProperty("via")]
        public int? Via { get; set; }

        [JsonProperty("via_user_id")]
        public int? ViaUserId { get; set; }

        [JsonProperty("original")]
        public int? Original { get; set; }

        [JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

        [JsonProperty("like_count")]
        public int? LikeCount { get; set; }

        [JsonProperty("comment_count")]
        public int? CommentCount { get; set; }

        [JsonProperty("repin_count")]
        public int? RepinCount { get; set; }

        [JsonProperty("is_private")]
        public int? IsPrivate { get; set; }

        [JsonProperty("orig_source")]
        public object OrigSource { get; set; }

        [JsonProperty("hide_origin")]
        public bool HideOrigin { get; set; }
    }

}