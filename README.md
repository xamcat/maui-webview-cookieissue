# maui-webview-cookieissue

## Background

I'm trying to use WebView and inject a cookie and it is not being set by the MAUI WebView. To troubleshoot, I have created a custom MAUI handler to set the same cookie via WebView2 API and it works fine. I was following this Docs to set cookie [WebView - .NET MAUI | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview#set-cookies).

- Works well with WebView2 version created via MAUI handler
- Doesn't work with the MAUI counterpart 

## Cookie sharing app

Uses the [cookie sharing web app](https://github.com/xamcat/cookie-sharing-app) to validate visible cookies.