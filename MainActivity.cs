using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Net;
using Android.Content.PM;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;

namespace braferAppV2
{
    [Activity(Label = "braferAppV2", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private MobileServiceClient client;
        Button button;
        EditText usr;
        EditText pass;
        const string applicationURL = @"https://xamfinapp.azurewebsites.net";
        private IMobileServiceTable<Usuarios> usuariosTable;
        private IMobileServiceTable<Eventos> eventosTable;
        List<Eventos> lsEventos = new List<Eventos>();
        string[] eventos;

        int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            client = new MobileServiceClient(applicationURL);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);
            usr = FindViewById<EditText>(Resource.Id.txtUsuario);
            pass = FindViewById<EditText>(Resource.Id.txtPass);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                usuariosTable = client.GetTable<Usuarios>();
                var user = await usuariosTable.Where(usuario => usuario.NomUsuario == usr.Text && usuario.Password == pass.Text).ToListAsync();

                foreach (Usuarios current in user)
                {
                    count++;
                }

                if (count == 0)
                {
                    Toast.MakeText(this, "Usuario ó Contraseña Erronea", ToastLength.Short).Show();
                }
                else
                {
                    StartActivity(typeof(ListaEveActivity));
                }
            }
            else
            {
                Toast.MakeText(this, "No hay conexión a internet", ToastLength.Short).Show();
            }
        }

        private async void getEventos()
        {
            eventosTable = client.GetTable<Eventos>();
            lsEventos = await eventosTable.Where(evento => 1 == 1).ToListAsync();

            foreach (Eventos item in lsEventos)
            {
                eventos.Append(item.NombreEvento);
            }
        }
    }
}

