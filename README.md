# 描述
Line Message Api .NET 5 SDK
# 如何安裝

```
Nuget
Install-Package NetCoreLineBotSDK -Version 1.0.0
dotnet cli
dotnet add package NetCoreLineBotSDK --version 1.0.0
```

# 快速開始

## 於Line Develop Console 取得 Channel Secret 及 Access Token

https://developers.line.biz/zh-hant/

- [ ] 申請一個Provider
- [ ] 申請一個Channel (一個Provider可以有多個Channel)
- [ ] 於Channel取得 Channel Secret 及 Access Token
- [ ] Use webhook 啟用
- [ ] Auto-reply messages 關閉
- [ ] 設定 Webhook URL (需為https)

## Startup.cs 新增 AddLineBotSDK

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddLineBotSDK(Configuration);
}
```

## appsettings.json 增加ChannelSecret/ChannelAccessToken
```
"LineSetting": {
    "ChannelSecret": "<Your Line Channel Secret>",
    "ChannelAccessToken": "<Your Line Channel Access Token>"
}
```

## 新增一個 Web Api Controller
```
[Route("api/[controller]")]
[ApiController]
public class LineController : ControllerBase
{
    private readonly ILineMessageUtility lineMessageUtility;
    public LineController(ILineMessageUtility _lineMessageUtility)
    {
        lineMessageUtility = _lineMessageUtility;
    }

    [HttpPost]
    [LineVerifySignature]
    public async Task<IActionResult> Post(WebhookEvent request)
    {
        var app = new LineBotSampleApp(lineMessageUtility);
        await app.RunAsync(request.events);
        return Ok();
    }
}
```

## 繼承 LineBotApp，可針對不同事件 override 處理

```
public class LineBotSampleApp : LineBotApp
{
    private readonly ILineMessageUtility lineMessageUtility;
    public LineBotSampleApp(ILineMessageUtility _lineMessageUtility) : base(_lineMessageUtility)
    {
        lineMessageUtility = _lineMessageUtility;
    }

    protected override async Task OnMessageAsync(LineEvent ev)
    {
        await lineMessageUtility.ReplyMessageAsync(ev.replyToken, $"You Said:{ev.message.Text}");
    }
}
```

## Demo

您可加入以下 Bot 並執行指令測試結果，原始碼請見 `NetCoreLineBotSDK.Sample` 

![image](https://user-images.githubusercontent.com/8849818/124583387-906cd400-de85-11eb-907e-a61507fb6703.png)

### Message Types

Message Type 官方文件: https://developers.line.biz/en/docs/messaging-api/message-types/

```
/text
/sticker
/image
/video
/audio
/location
/image-map
/image-map-with-video
/template-buttons
/template-confirm
/template-carousel
/template-carousel-images
```

## 


# Line message Api 官方文件

https://developers.line.biz/en/services/messaging-api/
