namespace jcaillaguaTaller03.Views;

public partial class vResumen : ContentPage
{
	public vResumen()
	{
		InitializeComponent();
	}

    public vResumen(string tipoIdR, string identificacionR, string nombreR, string apellidoR, string fechaR, string correoR, string salarioR, string aporteIessR)
    {
        InitializeComponent();
        string tipoId = tipoIdR;
        string identificacion = identificacionR;
        string nombre = nombreR;
		string apellido = apellidoR;
		string fecha = fechaR;
		string correo = correoR;
		string salario = salarioR;
		string aporteIess = aporteIessR;

        lblTipoIdentificacion.Text = tipoId;
        lblIdentificacion.Text = identificacion;
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lbalFecha.Text = fecha;
        lblCorreo.Text = correo;
        lblSalario.Text = salario;
        lblAportacion.Text = aporteIess;
    }

    private async void btnExportar_Clicked(object sender, EventArgs e)
    {


        string salida = $" Datos para de EMPLEADO:\n\n" +
                             $"Tipo Identificación: {lblTipoIdentificacion}\n" +
                             $"Número: {lblIdentificacion}\n" +
                             $"Apellidos: {lblApellido.Text}\n" +
                             $"Nombres: {lblNombre}\n" +
                             $"Correo: {lblCorreo}\n" +
                             $"Salario: {lblSalario}\n" +
                             $"Aportacion al IESS: {lblAportacion}\n";

        string fileName = $"Registro_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
        try
        {
            File.WriteAllText(filePath, salida);
            await DisplayAlert("Éxito", $"Datos enviado correctamente.\nArchivo guardado:\n{filePath}", "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar el archivo.\n{ex.Message}", "Aceptar");
            return;
        }
    }
}