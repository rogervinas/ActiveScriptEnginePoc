using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailApi.Models;

namespace ActiveScriptEnginePoc
{
    class TestProperties
    {
        public static AlertProperty Property1
        {
            get
            {
                AlertProperty alertProperty = new AlertProperty();
                //alertProperty.Rooms = 3;
                alertProperty.Surface = 100;
                alertProperty.Zone = "Barcelona Capital";
                alertProperty.PropertyType = 1;
                alertProperty.PropertySubtype = 2;
                alertProperty.PropertyTypeDescription = "Vivienda";
                alertProperty.PropertySubtypeDescription = "Piso";
                return alertProperty;
            }
        }

        public static AlertProperty Property2
        {
            get
            {
                AlertProperty alertProperty = new AlertProperty();
                alertProperty.Rooms = 4;
                alertProperty.Surface = 200;
                alertProperty.Zone = "Su tia Maria";
                //alertProperty_1.PropertyType = 1;
                alertProperty.PropertySubtype = 2;
                //alertProperty_1.PropertyTypeDescription = "Vivienda";
                alertProperty.PropertySubtypeDescription = "Parking";
                return alertProperty;
            }
        }

        public static AlertProperty Property3
        {
            get {
                AlertProperty alertProperty = new AlertProperty();
                alertProperty.Rooms = 3;
                alertProperty.Surface = 100;
                alertProperty.Zone = "Barcelona Capital";
                alertProperty.PropertyType = 1;
                alertProperty.PropertySubtype = 2;
                alertProperty.PropertyTypeDescription = "Vivienda";
                alertProperty.PropertySubtypeDescription = "Piso";
                return alertProperty;
            }
        }
    }
}
