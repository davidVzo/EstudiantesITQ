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
    public partial class EditarEstudiantes : ContentPage
    {
        private const string Url = "http://192.168.56.1/itq/post.php?codigo={0}&nombre={1}&apellido={2}&correo={3}&telefono={4}";
        public EditarEstudiantes(int codigo, string nombre, string apellido, string correo, string telefono)
        {
            InitializeComponent();
            
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text= nombre.ToString();
            txtApellido.Text= apellido.ToString();
            txtCorreo.Text= correo.ToString();
            txtTelefono.Text= telefono.ToString(); 
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            try
            {
                using (var webClient = new WebClient())
                {
                    var uri = new Uri(string.Format(Url,
                        txtCodigo.Text, txtNombre.Text,txtApellido.Text,txtCorreo.Text,txtTelefono.Text));

                    webClient.UploadString(uri, "PUT", string.Empty);
                    DisplayAlert("Succes","Registro de "+txtNombre.Text+" "+txtApellido.Text+" Actualizado correctamente "," cerrar");
                    await Navigation.PushAsync(new ListadoEstudiantes());
                }
            }
            catch (Exception ex )
            {
                DisplayAlert("Alerta ",ex.Message," Cerrar");
                
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoEstudiantes());
        }
    }
}