using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;
using Westwind.Utilities;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DotnetInterop Interop;

        public JavaScriptInterop JsInterop;
        
        public MainWindowModel Model {get; set; }= new MainWindowModel();

        public bool firstload = true;

        public MainWindow()
        {
            InitializeComponent();

            JsInterop = new JavaScriptInterop(webView);
            Interop = new DotnetInterop(this, JsInterop);

            // renders in a generic background color - so hide it
            webView.Visibility = Visibility.Hidden;

            DataContext = Model;
            Loaded += MainWindow_Loaded;
            
            InitializeAsync();
            

            webView.NavigationCompleted += WebView_NavigationCompleted;
            webView.Unloaded += (s,a) => webView.Visibility = Visibility.Hidden;
            webView.ContentLoading += WebView_ContentLoading;
            
            // Using a file URL
            //webView.Source = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "Editor/editor.htm"));

            // Using a Mapped virtual url set with CoreWebView2.SetVirtualHostNameToFolderMapping
            webView.Source = new Uri("https://test.editor/editor.htm");
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



            // Map a folder from the Executable Folder to a virtual domain
            // https://test.editor/Editor.html 
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "test.editor", "Editor",
                    CoreWebView2HostResourceAccessKind.Allow);

            webView.CoreWebView2.OpenDevToolsWindow();

            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
            
            webView.CoreWebView2.AddHostObjectToScript("mm", Interop);

            JsInterop.InitializeInterop();
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


        private async void HelloWorld_Click(object sender, RoutedEventArgs e)
        {
            // Simplest thing you can do - execute script on global scope
            await webView.ExecuteScriptAsync($"window.alert('Hello from .NET. Time is: {DateTime.Now.ToString("HH:mm:ss")}.')");
        }

        
        private async void HelloWorldFromJavaScript_Click(object sender, RoutedEventArgs e)
        {
            await webView.ExecuteScriptAsync($"callHelloWorldDotnet('Mr. JavaScript')");
        }


        private async void GetContent_Click(object sender, RoutedEventArgs e)
        {

            var cmd = "textEditor.getvalue()";
            var json = await webView.ExecuteScriptAsync(cmd);
            var markdown = JsonSerializationUtils.Deserialize<string>(json);

            //var markdown = await JsInterop.CallMethod<string>("getvalue");

            MessageBox.Show(this, markdown, "Editor Content", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private async void SetContent_Click(object sender, RoutedEventArgs e)
        {
            var markdown = @"# New Markdown text

This text is inserted from .NET into this document.
and this is **bold**.

Quotes: double - "" and single '

* Line 1
* Line 2    
";


            var cmd = "textEditor.setvalue(" + JsonSerializationUtils.Serialize(markdown) + ")";
            webView.CoreWebView2.ExecuteScriptAsync(cmd);
            return;

            //webView.CoreWebView2.ExecuteScriptAsync("textEditor.setvalue('# Hello World')");

            var jsInterop = new JavaScriptInterop(webView);
            await jsInterop.CallMethod("setvalue", markdown);
            
            //jsInterop.CallMethod("openSearchAndReplace", "dead", "wet");

            await jsInterop.CallMethod("setCursorPosition", 3, 22);

            await Task.Delay(3000);

            await jsInterop.CallMethod("setselection", "-- inserted from .NET at " + DateTime.Now.ToString("t") + " -- ");
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
            Debug.WriteLine("AccessKeyPressed: "  + e.Key.ToString());
        }

        private void btnSendKey_Click(object sender, RoutedEventArgs e)
        {
            Interop.ForwardSpecialKeyCombos(-1, true, false);  // alt
            Interop.ForwardSpecialKeyCombos(78, true, false);  // n
        }

        private void webView_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("KeyDown: "  + e.Key.ToString());
        }

        private void webView_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("KeyUp: "  + e.Key.ToString());
        }

      

        private void NavigateToString_Click(object sender, RoutedEventArgs e)
        {


            // To map related content use webView.CoreWebView2.SetVirtualHostNameToFolderMapping()
            // to map a domain name to a path that's part of the installation folder.
            webView.NavigateToString(@"
<html>
	<head>
	    <link rel=""stylesheet""
              href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"">
    </head>
               

<h1>String Navigation</h1>


<img src=""https://markdownmonster.west-wind.com/Images/MarkdownMonsterLogo.jpg""
     style='max-width: 100%' />	

<!-- Relative Path to Editor Folder virtual Mapping -->
<img src=""https://test.editor/fileicons/csharp.png"" />

<p>
This content generated to display as a string.
</p>
<p>
This works only if you have self-contained content, or you link Web Resources or you explicitly implement
</p>
");
        }

        private void WebView_ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
        {
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
        private string _Url = "about:blank"; //@"C:\Users\rstrahl\source\repos\WpfApp2\WpfApp1\bin\Debug\net472\Editor\editor.htm";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
