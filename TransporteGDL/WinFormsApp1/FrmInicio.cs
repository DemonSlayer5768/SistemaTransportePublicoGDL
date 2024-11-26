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
        public List<Estacion> Estaciones { get; set; } = new List<Estacion>();

        public FrmInicio()
        {
            InitializeComponent();

            // Cargar las Estaciones directamente desde la clase Estacion

            Estaciones = SistemaTransporte.CargarDatos();
            InicializarComboBox();


        }
        //inicializa el comboBox lineas
        private void InicializarComboBox()
        {
            cmb_Lineas.Items.Clear();
            cmb_Lineas.Items.Add("Todas");

            var lineasUnicas = Estaciones.SelectMany(est => est.Lineas).Distinct().OrderBy(linea => linea);
            foreach (var linea in lineasUnicas)
            {
                cmb_Lineas.Items.Add(linea);
            }
            cmb_Lineas.SelectedIndex = 0;
        }


        //boton imprimir las estaciones
        private void btn_Estaciones_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesParaMostrar = lineaSeleccionada == "Todas"
                ? new List<Estacion>(Estaciones)
                : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            foreach (var estacion in estacionesParaMostrar)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesParaMostrar.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }
        //boton recargar datos
        private void pB_Refresh_Click(object sender, EventArgs e)
        {
            Estaciones = SistemaTransporte.CargarDatos(); // Recargar estaciones
            listBox_Estaciones.Items.Clear();
            InicializarComboBox();

        }
        // private void btn_Estaciones_Click(object sender, EventArgs e)
        // {
        //     listBox_Estaciones.Items.Clear();

        //     string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

        //     List<Estacion> EstacionesParaMostrar = lineaSeleccionada == "Todas"
        //         ? new List<Estacion>(Estaciones)
        //         : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

        //     foreach (var estacion in EstacionesParaMostrar)
        //     {
        //         listBox_Estaciones.Items.Add(estacion.Nombre ?? string.Empty);
        //     }

        //     if (!EstacionesParaMostrar.Any())
        //     {
        //         listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
        //     }
        // }

        // //boton recargar datos
        // private void pB_Refresh_Click(object sender, EventArgs e)
        // {
        //     Estaciones = SistemaTransporte.CargarDatos(); // Recargar Estaciones
        //     listBox_Estaciones.Items.Clear();

        // }
        //abrir form agregar estacion
        private void agregarEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregar nuevoForm = new FrmAgregar();
            this.Hide();
            nuevoForm.Show();
            nuevoForm.FormClosed += (s, args) => this.Show();
        }
        //abrir form eliminar estacion
        private void eliminarEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminar nuevoForm = new FrmEliminar();
            this.Hide();
            nuevoForm.Show();
            nuevoForm.FormClosed += (s, args) => this.Show();
        }
        // imprimir matriz
        private void imprimirMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
                ? new List<Estacion>(Estaciones)
                : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            if (EstacionesSeleccionadas.Any())
            {
                Matriz.ConstruirMatrizAdyacencia(EstacionesSeleccionadas);
            }
            else
            {
                MessageBox.Show("No hay Estaciones para la línea seleccionada.");
            }
        }
        // Metodos de Ordenamientos
        private void insercionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(Estaciones)
               : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingInsertion(EstacionesSeleccionadas);

            foreach (var estacion in EstacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!EstacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
            }
        }

        private void burbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(Estaciones)
               : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingBubbleSort(EstacionesSeleccionadas);

            foreach (var estacion in EstacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!EstacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
            }
        }
        private void seleccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(Estaciones)
               : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingSelection(EstacionesSeleccionadas);

            foreach (var estacion in EstacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!EstacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
            }
        }
        private void mezclaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(Estaciones)
               : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingMerge(EstacionesSeleccionadas);

            foreach (var estacion in EstacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!EstacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
            }
        }
        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> EstacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(Estaciones)
               : Estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingQuickSort(EstacionesSeleccionadas);

            foreach (var estacion in EstacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!EstacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron Estaciones en esta línea.");
            }
        }

        private void busquedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRuta nuevoForm = new FrmRuta();
            // this.Hide();
            nuevoForm.Show();
            nuevoForm.FormClosed += (s, args) => this.Show();
        }
    }

}



