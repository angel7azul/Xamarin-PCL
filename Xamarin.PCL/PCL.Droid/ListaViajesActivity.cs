using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CL_Acceso.Clases;

namespace PCL.Droid
{
    [Activity(Label = "ListaViajesActivity")]
    public class ListaViajesActivity : Activity
    {
        Toolbar toolbarMenu;
        ListView viajes;
        List<Viaje> dataViajes;
        static readonly string nombreDB = "viajes.sqlite";
        static readonly string rutaDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        readonly string rutaComplete = Path.Combine(rutaDB, nombreDB);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ListaViajesLayout);

            viajes = FindViewById<ListView>(Resource.Id.listaViajes);
            toolbarMenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            SetActionBar(toolbarMenu);
            ActionBar.Title = "Menu";

            try
            {
                dataViajes = DatabaseHelper.LeerDatos(rutaComplete);
                ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, dataViajes);
                viajes.Adapter = adapter;
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Ingrese Datos", ToastLength.Short).Show();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icAdd:
                    Intent intent = new Intent(this, typeof(NuevoViajeActivity));
                    StartActivity(intent);
                    break;
                case Resource.Id.icDelete:
                    Toast.MakeText(this, "Icono Eliminar", ToastLength.Short).Show();
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            dataViajes = DatabaseHelper.LeerDatos(rutaComplete);
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, dataViajes);
            viajes.Adapter = adapter;
        }
    }
}