using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace WpfApp1
{

    /// <summary>
    /// Object that gets called from JavaScript
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class DotnetInterop
    {

        public JavaScriptInterop JsInterop {get; }

        public string Name { get; set; } = "Rick";
        public string Company { get; set; } = "West Wind";

        public MessageItem Message { get; set; } = new MessageItem();
        public MainWindow Window {get; set; }


        public DotnetInterop(MainWindow mainWindow, JavaScriptInterop jsInterop)
        {
            JsInterop = jsInterop;
            Window = mainWindow;
        }

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

        public async void KeyboardCommand(string command, string action)
        {
            string html = null;

            try
            { 
                html = await JsInterop.CallMethod<string>("getselection") as string;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            action = action.ToLower();

            if (action == "bold")
            {
                html = WrapValue(html, "**", "**", stripExtraSpaces: true);
            }
            else if (action == "italic")
            {
                var italic = "*";
                html = WrapValue(html, italic, italic, stripExtraSpaces: true);
            }

            await JsInterop.CallMethod("setselection", html);
        }

        /// <summary>
        /// Wraps a string with beginning and ending delimiters.
        /// Fixes up accidental leading and trailing spaces.
        /// </summary>
        /// <param name="input">string to wrap</param>
        /// <param name="delim1">start delimiter</param>
        /// <param name="delim2">end delimiter</param>
        /// <param name="stripExtraSpaces">strips 'extra' spaces or more than one and leaves only one</param>
        /// <returns></returns>
        public string WrapValue(string input, string delim1, string delim2, bool stripExtraSpaces = true)
        {
            if (!stripExtraSpaces)
                return delim1 + input + delim2;

            if (input.StartsWith(" "))
                input = " " + delim1 + input.TrimStart();
            else
                input = delim1 + input;

            if (input.EndsWith(" "))
                input = input.TrimEnd() + delim2 + " ";
            else
                input += delim2;

            return input;
        }
    }

    

    [DebuggerDisplay("JsonCallback: {Method}")]
    public class JsonCallbackObject
    {
        public string Method { get; set; }

        public List<object> Parameters { get; } = new List<object>();
    }
}