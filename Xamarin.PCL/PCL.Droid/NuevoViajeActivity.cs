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
    [Activity(Label = "NuevoViajeActivity")]
    public class NuevoViajeActivity : Activity
    {
        EditText nombreCiudad;
        DatePicker fechaInicio, fechaFin;
        Button GuardarViaje;

        static readonly string nombreDB = "viajes.sqlite";
        static readonly string rutaDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        readonly string rutaComplete = Path.Combine(rutaDB, nombreDB);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ViajesInsertarLayout);

            nombreCiudad = FindViewById<EditText>(Resource.Id.txtNombreCiudad);
            fechaInicio = FindViewById<DatePicker>(Resource.Id.dtpInicio);
            fechaFin = FindViewById<DatePicker>(Resource.Id.dtpFin);
            GuardarViaje = FindViewById<Button>(Resource.Id.btnGuardarViaje);

            GuardarViaje.Click += GuardarViaje_Click;
        }

        private void GuardarViaje_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nombreCiudad.Text))
            {
                Toast.MakeText(this, "Ingresa Datos", ToastLength.Short).Show();
            }
            else
            {
                var viaje = new Viaje()
                {
                    Nombre = nombreCiudad.Text,
                    FechaInicio = fechaInicio.DateTime.Date,
                    FechaFin = fechaFin.DateTime.Date
                };
                var result = DatabaseHelper.Insertar(ref viaje, rutaComplete);
                if (result)
                {
                    Toast.MakeText(this, "Dato Guardado", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Error, Intente de nuevo", ToastLength.Short).Show();
                }
            }
        }
    }
}