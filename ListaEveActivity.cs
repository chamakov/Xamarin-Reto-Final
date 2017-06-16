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
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace braferAppV2
{
    [Activity(Label = "ListaEveActivity")]
    public class ListaEveActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://xamfinapp.azurewebsites.net";
        private IMobileServiceTable<Sugerencias> sugerenciaTable;
        List<Eventos> lsEventos = new List<Eventos>();
        Button enviar;
        TextView txt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.layout1);

            client = new MobileServiceClient(applicationURL);
            enviar = FindViewById<Button>(Resource.Id.btnEnviar);
            txt = FindViewById<TextView>(Resource.Id.txtSugerencias);
            enviar.Click += Enviar_Click;
        }

        private async void Enviar_Click(object sender, EventArgs e)
        {
           Sugerencias sug = new Sugerencias();
           sug.sugerencia = txt.Text;
            sugerenciaTable = client.GetTable<Sugerencias>();
            try
            {
                await sugerenciaTable.InsertAsync(sug);
                Toast.MakeText(this, "Gracias por tus sugerencias, pronto nos pondremos en contacto contigo", ToastLength.Long).Show();
                txt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); ;
            }
        }
    }
}