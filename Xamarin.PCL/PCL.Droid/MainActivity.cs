using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace PCL.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText usuario, password;
        Button iniciarSesion;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            usuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            iniciarSesion = FindViewById<Button>(Resource.Id.btnInciar);

            iniciarSesion.Click += IniciarSesion_Click;
        }

        private void IniciarSesion_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(usuario.Text)||string.IsNullOrEmpty(password.Text))
            {
                Toast.MakeText(this, "Ingrese Datos", ToastLength.Short).Show();
            }
            else
            {
                Intent intent = new Intent(this, typeof(ListaViajesActivity));
                StartActivity(intent);
            }
        }
    }
}