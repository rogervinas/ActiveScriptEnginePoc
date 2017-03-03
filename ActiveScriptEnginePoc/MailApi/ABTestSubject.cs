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

        private static Dictionary<string, ActiveScriptEngine> subjectEngines = new Dictionary<string, ActiveScriptEngine>();

        private static ActiveScriptEngine GetEngine(string scriptBody)
        {
            ActiveScriptEngine engine;
            if(!subjectEngines.ContainsKey(scriptBody)) {
               engine = new ActiveScriptEngine("JScript");
               engine.AddCode("function GetSubject(matches) { " + scriptBody + " }");
               subjectEngines.Add(scriptBody, engine);
            }else{
                engine = subjectEngines[scriptBody];
            }
            return engine;
        }

        public static string GetSubject(List<AlertProperty> properties, string scriptBody)
        {
            ActiveScriptEngine engine = GetEngine(scriptBody);
          
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
