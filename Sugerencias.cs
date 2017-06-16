using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace braferAppV2
{
    public class Sugerencias
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "Sugerencia")]
        public string sugerencia { get; set; }

        public class SugerenciasItemWrapper : Java.Lang.Object
        {
            public SugerenciasItemWrapper(Eventos item)
            {
                SugerenciasItem = item;
            }

            public Eventos SugerenciasItem { get; private set; }
        }
    }
}