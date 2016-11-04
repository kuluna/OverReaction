セットアップ
---

# はじめに
OverReactionはSlackと連携するBotサーバーです。
SlackのOutgoing Webhooksを利用するので、SlackからアクセスできるWebサーバーでOverReactionを実行してください。

# セットアップ
## Slackの準備
### API Tokenの準備
1. [https://api.slack.com/docs/oauth-test-tokens](https://api.slack.com/docs/oauth-test-tokens) にアクセスします。
1. OverReactionを設置するチーム名のTokenを生成します。このTokenを控えておいてください。

### Webhookの準備
1. https://チーム名.slack.com/apps にアクセスします。
1. 「outgoing webhooks」で検索します。
1. Add Configuration ボタンを押し、Slackに追加します。
1. Channelは任意の1チャネルを選択してください。(ex: #general)
1. **Trigger Wordを設定すると設定したテキストしかOverReactionに送られなくなります。**
1. URLにはOverReactionのWebhookAPIのアドレスを指定します。(ex: https://overreaction.example.com/api/webhook)  
1. TokenはOverReactionがSlackから来たWebhookかどうかを検証するために使います。控えておいてください。

![webhook](img/webhook.png)

## OverReactionの準備
1. OverReactionのソースをダウンロードします。
1. `src/OverReaction/appsettings.json` を開きます。
1. AppSettingの下にあるXoxpTokenとWebhookTokenにそれぞれ控えたTokenを入力します。
1. 実行サーバーに [.NET Core](http://go.microsoft.com/fwlink/?LinkID=798306&clcid=0x409) をインストールします。
1. 実行サーバーにOverReactionをコピーし、OverReactionのフォルダで以下のコマンドを実行します。  
Windows  
`cd src\OverReaction & dotnet restore & dotnet run`  
Mac or Linux  
`cd src/OverReaction && dotnet restore && dotnet run`
1. 立ち上がったサーバーにアクセスして、OverReactionの設定ページが開けることを確認してください。

## トライ
1. OverReaction設定ページで右下の+アイコンを押してWordとEmojiを追加します。  
1. SlackでWordを含むテキストを送信します。
1. Slackで設定したリアクションが自動的に追加されれば完了です！  
![Demo](img/demo.gif)
