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
        public static string GetSubject(List<AlertProperty> properties, string scriptName)
        {
            using (TextReader reader = new StreamReader(@"SubjectScripts\" + scriptName))
            {
                string scriptBody = reader.ReadToEnd();
                return ABTestSubjectHelper.GetSubject(properties, scriptBody);
            }
        }

        public static void TestSubject(List<AlertProperty> properties, string scriptName, string expectedSubject)
        {
            string actualSubject = GetSubject(properties, scriptName);
            if(expectedSubject.Equals(actualSubject)) {
                Console.Out.WriteLine(String.Format("OK subject: {0}", actualSubject));
            } else {
                Console.Out.WriteLine(String.Format("KO subject: {0} | expected: {1}", actualSubject, expectedSubject));
            }
        }
    }
}
