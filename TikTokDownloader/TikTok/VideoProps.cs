using System;
using Newtonsoft.Json;

namespace TikTokDownloader.TikTok
{
        public partial class VideoProps
        {
            [JsonProperty("/v/:id")]
            public VId VId { get; set; }
        }

        public partial class VId
        {
            [JsonProperty("$isMobile")]
            public bool IsMobile { get; set; }

            [JsonProperty("$isIOS")]
            public object IsIos { get; set; }

            [JsonProperty("$isAndroid")]
            public bool IsAndroid { get; set; }

            [JsonProperty("$origin")]
            public Uri Origin { get; set; }

            [JsonProperty("$pageUrl")]
            public string PageUrl { get; set; }

            [JsonProperty("$language")]
            public string Language { get; set; }

            [JsonProperty("$originalLanguage")]
            public string OriginalLanguage { get; set; }

            [JsonProperty("$region")]
            public string Region { get; set; }

            [JsonProperty("$appId")]
            public long AppId { get; set; }

            [JsonProperty("$os")]
            public string Os { get; set; }

            [JsonProperty("$baseURL")]
            public string BaseUrl { get; set; }

            [JsonProperty("$downloadLink")]
            public DownloadLink DownloadLink { get; set; }

            [JsonProperty("$appType")]
            public string AppType { get; set; }

            [JsonProperty("$reflowType")]
            public string ReflowType { get; set; }

            [JsonProperty("$wid")]
            public string Wid { get; set; }

            [JsonProperty("videoObjectPageProps")]
            public VideoObjectPageProps VideoObjectPageProps { get; set; }

            [JsonProperty("pageState")]
            public PageState PageState { get; set; }

            [JsonProperty("videoData")]
            public VideoData VideoData { get; set; }

            [JsonProperty("shareUser")]
            public ShareUser ShareUser { get; set; }

            [JsonProperty("shareMeta")]
            public ShareMeta ShareMeta { get; set; }

            [JsonProperty("statusCode")]
            public long StatusCode { get; set; }

            [JsonProperty("$abTestVersion")]
            public AbTestVersion AbTestVersion { get; set; }

            [JsonProperty("webId")]
            public string WebId { get; set; }

            [JsonProperty("requestId")]
            public string RequestId { get; set; }

            [JsonProperty("config")]
            public Config Config { get; set; }
        }

        public partial class AbTestVersion
        {
            [JsonProperty("clientParameters")]
            public string ClientParameters { get; set; }

            [JsonProperty("clientVersionName")]
            public string ClientVersionName { get; set; }

            [JsonProperty("versionName")]
            public string VersionName { get; set; }

            [JsonProperty("parameters")]
            public string Parameters { get; set; }

            [JsonProperty("startTime")]
            public string StartTime { get; set; }

            [JsonProperty("endTime")]
            public string EndTime { get; set; }
        }

        public partial class Config
        {
            [JsonProperty("isDirectJump")]
            public bool IsDirectJump { get; set; }
        }

        public partial class DownloadLink
        {
            [JsonProperty("amazon")]
            public Amazon Amazon { get; set; }

            [JsonProperty("google")]
            public Amazon Google { get; set; }

            [JsonProperty("apple")]
            public Amazon Apple { get; set; }
        }

        public partial class Amazon
        {
            [JsonProperty("visible")]
            public bool Visible { get; set; }

            [JsonProperty("normal")]
            public Uri Normal { get; set; }
        }

        public partial class PageState
        {
            [JsonProperty("regionAppId")]
            public long RegionAppId { get; set; }

            [JsonProperty("os")]
            public string Os { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("baseURL")]
            public string BaseUrl { get; set; }

            [JsonProperty("appType")]
            public string AppType { get; set; }

            [JsonProperty("fullUrl")]
            public Uri FullUrl { get; set; }
        }

        public partial class ShareMeta
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("desc")]
            public string Desc { get; set; }

            [JsonProperty("image")]
            public Image Image { get; set; }
        }

        public partial class Image
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }
        }

        public partial class ShareUser
        {
            [JsonProperty("secUid")]
            public string SecUid { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("uniqueId")]
            public string UniqueId { get; set; }

            [JsonProperty("nickName")]
            public string NickName { get; set; }

            [JsonProperty("signature")]
            public string Signature { get; set; }

            [JsonProperty("verified")]
            public bool Verified { get; set; }

            [JsonProperty("covers")]
            public Uri[] Covers { get; set; }

            [JsonProperty("coversMedium")]
            public Uri[] CoversMedium { get; set; }

            [JsonProperty("coversLarger")]
            public Uri[] CoversLarger { get; set; }

            [JsonProperty("isSecret")]
            public bool IsSecret { get; set; }
        }

        public partial class VideoData
        {
            [JsonProperty("itemInfos")]
            public ItemInfos ItemInfos { get; set; }

            [JsonProperty("authorInfos")]
            public AuthorInfos AuthorInfos { get; set; }

            [JsonProperty("musicInfos")]
            public MusicInfos MusicInfos { get; set; }

            [JsonProperty("authorStats")]
            public AuthorStats AuthorStats { get; set; }

            [JsonProperty("challengeInfoList")]
            public ChallengeInfoList[] ChallengeInfoList { get; set; }

            [JsonProperty("duetInfo")]
            //[JsonConverter(typeof(ParseStringConverter))]
            public long DuetInfo { get; set; }

            [JsonProperty("textExtra")]
            public TextExtra[] TextExtra { get; set; }
        }

        public partial class AuthorInfos
        {
            [JsonProperty("verified")]
            public bool Verified { get; set; }

            [JsonProperty("secUid")]
            public string SecUid { get; set; }

            [JsonProperty("uniqueId")]
            public string UniqueId { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("nickName")]
            public string NickName { get; set; }

            [JsonProperty("covers")]
            public Uri[] Covers { get; set; }
        }

        public partial class AuthorStats
        {
            [JsonProperty("followerCount")]
            public long FollowerCount { get; set; }

            [JsonProperty("heartCount")]
            //[JsonConverter(typeof(ParseStringConverter))]
            public long HeartCount { get; set; }
        }

        public partial class ChallengeInfoList
        {
            [JsonProperty("challengeId")]
            public string ChallengeId { get; set; }

            [JsonProperty("challengeName")]
            public string ChallengeName { get; set; }
        }

        public partial class ItemInfos
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("video")]
            public Video Video { get; set; }

            [JsonProperty("covers")]
            public Uri[] Covers { get; set; }

            [JsonProperty("authorId")]
            public string AuthorId { get; set; }

            [JsonProperty("coversOrigin")]
            public Uri[] CoversOrigin { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("commentCount")]
            public long CommentCount { get; set; }

            [JsonProperty("diggCount")]
            public long DiggCount { get; set; }

            [JsonProperty("playCount")]
            public long PlayCount { get; set; }

            [JsonProperty("shareCount")]
            public long ShareCount { get; set; }

            [JsonProperty("createTime")]
            //[JsonConverter(typeof(ParseStringConverter))]
            public long CreateTime { get; set; }

            [JsonProperty("isActivityItem")]
            public bool IsActivityItem { get; set; }

            [JsonProperty("warnInfo")]
            public object[] WarnInfo { get; set; }
        }

        public partial class Video
        {
            [JsonProperty("urls")]
            public Uri[] Urls { get; set; }

            [JsonProperty("videoMeta")]
            public VideoMeta VideoMeta { get; set; }
        }

        public partial class VideoMeta
        {
            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("ratio")]
            public long Ratio { get; set; }

            [JsonProperty("duration")]
            public long Duration { get; set; }
        }

        public partial class MusicInfos
        {
            [JsonProperty("musicId")]
            public string MusicId { get; set; }

            [JsonProperty("musicName")]
            public string MusicName { get; set; }

            [JsonProperty("authorName")]
            public string AuthorName { get; set; }

            [JsonProperty("covers")]
            public Uri[] Covers { get; set; }
        }

        public partial class TextExtra
        {
            [JsonProperty("AwemeId")]
            public string AwemeId { get; set; }

            [JsonProperty("Start")]
            public long Start { get; set; }

            [JsonProperty("End")]
            public long End { get; set; }

            [JsonProperty("HashtagName")]
            public string HashtagName { get; set; }

            [JsonProperty("HashtagId")]
            public string HashtagId { get; set; }

            [JsonProperty("Type")]
            public long Type { get; set; }

            [JsonProperty("UserId")]
            public string UserId { get; set; }

            [JsonProperty("IsCommerce")]
            public bool IsCommerce { get; set; }
        }

        public partial class VideoObjectPageProps
        {
            [JsonProperty("videoProps")]
            public VideoPropsClass VideoProps { get; set; }

            [JsonProperty("pageProps")]
            public PageProps PageProps { get; set; }

            [JsonProperty("breadcrumbProps")]
            public BreadcrumbProps BreadcrumbProps { get; set; }
        }

        public partial class BreadcrumbProps
        {
            [JsonProperty("urlList")]
            public UrlList[] UrlList { get; set; }
        }

        public partial class UrlList
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }
        }

        public partial class PageProps
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public Uri Id { get; set; }
        }

        public partial class VideoPropsClass
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("keywords")]
            public string Keywords { get; set; }

            [JsonProperty("thumbnailUrl")]
            public Uri[] ThumbnailUrl { get; set; }

            [JsonProperty("uploadDate")]
            public DateTimeOffset UploadDate { get; set; }

            [JsonProperty("contentUrl")]
            public Uri ContentUrl { get; set; }

            [JsonProperty("embedUrl")]
            public Uri EmbedUrl { get; set; }

            [JsonProperty("commentCount")]
            //[JsonConverter(typeof(ParseStringConverter))]
            public long CommentCount { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("audio")]
            public Audio Audio { get; set; }

            [JsonProperty("creator")]
            public Creator Creator { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("interactionStatistic")]
            public VideoPropsInteractionStatistic[] InteractionStatistic { get; set; }
        }

        public partial class Audio
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("mainEntityOfPage")]
            public MainEntityOfPage MainEntityOfPage { get; set; }
        }

        public partial class MainEntityOfPage
        {
            [JsonProperty("@type")]
            public string Type { get; set; }

            [JsonProperty("@id")]
            public Uri Id { get; set; }
        }

        public partial class Creator
        {
            [JsonProperty("@type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("interactionStatistic")]
            public CreatorInteractionStatistic[] InteractionStatistic { get; set; }
        }

        public partial class CreatorInteractionStatistic
        {
            [JsonProperty("@type")]
            public string Type { get; set; }

            [JsonProperty("interactionType")]
            public InteractionType InteractionType { get; set; }

            [JsonProperty("userInteractionCount")]
            //[JsonConverter(typeof(DecodingChoiceConverter))]
            public long UserInteractionCount { get; set; }
        }

        public partial class InteractionType
        {
            [JsonProperty("@type")]
            public Uri Type { get; set; }
        }

        public partial class VideoPropsInteractionStatistic
        {
            [JsonProperty("@type")]
            public string Type { get; set; }

            [JsonProperty("interactionType")]
            public InteractionType InteractionType { get; set; }

            [JsonProperty("userInteractionCount")]
            public long UserInteractionCount { get; set; }
        }
    }
