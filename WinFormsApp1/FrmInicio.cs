using Newtonsoft.Json;
using WinFormsApp1;
namespace My_FrmInicio
{
    public partial class FrmInicio : Form
    {

        private List<Estacion> estaciones;

        public FrmInicio()
        {
            InitializeComponent();
            estaciones = new List<Estacion>();
            CargarDatos();
        }

        // Método para cargar datos del archivo JSON y configurar el ComboBox
        private void CargarDatos()
        {
            string rutaArchivo = "C:\\Users\\jjaim\\source\\repos\\WinFormsApp1\\WinFormsApp1\\STPMG.json";

            EstacionesWrapper wrapper = LeerArchivoJson(rutaArchivo);

            if (wrapper != null && wrapper.Estaciones.Any())
            {
                estaciones = wrapper.Estaciones;
                cmb_Lineas.Items.Clear(); // Limpiar ComboBox antes de llenarlo
                cmb_Lineas.Items.Add("Todas"); // agregar item para mostrar todas las estaciones

                // Usamos HashSet para evitar duplicados de líneas
                HashSet<string> lineasUnicas = new HashSet<string>();

                foreach (var estacion in estaciones)
                {
                    foreach (var linea in estacion.Lineas)
                    {
                        lineasUnicas.Add(linea);
                    }
                }

                // Agregar lineas 
                foreach (var linea in lineasUnicas)
                {
                    cmb_Lineas.Items.Add(linea);
                }

                // Seleccionar "Todas" por defecto
                cmb_Lineas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontraron estaciones en el archivo JSON o el archivo está vacío.");
            }
        }

        // Método para leer el archivo JSON
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

        // Función para abrir el formulario de agregar estaciones
        public void open_windows_form(object sender, EventArgs e)
        {
            //Frm_Agregar frm_Agregar = new Frm_Agregar();
            //frm_Agregar.Show();
        }

        private void btn_Estaciones_Click_1(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear(); // Limpiar ListBox antes de mostrar las estaciones
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? "Ninguna";

            if (lineaSeleccionada == "Todas")
            {
                foreach (var estacion in estaciones)
                {
                    listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
                }
            }
            else
            {
                var estacionesDeLinea = estaciones.Where(estacion => estacion.Lineas.Contains(lineaSeleccionada)).ToList();

                if (estacionesDeLinea.Any())
                {
                    foreach (var estacion in estacionesDeLinea)
                    {
                        listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
                    }
                }
                else
                {
                    listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
                }
            }
        }

        private void agregarEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del nuevo formulario (por ejemplo, Form2)
            FrmAgregar nuevoForm = new FrmAgregar();

            // Ocultar el formulario actual (Form1)
            this.Hide();

            // Mostrar el nuevo formulario
            nuevoForm.Show();

            // Si quieres que el nuevo formulario sea modal (bloquee el formulario actual hasta que se cierre), usa:
            // nuevoForm.ShowDialog();

            // Para volver a mostrar el formulario actual cuando se cierre el nuevo:
            nuevoForm.FormClosed += (s, args) => this.Show();
        }

     
    }

    // Clase Estacion
    public class Estacion
    {
        public string Nombre { get; set; }
        public List<string> Lineas { get; set; }
        public string ExtraCadena { get; set; }
        public int ExtraNumerico { get; set; }

        public Estacion(string nombre, List<string> lineas, string extraCadena, int extraNumerico)
        {
            Nombre = nombre;
            Lineas = lineas;
            ExtraCadena = extraCadena;
            ExtraNumerico = extraNumerico;
        }
    }

    // Clase envoltura para deserializar el JSON
    public class EstacionesWrapper
    {
        public List<Estacion> Estaciones { get; set; } = new List<Estacion>();

        public EstacionesWrapper() { }
    }
}

