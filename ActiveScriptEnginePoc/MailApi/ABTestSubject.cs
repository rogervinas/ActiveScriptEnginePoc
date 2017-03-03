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
        private static Dictionary<string, ActiveScriptEngine> engines = new Dictionary<string, ActiveScriptEngine>();

        private static ActiveScriptEngine GetEngine(string scriptBody)
        {
            ActiveScriptEngine engine;
            if(!engines.ContainsKey(scriptBody)) {
                engine = new SafeDisposableActiveScriptEngine("JScript");
                engine.Start();
                engine.AddCode("function GetSubject(matches) { " + scriptBody + " }");
                engines.Add(scriptBody, engine);
            } else {
                engine = engines[scriptBody];
            }
            return engine;
        }

        public static void ClearEngines()
        {
            engines.Clear();
        }

        public static string GetSubject(List<AlertProperty> properties, string scriptBody)
        {
            ActiveScriptEngine engine = GetEngine(scriptBody);

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

    public class SafeDisposableActiveScriptEngine : ActiveScriptEngine
    {
        public SafeDisposableActiveScriptEngine(string p) : base(p)
        {
        }

        protected override void Dispose(bool managedDispose)
        {
            if (managedDispose)
            {
                base.Dispose(managedDispose);
            }
        }
    }
}
