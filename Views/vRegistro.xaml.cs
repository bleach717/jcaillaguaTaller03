namespace jcaillaguaTaller03.Views;
using System.Text.RegularExpressions;
public partial class vRegistro : ContentPage
{
	public vRegistro()
	{
		InitializeComponent();
	}

    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {
        // Valida que todos los datos este n llenos
        if (pkIdentificacion.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtSalario.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
            return;
        }

        //Validar que en nombre y apellido sean solo letras
        if (!Regex.IsMatch(txtNombres.Text, @"^[A-Za-z¡…Õ”⁄·ÈÌÛ˙—Ò\s]+$") ||
               !Regex.IsMatch(txtApellidos.Text, @"^[A-Za-z¡…Õ”⁄·ÈÌÛ˙—Ò\s]+$"))
        {
            await DisplayAlert("Error", "Nombres y apellidos solo deben contener letras.", "Aceptar");
            return;
        }

        //Valida que sea Correo Electronico
        if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Error", "Ingrese un correo electrÛnico v·lido.", "Aceptar");
            return;
        }


        //validacion de identificacion 
        string tipo = pkIdentificacion.SelectedItem.ToString();
        string id = txtIdentificacion.Text.Trim();

        if (tipo == "Cedula")
        {
            if (!Regex.IsMatch(id, @"^\d{10}$"))
            {
                await DisplayAlert("Error", "La cÈdula debe tener exactamente 10 dÌgitos numÈricos.", "Aceptar");
                return;
            }
        }
        else if (tipo == "RUC")
        {
            if (!Regex.IsMatch(id, @"^\d{13}$"))
            {
                await DisplayAlert("Error", "El RUC debe tener exactamente 13 dÌgitos numÈricos.", "Aceptar");
                return;
            }
        }
        else if (tipo == "Pasaporte")
        {
            if (id.Length < 3)
            {
                await DisplayAlert("Error", "El pasaporte no puede estar vacÌo.", "Aceptar");
                return;
            }

        }

        // Valida que salario se numerico
        if (!decimal.TryParse(txtSalario.Text, out _))
        {
            await DisplayAlert("Error", "El salario debe ser un n˙mero v·lido.", "Aceptar");
            return;
        }

        double salariobase = Convert.ToDouble(txtSalario.Text);

        double aporte = salariobase * (0.0945);

        string tipoIdentificacion = pkIdentificacion.SelectedItem.ToString();
        string identificacion = txtIdentificacion.Text;
        string nombre = txtNombres.Text;
        string apellido= txtApellidos.Text;
        string fecha = dtpFecha.Date.ToString();
        string correo = txtCorreo.Text;
        string salario = txtSalario.Text;
        string aporteIess = aporte.ToString("F2");

        await DisplayAlert("Datos ingresados correctamente", "", "Continuar");
        await Navigation.PushAsync(new vResumen(tipoIdentificacion,identificacion,nombre,apellido,fecha,correo,salario,aporteIess));
    }
}