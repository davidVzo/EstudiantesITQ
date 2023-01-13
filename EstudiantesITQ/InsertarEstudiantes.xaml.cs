using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstudiantesITQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarEstudiantes : ContentPage
    {
        private const string Url = "http://192.168.56.1/itq/post.php";
        public InsertarEstudiantes()
        {
            InitializeComponent();
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            try
            {
                var parameters = new System.Collections.Specialized.NameValueCollection();
                parameters.Add("codigo", txtCodigo.Text);
                parameters.Add("nombre", txtNombre.Text);
                parameters.Add("apellido", txtApellido.Text);
                parameters.Add("correo", txtCorreo.Text);
                parameters.Add("telefono", txtTelefono.Text);
                cliente.UploadValues(Url, "POST", parameters);
                await Navigation.PushAsync(new ListadoEstudiantes());
                //DisplayAlert("Sucess", "Registro Ingresado del Usuario: " + txtNombre.Text + " " + txtApellido.Text, " Cerrar ");
                Limpiar();


            }
            catch (Exception ex)
            {
                //DisplayAlert("Alerta ", ex.Message, " Cancelar ");
                //mostrar errores en consola
                Console.WriteLine(ex.Message);
            }

        }

        public void Limpiar()
        {
            //calidad de software para limpiar las variables 
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtCodigo.Text = String.Empty;
            txtCorreo.Text = String.Empty;
            txtTelefono.Text = String.Empty;

        }

        async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoEstudiantes());
        }
    }
}