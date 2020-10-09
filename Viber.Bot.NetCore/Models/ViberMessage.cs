using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Viber.Bot.NetCore.Infrastructure;

namespace Viber.Bot.NetCore.Models
{
    public static class ViberMessage
    {
		public abstract class MessageBase
        {
            protected MessageBase(string type)
            {
                Type = type;
            }

            [JsonProperty("receiver")]
            public string Receiver { get; set; }

            [JsonProperty("type")]
            public string Type { get; }

            [JsonProperty("sender")]
            public ViberUser.UserBase Sender { get; set; }

            [JsonProperty("tracking_data")]
            public string TrackingData { get; set; }

            [JsonProperty("min_api_version")]
            public double? MinApiVersion { get; set; }
        }

        public class TextMessage : MessageBase
        {
            public TextMessage()
                : base(ViberMessageType.Text)
            {
            }

            /// <summary>
            /// The text of the message.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public class BroadcastMessage : TextMessage
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BroadcastMessage"/> class.
            /// </summary>
            public BroadcastMessage()
            {
                
            }
            /// <summary>
            /// The list of accounts identifiers to send messages to multiple Viber users (who subscribed to the account).
            /// </summary>
            [JsonProperty("broadcast_list")]
            public IList<string> BroadcastList { get; set; }
        }

        public class ContactMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ContactMessage"/> class.
            /// </summary>
            public ContactMessage()
                : base(ViberMessageType.Contact)
            {
            }

            /// <summary>
            /// Contact object.
            /// </summary>
            [JsonProperty("contact")]
            public ViberContact Contact { get; set; }
        }

        public class FileMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FileMessage"/> class.
            /// </summary>
            public FileMessage()
                : base(ViberMessageType.File)
            {
            }

            /// <summary>
            /// URL of the file. Max size 50 MB. See forbidden file formats for unsupported file types
            /// </summary>
            [JsonProperty("media")]
            public string Media { get; set; }

            /// <summary>
            /// Size of the file in bytes.
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }

            /// <summary>
            /// Name of the file. File name should include extension. Max 256 characters (including file extension). Sending a file without extension or with the wrong extension might cause the client to be unable to open the file.
            /// </summary>
            [JsonProperty("file_name")]
            public string FileName { get; set; }
        }

        public class KeyboardMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="KeyboardMessage"/> class.
            /// </summary>
            public KeyboardMessage()
                : base(ViberMessageType.Text)
            {
            }

            /// <summary>
            /// The text of the message.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Keyboard object.
            /// </summary>
            [JsonProperty("keyboard")]
            public ViberKeyboard Keyboard { get; set; }
        }

        public class LocationMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LocationMessage"/> class.
            /// </summary>
            public LocationMessage()
                : base(ViberMessageType.Location)
            {
            }

            /// <summary>
            /// Location data.
            /// </summary>
            [JsonProperty("location")]
            public ViberLocation Location { get; set; }
        }

        public class PictureMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PictureMessage"/> class.
            /// </summary>
            public PictureMessage()
                : base(ViberMessageType.Picture)
            {
                Text = String.Empty;
            }

            /// <summary>
            /// The text of the message.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// URL of the image (JPEG).
            /// </summary>
            [JsonProperty("media")]
            public string Media { get; set; }

            /// <summary>
            /// URL of a reduced size image (JPEG).
            /// </summary>
            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }
        }

        public class StickerMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StickerMessage"/> class.
            /// </summary>
            public StickerMessage()
                : base(ViberMessageType.Sticker)
            {
            }

            /// <summary>
            /// Unique Viber sticker ID.
            /// </summary>
            [JsonProperty("sticker_id")]
            public string StickerId { get; set; }
        }
        public class UrlMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UrlMessage"/> class.
            /// </summary>
            public UrlMessage()
                : base(ViberMessageType.Url)
            {
            }

            /// <summary>
            /// URL, max 2000 characters.
            /// </summary>
            [JsonProperty("media")]
            public string Media { get; set; }
        }
        public class VideoMessage : MessageBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="VideoMessage"/> class.
            /// </summary>
            public VideoMessage()
                : base(ViberMessageType.Video)
            {
            }

            /// <summary>
            /// URL of the video (MP4, H264). Max size 50 MB. Only MP4 and H264 are supported.
            /// </summary>
            [JsonProperty("media")]
            public string Media { get; set; }

            /// <summary>
            /// URL of a reduced size image (JPEG). Max size 100 kb. Recommended: 400x400. Only JPEG format is supported.
            /// </summary>
            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }

            /// <summary>
            /// Size of the video in bytes.
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }

            /// <summary>
            /// Video duration in seconds; will be displayed to the receiver. Max 180 seconds.
            /// </summary>
            [JsonProperty("duration")]
            public int? Duration { get; set; }
        }
    }
}