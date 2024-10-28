using My_FrmInicio;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmAgregar : Form
    {
        private string rutaArchivo = "C:\\Users\\jjaim\\source\\repos\\WinFormsApp1\\WinFormsApp1\\STPMG.json";

        public FrmAgregar()
        {
            InitializeComponent();
        }


        private void Btn_AgregarEstacion_Click(object sender, EventArgs e)
        {
            //Obtener datos de los TextBox
            string nombreEstacion = TextB_Nombre.Text.Trim();
            string lineaEstacion = TextB_Linea.Text.Trim();
            string extraCadena = TextB_Cadena.Text.Trim();
            int extraNumerico = int.TryParse(TextB__Numerico.Text, out int num) ? num : 0;

            // Leer y deserializar el archivo JSON
            EstacionesWrapper wrapper = LeerArchivoJson(rutaArchivo);

            if (wrapper != null)
            {
                //Verificar si la estacion ya existe
                bool estacionExiste = wrapper.Estaciones.Any(e => e.Nombre.Equals(nombreEstacion, StringComparison.OrdinalIgnoreCase));

                if (estacionExiste)
                {
                    // Si la estacion ya existe, mostramos un mensaje de advertencia
                    MessageBox.Show("La estación ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Agregar nueva estacion si no existe
                    Estacion nuevaEstacion = new Estacion(
                        nombreEstacion,
                        new List<string> { lineaEstacion },
                        extraCadena,
                        extraNumerico
                    );

                    wrapper.Estaciones.Add(nuevaEstacion);

                    //Guardar el archivo JSON con la nueva estacion
                    GuardarArchivoJson(rutaArchivo, wrapper);

                    // Mostrar un mensaje de confirmación
                    MessageBox.Show("Estación agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Limpiar los campos
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar el archivo JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodo para leer el archivo JSON
        private EstacionesWrapper LeerArchivoJson(string rutaArchivo)
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string jsonData = File.ReadAllText(rutaArchivo);
                    return JsonConvert.DeserializeObject<EstacionesWrapper>(jsonData) ?? new EstacionesWrapper();
                }
                else
                {
                    MessageBox.Show($"No se encontró el archivo en la ruta: {rutaArchivo}");
                    return new EstacionesWrapper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo JSON: {ex.Message}");
                return new EstacionesWrapper();
            }
        }

        // Metodo para guardar el archivo JSON
        private void GuardarArchivoJson(string rutaArchivo, EstacionesWrapper wrapper)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
                File.WriteAllText(rutaArchivo, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo JSON: {ex.Message}");
            }
        }

        // Metodo para limpiar los TextBox después de agregar una estación
        private void LimpiarCampos()
        {
            TextB_Nombre.Clear();
            TextB_Linea.Clear();
            TextB_Cadena.Clear();
            TextB__Numerico.Clear();
        }

      
    }
}
