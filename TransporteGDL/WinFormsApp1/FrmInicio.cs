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

        public FrmInicio()
        {
            InitializeComponent();

            // Cargar las estaciones directamente desde la clase Estacion
            estaciones = Estacion.CargarDatos();

            InicializarComboBox();
        }
        //inicializa el comboBox lineas
        private void InicializarComboBox()
        {
            cmb_Lineas.Items.Clear();
            cmb_Lineas.Items.Add("Todas");

            var lineasUnicas = estaciones.SelectMany(est => est.Lineas).Distinct().OrderBy(linea => linea);
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
                ? new List<Estacion>(estaciones)
                : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

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
            estaciones = Estacion.CargarDatos(); // Recargar estaciones
            listBox_Estaciones.Items.Clear();

        }
        //abrir form agregar estacion
        private void agregarEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del nuevo formulario (por ejemplo, Form2)
            FrmAgregar nuevoForm = new FrmAgregar();

            // Ocultar el formulario actual (Form1)
            this.Hide();

            // Mostrar el nuevo formulario
            nuevoForm.Show();

            // nuevoForm.ShowDialog();

            // Para volver a mostrar el formulario actual cuando se cierre el nuevo:
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
        //abrir form busqueda anchura
        private void anchuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRuta nuevoForm = new FrmRuta();
            //this.Hide();
            nuevoForm.Show();
            nuevoForm.FormClosed += (s, args) => this.Show();
        }
        // imprimir matriz
        private void imprimirMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
                ? new List<Estacion>(estaciones)
                : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            if (estacionesSeleccionadas.Any())
            {
                Estacion.ConstruirMatrizAdyacencia(estacionesSeleccionadas);
            }
            else
            {
                MessageBox.Show("No hay estaciones para la línea seleccionada.");
            }
        }
        // Metodos de Ordenamientos
        private void insercionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(estaciones)
               : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingInsertion(estacionesSeleccionadas);

            foreach (var estacion in estacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }
        private void burbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(estaciones)
               : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingBubbleSort(estacionesSeleccionadas);

            foreach (var estacion in estacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }
        private void seleccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(estaciones)
               : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingSelection(estacionesSeleccionadas);

            foreach (var estacion in estacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }
        private void mezclaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(estaciones)
               : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingMerge(estacionesSeleccionadas);

            foreach (var estacion in estacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }
        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_Estaciones.Items.Clear();
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
               ? new List<Estacion>(estaciones)
               : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            Ordenamientos.SortUsingQuickSort(estacionesSeleccionadas);

            foreach (var estacion in estacionesSeleccionadas)
            {
                listBox_Estaciones.Items.Add($" - {estacion.Nombre}");
            }

            if (!estacionesSeleccionadas.Any())
            {
                listBox_Estaciones.Items.Add("No se encontraron estaciones en esta línea.");
            }
        }

    }

}



