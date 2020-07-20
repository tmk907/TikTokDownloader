using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTokDownloader
{
    public partial class HarArchive
    {
        [JsonProperty("log")]
        public Log Log { get; set; }
    }

    public partial class Log
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("creator")]
        public Creator Creator { get; set; }

        [JsonProperty("pages")]
        public List<object> Pages { get; set; }

        [JsonProperty("entries")]
        public List<Entry> Entries { get; set; }
    }

    public partial class Creator
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("startedDateTime")]
        public DateTimeOffset StartedDateTime { get; set; }

        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }

        [JsonProperty("cache")]
        public Cache Cache { get; set; }

        [JsonProperty("timings")]
        public Timings Timings { get; set; }

        [JsonProperty("serverIPAddress")]
        public string ServerIpAddress { get; set; }

        [JsonProperty("_initiator")]
        public Initiator Initiator { get; set; }

        [JsonProperty("_priority")]
        public string Priority { get; set; }

        [JsonProperty("_resourceType")]
        public string ResourceType { get; set; }
    }

    public partial class Cache
    {
    }

    public partial class Initiator
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("stack")]
        public Stack Stack { get; set; }
    }

    public partial class Stack
    {
        [JsonProperty("callFrames")]
        public List<CallFrame> CallFrames { get; set; }
    }

    public partial class CallFrame
    {
        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        [JsonProperty("scriptId")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long ScriptId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("lineNumber")]
        public long LineNumber { get; set; }

        [JsonProperty("columnNumber")]
        public long ColumnNumber { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("httpVersion")]
        public string HttpVersion { get; set; }

        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }

        [JsonProperty("queryString")]
        public List<Header> QueryString { get; set; }

        [JsonProperty("cookies")]
        public List<Cooky> Cookies { get; set; }

        [JsonProperty("headersSize")]
        public long HeadersSize { get; set; }

        [JsonProperty("bodySize")]
        public long BodySize { get; set; }
    }

    public partial class Cooky
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("expires")]
        public object Expires { get; set; }

        [JsonProperty("httpOnly")]
        public bool HttpOnly { get; set; }

        [JsonProperty("secure")]
        public bool Secure { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("statusText")]
        public string StatusText { get; set; }

        [JsonProperty("httpVersion")]
        public string HttpVersion { get; set; }

        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }

        [JsonProperty("cookies")]
        public List<object> Cookies { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("redirectURL")]
        public string RedirectUrl { get; set; }

        [JsonProperty("headersSize")]
        public long HeadersSize { get; set; }

        [JsonProperty("bodySize")]
        public long BodySize { get; set; }

        [JsonProperty("_transferSize")]
        public long TransferSize { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Timings
    {
        [JsonProperty("blocked")]
        public double Blocked { get; set; }

        [JsonProperty("dns")]
        public long Dns { get; set; }

        [JsonProperty("ssl")]
        public long Ssl { get; set; }

        [JsonProperty("connect")]
        public long Connect { get; set; }

        [JsonProperty("send")]
        public double Send { get; set; }

        [JsonProperty("wait")]
        public double Wait { get; set; }

        [JsonProperty("receive")]
        public double Receive { get; set; }

        [JsonProperty("_blocked_queueing")]
        public double BlockedQueueing { get; set; }
    }
}
