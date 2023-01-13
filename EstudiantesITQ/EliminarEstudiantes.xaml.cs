using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstudiantesITQ
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EliminarEstudiantes : ContentPage
    {
        private const string Url = "http://192.168.56.1/itq/post.php?codigo={0}";
        public EliminarEstudiantes()
        {
            InitializeComponent();
        }

        private async void btnEliminarEstudiante_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri( string.Format(Url,txtcodigo.Text));
                var result = await client.DeleteAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    await DisplayAlert("succesfully", " El dato ha sido borrado ", " okey ");
                    await Navigation.PushAsync(new ListadoEstudiantes());
                }
                else {
                    await DisplayAlert("Error", "Estudiante de código " + txtcodigo.Text , " cancelar" );
                }


            }
            catch (Exception ex)
            {
                //DisplayAlert("Alerta ", ex.Message, " Cancelar ");
                //mostrar errores en consola
                Console.WriteLine(ex.Message);
            }

        }
    }
}