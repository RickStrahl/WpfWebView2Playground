using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;
using Westwind.Utilities;

namespace WpfApp1
{
    public class JavaScriptInterop
    {
        private WebView2 WebView { get; }

        public JavaScriptInterop(WebView2 webView)
        {
            WebView = webView;
        }


        public string Method { get; set; }
        public object[] Parameters = { };



        public async Task<string> GetEditorContent()
        {
            var txt = await CallMethod<string>("getvalue");
            return txt;
        }

        public async Task SetEditorContent(string text)
        {
            text = text ?? string.Empty;
            await CallMethod("setvalue", text);
        }


        /// <summary>
        /// This works but - may have timing issues!
        /// </summary>
        public void InitializeInterop()
        {
            var cmd = "initializeInterop()";
            _ = WebView.CoreWebView2.ExecuteScriptAsync(cmd);
        }

        public async Task InitializeInteropAsync()
        {
            var cmd = "initializeInterop()";
            await WebView.CoreWebView2.ExecuteScriptAsync(cmd);
        }

        /// <summary>
        /// Calls a method with simple or no parameters: string, boolean, numbers
        /// </summary>
        /// <param name="method">Method to call</param>
        /// <param name="parameters">Parameters to path or none</param>
        /// <returns>object result as specified by TResult type</returns>
        public async Task<TResult> CallMethod<TResult>(string method, params object[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("textEditor." + method + "(");

            if (parameters != null)
            {
                for (var index = 0; index < parameters.Length; index++)
                {
                    object parm = parameters[index];
                    var jsonParm = JsonSerializationUtils.Serialize(parm);
                    sb.Append(jsonParm);
                    if (index < parameters.Length - 1)
                        sb.Append(",");
                }
            }
            sb.Append(")");

            var cmd = sb.ToString();
            string result = await WebView.CoreWebView2.ExecuteScriptAsync(cmd);
            
            Type resultType = typeof(TResult);
            return (TResult) JsonSerializationUtils.Deserialize(result, resultType, true);
        }

        /// <summary>
        /// Calls a method with simple parameters: String, number, boolean
        /// This version returns no results.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task CallMethod(string method, params object[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("textEditor." + method + "(");

            if (parameters != null)
            {
                for (var index = 0; index < parameters.Length; index++)
                {
                    object parm = parameters[index];
                    var jsonParm = JsonSerializationUtils.Serialize(parm);
                    sb.Append(jsonParm);
                    if (index < parameters.Length - 1)
                        sb.Append(",");
                }
            }
            sb.Append(")");

            await WebView.CoreWebView2.ExecuteScriptAsync(sb.ToString());
        }

        
        /// <summary>
        /// Calls a method on the TextEditor in JavaScript a single JSON encoded
        /// value or object. The receiving function should expect a JSON object and parse it.
        ///
        /// This version returns no result value.
        /// </summary>
        public async Task CallMethodWithJson(string method, object parameter = null)
        {
            string cmd = "textEditor." + method;

            if (parameter != null)
            {
                var jsonParm = JsonSerializationUtils.Serialize(parameter);
                cmd += "(" + jsonParm + ")";
            }

            await WebView.CoreWebView2.ExecuteScriptAsync(cmd);
        }

        /// <summary>
        /// Calls a method on the TextEditor in JavaScript a single JSON encoded
        /// value or object. The receiving function should expect a JSON object and parse it.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<object> CallMethodWithJson<TResult>(string method, object parameter = null)
        {
            string cmd = "textEditor." + method;

            if (parameter != null)
            {
                var jsonParm = JsonSerializationUtils.Serialize(parameter);
                cmd += "(" + jsonParm + ")";
            }

            string result = await WebView.CoreWebView2.ExecuteScriptAsync(cmd);


            return JsonSerializationUtils.Deserialize(result, typeof(TResult), true);
        }


    }
}