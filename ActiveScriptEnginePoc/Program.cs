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
            List<AlertProperty> properties1 = new List<AlertProperty>();
            properties1.Add(TestProperties.Property1);
            TestSubjectScript.TestSubject(properties1, "SubjectScript1.js", "Piso 100 m2 en Barcelona Capital, ¡date prisa!");
            TestSubjectScript.TestSubject(properties1, "SubjectScript2.js", "Nuevo: Piso 100 m2 en Barcelona Capital, ¡date prisa!");

            List<AlertProperty> properties2 = new List<AlertProperty>();
            properties2.Add(TestProperties.Property2);
            properties2.Add(TestProperties.Property3);
            TestSubjectScript.TestSubject(properties2, "SubjectScript1.js", "Parking 4 hab y 200 m2 en Su tia Maria y más novedades, ¡date prisa!");
            TestSubjectScript.TestSubject(properties2, "SubjectScript2.js", "Nuevo: Parking 4 hab y 200 m2 en Su tia Maria y más novedades, ¡date prisa!");

            Console.ReadKey();
        }
    }
}
