using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace MailApi.Models
{
    [ComVisible(true)]
    public class AlertProperty
    {
        public long PropertyId { get; set; }

        public int TransactionId { get; set; }

        public string TransactionDescription { get; set; }

        public string ImageMainUrl { get; set; }

        public string PropertyUrl { get; set; }

        public int Rooms { get; set; }

        public int BathRooms { get; set; }

        public int Surface { get; set; }

        public decimal Price { get; set; }

        public string Zone { get; set; }

        public string City { get; set; }

        public int PropertyType { get; set; }

        public string PropertyTypeDescription { get; set; }

        public int PropertySubtype { get; set; }

        public string PropertySubtypeDescription { get; set; }
    }
}