﻿using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WebBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = UrlTxt.Text;
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

            Browser.Navigate(new Uri(url));
        }

        private async void Browser_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Navigation failed!!");
            await dialog.ShowAsync();
        }
    }
}
