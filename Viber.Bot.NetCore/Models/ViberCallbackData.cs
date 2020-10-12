using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Viber.Bot.NetCore.Infrastructure;

namespace Viber.Bot.NetCore.Models
{
	/// <summary>
	/// Webhook callback data.
	/// </summary>
	public class ViberCallbackData
	{
		/// <summary>
		/// Callback type - which event triggered the callback.
		/// </summary>
		[JsonProperty("event")]
		public string Event { get; set; }

		/// <summary>
		/// Unique ID of the message.
		/// </summary>
		[JsonProperty("message_token")]
		public long MessageToken { get; set; }

		/// <summary>
		/// Time of the event that triggered the callback (epoch time).
		/// </summary>
		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }

		/// <summary>
		/// Unique Viber user id.
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		/// Viber user.
		/// </summary>
		[JsonProperty("user")]
		public ViberUser.User User { get; set; }

		/// <summary>
		/// Indicated whether a user is already subscribed.
		/// </summary>
		[JsonProperty("subscribed")]
		public bool? Subscribed { get; set; }

		/// <summary>
		/// Any additional parameters added to the deep link used to access the conversation passed as a string.
		/// </summary>
		/// <remarks>
		/// See deep link section for additional information: https://developers.viber.com/docs/tools/deep-links.
		/// </remarks>
		[JsonProperty("context")]
		public string Context { get; set; }

		/// <summary>
		/// A string describing the failure.
		/// </summary>
		[JsonProperty("desc")]
		public string Description { get; set; }

		/// <summary>
		/// Viber user.
		/// </summary>
		[JsonProperty("sender")]
		public ViberUser.User Sender { get; set; }

		/// <summary>
		/// Message object.
		/// </summary>
		[JsonIgnore]
		public ViberMessage.MessageBase Message { get; set; }

		/// <summary>
		/// Message object.
		/// </summary>
		[JsonProperty("message")]
		private JObject message
		{
			set
			{
				var messageType = value.Property("type")?.Value.ToObject<string>();
				Type type;
				switch (messageType)
				{
					case ViberMessageType.Text:
						type = typeof(ViberMessage.TextMessage);
						break;
					case ViberMessageType.Picture:
						type = typeof(ViberMessage.PictureMessage);
						break;
					case ViberMessageType.Video:
						type = typeof(ViberMessage.VideoMessage);
						break;
					case ViberMessageType.File:
						type = typeof(ViberMessage.FileMessage);
						break;
					case ViberMessageType.Location:
						type = typeof(ViberMessage.LocationMessage);
						break;
					case ViberMessageType.Contact:
						type = typeof(ViberMessage.ContactMessage);
						break;
					case ViberMessageType.Sticker:
						type = typeof(ViberMessage.StickerMessage);
						break;
					case ViberMessageType.CarouselContent:
						throw new NotImplementedException();
					case ViberMessageType.Url:
						type = typeof(ViberMessage.UrlMessage);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				Message = (ViberMessage.MessageBase)value.ToObject(type);
			}
		}
	}
}