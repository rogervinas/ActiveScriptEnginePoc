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
            using (var engine = new ActiveScriptEngine("JScript"))
            {
                engine.Start();

                dynamic script = engine.GetScriptHandle();

                object result = null;

                try
                {
                    AlertPropertyListWrapperForSubjectABTest alertProperties = new AlertPropertyListWrapperForSubjectABTest();
                    alertProperties.List = properties;

                    engine.AddCode("function GetSubject(matches) { " + scriptBody + " }");

                    result = script.GetSubject(alertProperties);

                }
                catch (COMException ex)
                {
                    var error = engine.LastError;
                    Console.Out.WriteLine("An error occurred: " + error.Description + "line: " + error.LineNumber + "source text: " + error.LineText + " exception: " + ex);
                    result = null;
                }

                return (result is string) ? (string)result : null;
            }
        }
    }
}
