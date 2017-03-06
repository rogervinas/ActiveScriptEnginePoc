using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailApi.Models;
using ActiveXScriptLib;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MailApi
{
    public class ABTestSubjectHelper
    {
        public static string GetSubject(List<AlertProperty> properties, string scriptBody)
        {
            object result = null;
            using (ActiveScriptEngine engine = new ActiveScriptEngine("JScript"))
            {
                try 
                {
                    AlertPropertyListWrapperForSubjectABTest alertProperties = new AlertPropertyListWrapperForSubjectABTest();
                    alertProperties.List = properties;
                    engine.AddCode("function GetSubject(matches) { " + scriptBody + " }");
                    engine.Start();
                    dynamic script = engine.GetScriptHandle();
                    result = script.GetSubject(alertProperties);
                } catch(Exception ex) {
                    string errorMsg = "GetSubject: unknown error executing javascript";
                    if (engine.LastError != null)
                    {
                        errorMsg = String.Format(
                            "GetSubject: error executing javascript lineNumber={0} line={1}",
                            engine.LastError.LineNumber, engine.LastError.LineText
                        );
                    }
                    Console.Out.WriteLine(errorMsg, ex);
                    result = null;
                }
            }
            return (result is string) ? (string)result : null;
        }
    }
}