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
    public class Usuarios
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "NomUsuario")]
        public string NomUsuario { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        public class UsuariosItemWrapper : Java.Lang.Object
        {
            public UsuariosItemWrapper(Usuarios item)
            {
                UsuariosItem = item;
            }

            public Usuarios UsuariosItem { get; private set; }
        }
    }
}