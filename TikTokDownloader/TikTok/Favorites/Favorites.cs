using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTokDownloader.TikTok.Favorites
{
    public class Video
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
        public string Cover { get; set; }

        [JsonProperty("originCover")]
        public string OriginCover { get; set; }

        [JsonProperty("dynamicCover")]
        public string DynamicCover { get; set; }

        [JsonProperty("playAddr")]
        public string PlayAddr { get; set; }

        [JsonProperty("downloadAddr")]
        public string DownloadAddr { get; set; }

        [JsonProperty("shareCover")]
        public IList<string> ShareCover { get; set; }

        [JsonProperty("reflowCover")]
        public string ReflowCover { get; set; }
    }

    public class Author
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatarThumb")]
        public string AvatarThumb { get; set; }

        [JsonProperty("avatarMedium")]
        public string AvatarMedium { get; set; }

        [JsonProperty("avatarLarger")]
        public string AvatarLarger { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("secUid")]
        public string SecUid { get; set; }

        [JsonProperty("secret")]
        public bool Secret { get; set; }

        [JsonProperty("ftc")]
        public bool Ftc { get; set; }

        [JsonProperty("relation")]
        public long Relation { get; set; }

        [JsonProperty("openFavorite")]
        public bool OpenFavorite { get; set; }

        [JsonProperty("commentSetting")]
        public long CommentSetting { get; set; }

        [JsonProperty("duetSetting")]
        public long DuetSetting { get; set; }

        [JsonProperty("stitchSetting")]
        public long StitchSetting { get; set; }

        [JsonProperty("privateAccount")]
        public bool PrivateAccount { get; set; }
    }

    public class Music
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("playUrl")]
        public string PlayUrl { get; set; }

        [JsonProperty("coverThumb")]
        public string CoverThumb { get; set; }

        [JsonProperty("coverMedium")]
        public string CoverMedium { get; set; }

        [JsonProperty("coverLarge")]
        public string CoverLarge { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("original")]
        public bool Original { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }
    }

    public class Challenge
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

        [JsonProperty("isCommerce")]
        public bool IsCommerce { get; set; }
    }

    public class Stats
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

    public class DuetInfo
    {

        [JsonProperty("duetFromId")]
        public string DuetFromId { get; set; }
    }

    public class TextExtra
    {

        [JsonProperty("awemeId")]
        public string AwemeId { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("hashtagName")]
        public string HashtagName { get; set; }

        [JsonProperty("hashtagId")]
        public string HashtagId { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("isCommerce")]
        public bool IsCommerce { get; set; }

        [JsonProperty("userUniqueId")]
        public string UserUniqueId { get; set; }

        [JsonProperty("secUid")]
        public string SecUid { get; set; }
    }

    public class AuthorStats
    {

        [JsonProperty("followingCount")]
        public long FollowingCount { get; set; }

        [JsonProperty("followerCount")]
        public long FollowerCount { get; set; }

        [JsonProperty("heartCount")]
        public long HeartCount { get; set; }

        [JsonProperty("videoCount")]
        public long VideoCount { get; set; }

        [JsonProperty("diggCount")]
        public long DiggCount { get; set; }

        [JsonProperty("heart")]
        public long Heart { get; set; }
    }

    public class StickersOnItem
    {

        [JsonProperty("stickerType")]
        public long StickerType { get; set; }

        [JsonProperty("stickerText")]
        public IList<string> StickerText { get; set; }
    }

    public class EffectSticker
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ID")]
        public string ID { get; set; }
    }

    public class FavoriteItem
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

        [JsonProperty("challenges")]
        public IList<Challenge> Challenges { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("duetInfo")]
        public DuetInfo DuetInfo { get; set; }

        [JsonProperty("originalItem")]
        public bool OriginalItem { get; set; }

        [JsonProperty("officalItem")]
        public bool OfficalItem { get; set; }

        [JsonProperty("textExtra")]
        public IList<TextExtra> TextExtra { get; set; }

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

        [JsonProperty("itemMute")]
        public bool ItemMute { get; set; }

        [JsonProperty("authorStats")]
        public AuthorStats AuthorStats { get; set; }

        [JsonProperty("privateItem")]
        public bool PrivateItem { get; set; }

        [JsonProperty("duetEnabled")]
        public bool DuetEnabled { get; set; }

        [JsonProperty("stitchEnabled")]
        public bool StitchEnabled { get; set; }

        [JsonProperty("shareEnabled")]
        public bool ShareEnabled { get; set; }

        [JsonProperty("isAd")]
        public bool IsAd { get; set; }

        [JsonProperty("stickersOnItem")]
        public IList<StickersOnItem> StickersOnItem { get; set; }

        [JsonProperty("effectStickers")]
        public IList<EffectSticker> EffectStickers { get; set; }

        [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Header> Headers { get; set; } = new List<Header>();
    }

    public class Favorites
    {

        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("itemList")]
        public IList<FavoriteItem> ItemList { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }


}
