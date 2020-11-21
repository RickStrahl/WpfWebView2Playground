using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace WpfApp1
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class DotnetInterop
    {
        public string Name { get; set; } = "Rick";
        public string Company { get; set; } = "West Wind";

        public MessageItem Message { get; set; } = new MessageItem();
        public MainWindow Window {get; set; }


        public void ForwardSpecialKeyCombos(int keyCode, bool alt, bool ctrl)
        {
            string chars = null;

            if (alt)
                chars = "%";
            if (ctrl)
                chars = "^";
            if (keyCode > 0)
                chars = ((char)keyCode).ToString();

            if (string.IsNullOrEmpty(chars)) return;

            Window.Focus();
            System.Windows.Forms.SendKeys.SendWait(chars);
            Window.webView.Focus();
        }

        // var res = window.chrome.webview.hostObjects.sync.mm.HelloWorld('rick');
        // alert(res);
        public string HelloWorld(string name)
        {
            Thread.Sleep(300);
            return $"Hello World, {name}!   - Message: {Message.Message}";
        }


        public MessageItem ReturnDotnetObject()
        {
            return new MessageItem();
        }


        public string PassMessageItem(MessageItem message)
        {
            return message.Message  + " - " + message.FullName;
        }


        public string PassDynamic(object message)
        {
            dynamic msg = message as dynamic;
            var msgText = Westwind.Utilities.ReflectionUtils.GetPropertyCom(message, "Message") as string;
            var name = Westwind.Utilities.ReflectionUtils.GetPropertyCom(message, "FullName") as string;

            return msg.Message + " " + msg.FullName;
        }

        public MessageItem GetMessageItem()
        {
            return new MessageItem();
        }

    }

    

    [DebuggerDisplay("JsonCallback: {Method}")]
    public class JsonCallbackObject
    {
        public string Method { get; set; }

        public List<object> Parameters { get; } = new List<object>();
    }
}