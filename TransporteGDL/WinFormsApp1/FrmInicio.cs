using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1;
namespace My_FrmInicio
{
    public partial class FrmInicio : Form
    {
        private List<Estacion> estaciones;
        private int[,] matrizAdyacencia;

        public FrmInicio()
        {
            InitializeComponent();
            estaciones = new List<Estacion>();
            matrizAdyacencia = new int[0, 0]; // Inicialización temporal para evitar la advertencia
            CargarDatos();
        }

        // Método para cargar datos del archivo JSON y configurar el ComboBox
        private void CargarDatos()
        {
            string rutaArchivo = "D:\\Porgramacion\\Materias\\Algoritmia\\SISTEUR\\TransporteGDL\\WinFormsApp1\\STPMG.json";

            if (File.Exists(rutaArchivo))
            {
                string jsonData = File.ReadAllText(rutaArchivo);
                JObject jsonObj = JObject.Parse(jsonData);

                var estacionesArray = jsonObj["Estaciones"] as JArray;

                if (estacionesArray != null)
                {
                    estaciones = estacionesArray.Select(estacion => new Estacion(
                        (string?)estacion["Nombre"] ?? string.Empty,
                        estacion["Lineas"]?.Select(linea => (string?)linea ?? string.Empty).ToList() ?? new List<string>(),
                        (string?)estacion["ExtraCadena"] ?? string.Empty,
                        (int?)estacion["ExtraNumerico"] ?? 0
                    )).ToList();
                }
                else
                {
                    estaciones = new List<Estacion>(); // Si no se encuentran estaciones, se inicializa una lista vacía
                }



                cmb_Lineas.Items.Clear();
                cmb_Lineas.Items.Add("Todas");

                var lineasUnicas = estaciones.SelectMany(est => est.Lineas).Distinct().OrderBy(linea => linea);
                foreach (var linea in lineasUnicas)
                {
                    cmb_Lineas.Items.Add(linea);
                }
                cmb_Lineas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"No se encontró el archivo en la ruta: {rutaArchivo}");
            }
        }

        // Modificar el método de construcción de la matriz de adyacencia para que acepte las estaciones seleccionadas
        private void ConstruirMatrizAdyacencia(List<Estacion> estacionesSeleccionadas)
        {
            int n = estacionesSeleccionadas.Count;
            matrizAdyacencia = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // Verificar si las estaciones i y j comparten alguna línea
                    bool compartenLinea = estacionesSeleccionadas[i].Lineas.Intersect(estacionesSeleccionadas[j].Lineas).Any();
                    if (compartenLinea)
                    {
                        matrizAdyacencia[i, j] = 1;
                        matrizAdyacencia[j, i] = 1; // Simetría
                    }
                }
            }
        }

        // Imprimir la matriz de adyacencia para las estaciones seleccionadas
        private void ImprimirMatrizAdyacencia(List<Estacion> estacionesSeleccionadas)
        {
            // Usar un ListBox o cualquier otro control para mostrar la matriz
            listBox_Estaciones.Items.Clear();
            listBox_Estaciones.Items.Add($"Matriz de Adyacencia para la línea: {cmb_Lineas.SelectedItem}");

            for (int i = 0; i < matrizAdyacencia.GetLength(0); i++)
            {
                string fila = "";
                for (int j = 0; j < matrizAdyacencia.GetLength(1); j++)
                {
                    fila += matrizAdyacencia[i, j] + " ";
                }
                listBox_Estaciones.Items.Add(fila); // Mostrar la fila de la matriz
            }
        }


        private void btn_Estaciones_Click_1(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesParaMostrar;

            if (lineaSeleccionada == "Todas")
            {
                estacionesParaMostrar = new List<Estacion>(estaciones);
            }
            else
            {
                estacionesParaMostrar = estaciones.Where(estacion => estacion.Lineas.Contains(lineaSeleccionada)).ToList();
            }

        
            foreach (var estacion in estacionesParaMostrar)
            {
                Console.WriteLine($"- {estacion.Nombre}");
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesParaMostrar.Any())
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
            listBox_Estaciones.Items.Clear();
            CargarDatos();
        }

        private void imprimirMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            // Filtrar estaciones de acuerdo con la línea seleccionada
            List<Estacion> estacionesSeleccionadas = new List<Estacion>();

            if (lineaSeleccionada == "Todas")
            {
                estacionesSeleccionadas = new List<Estacion>(estaciones); // Si es "Todas", todas las estaciones
            }
            else
            {
                estacionesSeleccionadas = estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList(); // Filtrar solo las estaciones de la línea seleccionada
            }

            // Si no hay estaciones seleccionadas, mostramos un mensaje
            if (estacionesSeleccionadas.Any())
            {
                // Construir la matriz de adyacencia para las estaciones seleccionadas
                ConstruirMatrizAdyacencia(estacionesSeleccionadas);

                // Imprimir la matriz de adyacencia en el ListBox o en otro control
                ImprimirMatrizAdyacencia(estacionesSeleccionadas);
            }
            else
            {
                MessageBox.Show("No hay estaciones para la línea seleccionada.");
            }
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
}
