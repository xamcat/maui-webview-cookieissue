using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace testWebView2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var webView2 = new WebView2();
            webView2.Source = new Uri("https://cookie-sharing-app.azurewebsites.net");
            this.Content = webView2;
            webView2.CoreWebView2Initialized += (s, e) => InitWebView2((WebView2)s);
        }

        public async Task InitWebView2(WebView2 webView2)
        {
            const string uri = "https://cookie-sharing-app.azurewebsites.net";
            const string domain = ".cookie-sharing-app.azurewebsites.net";
            const string path = "/";
            const string cookieName = "Cookie1";
            const string cookieVal = "CookieVal1";
            var newCookie = webView2.CoreWebView2.CookieManager.CreateCookie(cookieName, cookieVal, domain, path);
            webView2.CoreWebView2.CookieManager.AddOrUpdateCookie(newCookie);
            var cookies = await webView2.CoreWebView2.CookieManager.GetCookiesAsync(uri);
            Debug.WriteLine($"Found {cookies.Count} cookies after creating the new one!");
        }
    }
}
