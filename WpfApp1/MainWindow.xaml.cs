using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Westwind.Utilities;
using WpfApp1;
using Path = System.Windows.Shapes.Path;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public DotnetInterop Interop = new DotnetInterop();

        public MainWindowModel Model {get; set; }= new MainWindowModel();

        public bool firstload = true;

        public MainWindow()
        {
            InitializeComponent();

            Interop.Window = this;

            webView.Visibility = Visibility.Hidden;

            DataContext = Model;
            Loaded += MainWindow_Loaded;
            
            InitializeAsync();
            

            webView.NavigationCompleted += WebView_NavigationCompleted;
            
            webView.Loaded += WebView_Loaded;
            webView.Unloaded += (s,a) => webView.Visibility = Visibility.Hidden;
        }

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
        }



        private void WebView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
          
            if (e.IsSuccess)
                Model.Url = webView.Source.ToString();

            if (firstload)
            {
                firstload = false;
                webView.Visibility = Visibility.Visible;
            }

        }

        
        async void InitializeAsync()
        {
            // must create a data folder if running out of a secured folder that can't write like Program Files
            var env = await  CoreWebView2Environment.CreateAsync(userDataFolder: System.IO.Path.Combine(System.IO.Path.GetTempPath(),"MarkdownMonster_Browser"));
            await webView.EnsureCoreWebView2Async(env);

            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
            
            webView.CoreWebView2.AddHostObjectToScript("mm", Interop);
        }

        private void CoreWebView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            var text = e.TryGetWebMessageAsString();

            var callbackJson = JsonSerializationUtils.Deserialize(text, typeof(JsonCallbackObject)) as JsonCallbackObject;

            if (callbackJson.Method == "showMessage")
            {
                MessageBox.Show(callbackJson.Parameters[0] + "\r\n" + text, "WPF Window");
            }


        }

        

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //webView.Source = new Uri(Model.Url);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //webView.CoreWebView2.ExecuteScriptAsync("textEditor.setvalue('# Hello World')");


            var txt = @"# New Markdown text

This is 'left' for dead, this is ""Left for real"", 
and this is **bold**.

* Line 1
* Line 2
";
            var jsInterop = new JavaScriptInterop(webView);
            jsInterop.CallMethod("setvalue", txt);

            
            //jsInterop.CallMethod("openSearchAndReplace", "dead", "wet");

            jsInterop.CallMethod("setCursorPosition", 3, 10);


            jsInterop.CallMethod("setselection", "Better Dead than bled");

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.ExecuteScriptAsync("testCallback('# Hello World')");
            //webView.CoreWebView2.ExecuteScriptAsync("mm.Name = 'rick'");

            //webView.CoreWebView2.ExecuteScriptAsync("mm.HelloWorld('Rick')");
        }


        private void btnNav_Click(object sender, RoutedEventArgs e)
        {
            webView.Source = new Uri(txtUrl.Text);
        }

        private void txtUrl_LostFocus(object sender, RoutedEventArgs e)
        {
            webView.Source = new Uri(txtUrl.Text);
        }

        private void webView_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {
            Debug.WriteLine(e.Key.ToString());
        }

        private void btnSendKey_Click(object sender, RoutedEventArgs e)
        {
            Interop.ForwardSpecialKeyCombos(-1, true, false);  // alt
            Interop.ForwardSpecialKeyCombos(78, true, false);  // n
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MessageItem
    {
        public string FullName { get; set; } = "Rick";
        public string Message { get; set; } = "Message set in .NET";

    }


    public class MainWindowModel : INotifyPropertyChanged
    {

        public string Url
        {
            get { return _Url; }
            set
            {
                if (value == _Url) return;
                _Url = value;
                OnPropertyChanged(nameof(Url));
            }
        }

        private string _Url = @"C:\Users\rstrahl\source\repos\WpfApp2\WpfApp1\bin\Debug\net472\Editor\editor.htm";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
