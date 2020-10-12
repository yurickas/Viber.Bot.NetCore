# Viber.Bot.NetCore
Viber-bot API for ASP.Net Core 3.x

## How to work with him

1. Create new ASP.NET Core 3.1 project.
2. Install package
3. Add middleware in to `sturtup.cs`

```c#
public void ConfigureServices(IServiceCollection services)
{
    ...    
    services.AddViberBotApi(opt =>
            {
                opt.Token = "YOUR_API_TOKEN";
                opt.Webhook = "YOUR_URL_WEBHOOK";
            });

    ...
}
```

If you want to gets settings from `application.json` then add section in to file:
```c#
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ViberBot": {
    "Token": "YOUR_API_TOKEN",
    "Webhook": "YOUR_URL_WEBHOOK"
  } 
}

```
and add middleware in to `sturtup.cs`
```c#
public void ConfigureServices(IServiceCollection services)
{
    ...    
    services.AddViberBotApi(Configuration);

    ...
}
```

4. Create controller for webhooks
```c#
    [Route("[controller]")]
    [ApiController]
    public class ViberController : ControllerBase
    {
        private readonly IViberBotApi _viberBotApi;
        
        public ViberController(IViberBotApi viberBotApi)
        {
            _viberBotApi = viberBotApi;
        }

        // The service sets a webhook automatically, but if you want sets him manually then use this
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _viberBotApi.SetWebHookAsync(new ViberWebHook.WebHookRequest("YOUR_WEBHOOK_URL"));

            if (response.Content.Status == ViberErrorCode.Ok)
            {
                return Ok("Viber-bot is active");
            }
            else
            {
                return BadRequest(response.Content.StatusMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ViberCallbackData update)
        {
            var str = String.Empty;

            switch (update.Message.Type)
            {
                case ViberMessageType.Text:
                {
                    var mess = update.Message as ViberMessage.TextMessage;

                    str = mess.Text;

                    break;
                }

                    default: break;
            }

            // you should to control required fields
            var message = new ViberMessage.TextMessage()
            {
                //required
                Receiver = update.Sender.Id,
                Sender = new ViberUser.User()
                {
                    //required
                    Name = "Our bot",
                    Avatar = "http://dl-media.viber.com/1/share/2/long/bots/generic-avatar%402x.png"
                },
                //required
                Text = str
            };

            // our bot returns incoming text
            var response = await _viberBotApi.SendMessageAsync<ViberResponse.SendMessageResponse>(message);

            return Ok();
        }
    }
