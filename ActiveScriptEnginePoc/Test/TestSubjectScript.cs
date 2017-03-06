using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MailApi;
using MailApi.Models;

namespace ActiveScriptEnginePoc
{
    class TestSubjectScript
    {
        public static string GetScript(string scriptName)
        {
            using (TextReader reader = new StreamReader(@"SubjectScripts\" + scriptName))
            {
                return reader.ReadToEnd();
            }
        }

        public static void TestSubject(List<AlertProperty> properties, string script, string expectedSubject, bool silent = false)
        {
            string actualSubject = ABTestSubjectHelper.GetSubject(properties, script);
            if(expectedSubject.Equals(actualSubject)) {
                if(!silent) Console.Out.WriteLine(String.Format("OK subject: {0}", actualSubject));
            } else {
                if (!silent) Console.Out.WriteLine(String.Format("KO subject: {0} | expected: {1}", actualSubject, expectedSubject));
            }
        }
    }
}
