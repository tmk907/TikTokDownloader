using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTokDownloader.TikTok
{
    public partial class Favorites
    {
        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("items")]
        public List<FavoriteItem> Items { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("maxCursor")]
        public string MaxCursor { get; set; }

        [JsonProperty("minCursor")]
        public string MinCursor { get; set; }
    }

    public partial class FavoriteItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("createTime")]
        public long CreateTime { get; set; }

        [JsonProperty("video")]
        public Video Video { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("music")]
        public Music Music { get; set; }

        [JsonProperty("challenges", NullValueHandling = NullValueHandling.Ignore)]
        public List<Challenge> Challenges { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("originalItem")]
        public bool OriginalItem { get; set; }

        [JsonProperty("officalItem")]
        public bool OfficalItem { get; set; }

        [JsonProperty("textExtra", NullValueHandling = NullValueHandling.Ignore)]
        public List<TextExtra> TextExtra { get; set; }

        [JsonProperty("secret")]
        public bool Secret { get; set; }

        [JsonProperty("forFriend")]
        public bool ForFriend { get; set; }

        [JsonProperty("digged")]
        public bool Digged { get; set; }

        [JsonProperty("itemCommentStatus")]
        public long ItemCommentStatus { get; set; }

        [JsonProperty("showNotPass")]
        public bool ShowNotPass { get; set; }

        [JsonProperty("vl1")]
        public bool Vl1 { get; set; }

        [JsonProperty("warnInfo", NullValueHandling = NullValueHandling.Ignore)]
        public List<WarnInfo> WarnInfo { get; set; }

        [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Header> Headers { get; set; } = new List<Header>();
    }

    public partial class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatarThumb")]
        public Uri AvatarThumb { get; set; }

        [JsonProperty("avatarMedium")]
        public Uri AvatarMedium { get; set; }

        [JsonProperty("avatarLarger")]
        public Uri AvatarLarger { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("secUid")]
        public string SecUid { get; set; }

        [JsonProperty("relation")]
        public long Relation { get; set; }

        [JsonProperty("openFavorite")]
        public bool OpenFavorite { get; set; }
    }

    public partial class Challenge
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("profileThumb")]
        public string ProfileThumb { get; set; }

        [JsonProperty("profileMedium")]
        public string ProfileMedium { get; set; }

        [JsonProperty("profileLarger")]
        public string ProfileLarger { get; set; }

        [JsonProperty("coverThumb")]
        public string CoverThumb { get; set; }

        [JsonProperty("coverMedium")]
        public string CoverMedium { get; set; }

        [JsonProperty("coverLarger")]
        public string CoverLarger { get; set; }
    }

    public partial class Music
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("playUrl")]
        public Uri PlayUrl { get; set; }

        [JsonProperty("coverThumb")]
        public Uri CoverThumb { get; set; }

        [JsonProperty("coverMedium")]
        public Uri CoverMedium { get; set; }

        [JsonProperty("coverLarge")]
        public Uri CoverLarge { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("original")]
        public bool Original { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("diggCount")]
        public long DiggCount { get; set; }

        [JsonProperty("shareCount")]
        public long ShareCount { get; set; }

        [JsonProperty("commentCount")]
        public long CommentCount { get; set; }

        [JsonProperty("playCount")]
        public long PlayCount { get; set; }
    }

    //public partial class TextExtra
    //{
    //    [JsonProperty("awemeId")]
    //    public string AwemeId { get; set; }

    //    [JsonProperty("start")]
    //    public long Start { get; set; }

    //    [JsonProperty("end")]
    //    public long End { get; set; }

    //    [JsonProperty("hashtagName")]
    //    public string HashtagName { get; set; }

    //    [JsonProperty("hashtagId")]
    //    public string HashtagId { get; set; }

    //    [JsonProperty("type")]
    //    public long Type { get; set; }

    //    [JsonProperty("userId")]
    //    public UserId UserId { get; set; }

    //    [JsonProperty("isCommerce")]
    //    public bool IsCommerce { get; set; }
    //}

    public partial class Video
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("ratio")]
        public string Ratio { get; set; }

        [JsonProperty("cover")]
        public Uri Cover { get; set; }

        [JsonProperty("originCover")]
        public Uri OriginCover { get; set; }

        [JsonProperty("dynamicCover")]
        public Uri DynamicCover { get; set; }

        [JsonProperty("playAddr")]
        public Uri PlayAddr { get; set; }

        [JsonProperty("downloadAddr")]
        public Uri DownloadAddr { get; set; }

        [JsonProperty("shareCover")]
        [JsonConverter(typeof(ShareCoverConverter))]
        public List<string> ShareCover { get; set; }
    }

    public partial class WarnInfo
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }


    internal class ShareCoverConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(List<string>) || t == typeof(string);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            if (reader.ValueType == typeof(string))
            {
                var value = serializer.Deserialize<string>(reader);
                return new List<string>() { value };
            }
            else
            {
                return serializer.Deserialize<List<string>>(reader);
            }
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (typeof(string) == untypedValue.GetType())
            {
                serializer.Serialize(writer, (string)untypedValue);
                return;
            }
            else
            {
                serializer.Serialize(writer, (List<string>)untypedValue);
                return;
            }
        }

        public static readonly ShareCoverConverter Singleton = new ShareCoverConverter();
    }
}
