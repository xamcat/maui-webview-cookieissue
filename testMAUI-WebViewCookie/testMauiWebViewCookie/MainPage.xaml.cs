using System.Net;

namespace testMauiWebViewCookie;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        const string url = "https://cookie-sharing-app.azurewebsites.net";
        const string domain = ".cookie-sharing-app.azurewebsites.net";
        const string path = "/";
        const string cookieName = "Cookie2";
        const string cookieVal = "CookieVal2";

        var cookieContainer = new CookieContainer();
        Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);

        Cookie cookie = new Cookie
        {
            Name = cookieName,
            Expires = DateTime.Now.AddDays(1),
            Value = cookieVal,
            Domain = domain, //uri.Host, both don't work
            Path = path
        };
        cookieContainer.Add(uri, cookie);
        this.webView.Cookies = cookieContainer;
        this.webView.Source = new UrlWebViewSource { Url = uri.ToString() };
    }
}

