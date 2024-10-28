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

        // Metodo para cargar datos del archivo JSON y configurar el ComboBox

        private void CargarDatos()
        {
           string rutaArchivo = "D:\\Porgramacion\\Materias\\Algoritmia\\SISTEUR\\TransporteGDL\\WinFormsApp1\\STPMG.json";

           EstacionesWrapper wrapper = LeerArchivoJson(rutaArchivo);

           if (wrapper != null && wrapper.Estaciones.Any())
           {
               estaciones = wrapper.Estaciones;

               cmb_Lineas.Items.Clear(); // Limpiar ComboBox antes de llenarlo
               cmb_Lineas.Items.Add("Todas"); // agregar item para mostrar todas las estaciones

               // Usamos HashSet para evitar duplicados de llneas
               HashSet<string> lineasUnicas = new HashSet<string>();

               foreach (var estacion in estaciones)
               {
                   foreach (var linea in estacion.Lineas)
                   {
                       lineasUnicas.Add(linea);
                   }
               }

               // Convertir HashSet a lista y ordenar
               List<string> lineasOrdenadas = lineasUnicas.ToList();
               lineasOrdenadas.Sort(); // Ordenar alfabeticamente

               // Agregar lineas ordenadas al ComboBox
               foreach (var linea in lineasOrdenadas)
               {
                   cmb_Lineas.Items.Add(linea);
               }

               // Opcion "Todas"
               cmb_Lineas.SelectedIndex = 0;
           }
           else
           {
               MessageBox.Show("No se encontraron estaciones en el archivo JSON o el archivo esta vacio.");
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
                    MessageBox.Show($"No se encontr� el archivo en la ruta: {rutaArchivo}");
                    return new EstacionesWrapper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo JSON: {ex.Message}");
                return new EstacionesWrapper();
            }
        }


        private void btn_Estaciones_Click_1(object sender, EventArgs e)
        {   
            listBox_Estaciones.Items.Clear(); // Limpiar ListBox antes de mostrar las estaciones
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            // Clonamos la lista de estaciones para poder ordenarla sin modificar la lista original
            List<Estacion> estacionesParaMostrar;

            if (lineaSeleccionada == "Todas")
            {
                // Ordenamos todas las estaciones cuando se selecciona "Todas"
                estacionesParaMostrar = new List<Estacion>(estaciones); 
            }
            else
            {
                // Filtramos y ordenamos solo las estaciones que pertenecen a la línea seleccionada
                estacionesParaMostrar = estaciones.Where(estacion => estacion.Lineas.Contains(lineaSeleccionada)).ToList();
            }

            // Metodos de ordenamiento para la lista 

            //Ordenamientos.SortUsingInsertion(estacionesParaMostrar); //Metodo Insercion
            // Ordenamientos.SortUsingBubbleSort(estacionesParaMostrar); //Metodo Burbuja
            // Ordenamientos.SortUsingSelection(estacionesParaMostrar); //Metodo Seleccion 
            Ordenamientos.SortUsingMerge(estacionesParaMostrar); //Metodo Mezcla


            // Mostrar las estaciones ordenadas en la consola
            Console.WriteLine("Estaciones ordenadas por nombre: \n");
            foreach (var estacion in estacionesParaMostrar) // Cambié aquí para usar 'estacionesParaMostrar'
            {
                Console.WriteLine($"- {estacion.Nombre} \n");
            }

            // Llenamos el ListBox con las estaciones ordenadas
            if (estacionesParaMostrar.Any())
            {
                foreach (var estacion in estacionesParaMostrar)
                {
                    listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
                }
            }
            else
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
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

        private void eliminarEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminar nuevoForm = new FrmEliminar();
            this.Hide();
            nuevoForm.Show();
            nuevoForm.FormClosed += (s, args) => this.Show();
        }

        private void pB_Refresh_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear(); // Limpiar ListBox antes de mostrar las estaciones
            CargarDatos(); // recargar JSON
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