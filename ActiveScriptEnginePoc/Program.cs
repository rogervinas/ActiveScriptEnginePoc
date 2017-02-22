using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveXScriptLib;
using MailApi.Models;
using System.Runtime.InteropServices;

namespace ActiveScriptEnginePoc
{

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
                    AlertPropertyListWrapperForSubjectABTest alertProperties = generateAlertProperties_1();

                    String jsFunctionBodyFromKey = generateJsFunction();

                    engine.AddCode("function myfunc(matches) { "+jsFunctionBodyFromKey+" }");

                    var result = script.myfunc(alertProperties);

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

        private static String generateJsFunction()
        {
            String function = 
                "var base='[PropertySubtype/PropertyTypeDescription] [Rooms] hab y [Surface] m2 en [Zone]';"
	            + "var endSingle=', ¡date prisa!';"
                + "var endMultiple=' y más novedades, ¡date prisa!';"
                + "var subject;"
                + "var propertyTypeDescription = matches.Get(0).PropertyTypeDescription;"
                + "if (matches.Get(0).PropertySubtype > 0){"
		        + "propertyTypeDescription=matches.Get(0).PropertySubtypeDescription;"
	            + "}"
  			    + "subject=base.replace('[PropertySubtype/PropertyTypeDescription]',propertyTypeDescription);"
                + "if(matches.Get(0).Rooms>0){"
	            + "subject=subject.replace('[Rooms]',matches.Get(0).Rooms);"
                + "}else{"
	            + "subject=subject.replace(' [Rooms] hab y','');"	
                + "}"
                + "if(matches.Get(0).Surface>0){"
	            + "subject=subject.replace('[Surface]',matches.Get(0).Surface);"
                + "}else{"
	            + "if(matches.Get(0).Rooms>0){"
		        + "subject=subject.replace(' y [Surface] m2','');"
                + "}else{"
  	            + "subject=subject.replace(' [Surface] m2','');"
                + "}"
                + "}"
                + "subject=subject.replace('[Zone]',matches.Get(0).Zone);"
                + "if(matches.Count() > 1){"
  	            + "subject=subject+endMultiple;"
	            + "}else{"
  	            + "subject=subject+endSingle;"
                + "}"
                + "return subject;";

            return function;
        }

        private static AlertPropertyListWrapperForSubjectABTest generateAlertProperties_1()
        {
            AlertPropertyListWrapperForSubjectABTest alertProperties = new AlertPropertyListWrapperForSubjectABTest();
            AlertProperty alertProperty = new AlertProperty();
            //alertProperty.Rooms = 3;
            alertProperty.Surface = 100;
            alertProperty.Zone = "Barcelona Capital";
            alertProperty.PropertyType = 1;
            alertProperty.PropertySubtype = 2;
            alertProperty.PropertyTypeDescription = "Vivienda";
            alertProperty.PropertySubtypeDescription = "Piso";
            alertProperties.List = new List<AlertProperty>();
            alertProperties.List.Add(alertProperty);
            return alertProperties;
        }


        private static AlertPropertyListWrapperForSubjectABTest generateAlertProperties_2()
        {
            AlertPropertyListWrapperForSubjectABTest alertProperties = new AlertPropertyListWrapperForSubjectABTest();
            AlertProperty alertProperty_1 = new AlertProperty();
            alertProperty_1.Rooms = 4;
            alertProperty_1.Surface = 200;
            alertProperty_1.Zone = "Su tia Maria";
            //alertProperty_1.PropertyType = 1;
            alertProperty_1.PropertySubtype = 2;
            //alertProperty_1.PropertyTypeDescription = "Vivienda";
            alertProperty_1.PropertySubtypeDescription = "Parking";

            AlertProperty alertProperty_2 = new AlertProperty();
            alertProperty_2.Rooms = 3;
            alertProperty_2.Surface = 100;
            alertProperty_2.Zone = "Barcelona Capital";
            alertProperty_2.PropertyType = 1;
            alertProperty_2.PropertySubtype = 2;
            alertProperty_2.PropertyTypeDescription = "Vivienda";
            alertProperty_2.PropertySubtypeDescription = "Piso";

            alertProperties.List = new List<AlertProperty>();
            alertProperties.List.Add(alertProperty_1);
            alertProperties.List.Add(alertProperty_2);
            return alertProperties;

        }
    }
}
