using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveXScriptLib;
using MailApi.Models;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ActiveScriptEnginePoc
{
    class Program
    {
        static void Main(string[] args)
        {
            string subjectScript1 = TestSubjectScript.GetScript("SubjectScript1.js");
            string subjectScript2 = TestSubjectScript.GetScript("SubjectScript2.js");

            List<AlertProperty> properties1 = new List<AlertProperty>();
            properties1.Add(TestProperties.Property1);
            TestSubjectScript.TestSubject(properties1, subjectScript1, "Nuevo: Piso 100 m2 en Barcelona Capital, ¡date prisa!");
            TestSubjectScript.TestSubject(properties1, subjectScript2, "Nuevo: Piso 100 m2 en Barcelona Capital, ¡date prisa!");

            List<AlertProperty> properties2 = new List<AlertProperty>();
            properties2.Add(TestProperties.Property2);
            properties2.Add(TestProperties.Property3);
            TestSubjectScript.TestSubject(properties2, subjectScript1, "Nuevo: Parking 4 hab y 200 m2 en Su tia Maria y más novedades, ¡date prisa!");
            TestSubjectScript.TestSubject(properties2, subjectScript2, "Nuevo: Parking 4 hab y 200 m2 en Su tia Maria y más novedades, ¡date prisa!");

            int count = 10000;
            Console.Out.WriteLine(String.Format("Testing {0} executions ...", count));
            var sw = Stopwatch.StartNew();
            for (int i = 1; i < count; i++)
            {
                TestSubjectScript.TestSubject(properties1, subjectScript1, "Piso 100 m2 en Barcelona Capital, ¡date prisa!", true);
            }
            Console.Out.WriteLine(
                String.Format("{0} executions in {1} ms => 1 execution / {2} ms",
                count, sw.ElapsedMilliseconds, 1.0 * sw.ElapsedMilliseconds / count
            ));

            Console.ReadKey();
        }
    }
}
