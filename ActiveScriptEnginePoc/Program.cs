using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveXScriptLib;
using System.Runtime.InteropServices;

namespace ActiveScriptEnginePoc
{
    [ComVisible(true)]
    public class People
    {
        public List<Person> List { get; set; }

        public Person Get(int i)
        {
            return List[i];
        }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }
    }

    [ComVisible(true)]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var engine = new ActiveScriptEngine("JScript"))
            {
                engine.Start();

                dynamic script = engine.GetScriptHandle();

                try
                {
                    People people = new People();

                    Person anna = new Person()
                    {
                        FirstName = "Anna",
                        LastName = "Rodriguez"
                    };
                    Person brad = new Person()
                    {
                        FirstName = "Brad",
                        LastName = "Pitt"
                    };

                    people.List = new List<Person>();
                    people.List.Add(anna);
                    people.List.Add(brad);

                    engine.AddCode("function myfunc(x) { return 'hola ' + x.Get(1).FirstName; }");

                    var result = script.myfunc(people);

                    Console.WriteLine(result);
                }
                catch (COMException)
                {
                    var error = engine.LastError;
                    Console.WriteLine("An error occurred: " + error.Description);
                    Console.WriteLine("Line number: " + error.LineNumber);
                    Console.WriteLine("Error source text: " + error.LineText);
                }

                Console.ReadLine();
            }

        }
    }
}
