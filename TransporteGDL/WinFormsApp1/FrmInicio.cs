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

            // Cargar las estaciones directamente desde la clase Estacion
            estaciones = Estacion.CargarDatos();

            matrizAdyacencia = new int[0, 0]; // Inicialización temporal para evitar la advertencia
            InicializarComboBox();
        }

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


        private void ConstruirMatrizAdyacencia(List<Estacion> estacionesSeleccionadas)
        {
            int n = estacionesSeleccionadas.Count;
            matrizAdyacencia = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    bool compartenLinea = estacionesSeleccionadas[i].Lineas.Intersect(estacionesSeleccionadas[j].Lineas).Any();
                    if (compartenLinea)
                    {
                        matrizAdyacencia[i, j] = 1;
                        matrizAdyacencia[j, i] = 1; // Simetria
                    }
                }
            }
        }

        private void ImprimirMatrizAdyacencia(List<Estacion> estacionesSeleccionadas)
        {
            listBox_Estaciones.Items.Clear();
            listBox_Estaciones.Items.Add($"Matriz de Adyacencia para la línea: {cmb_Lineas.SelectedItem}");

            for (int i = 0; i < matrizAdyacencia.GetLength(0); i++)
            {
                string fila = "";
                for (int j = 0; j < matrizAdyacencia.GetLength(1); j++)
                {
                    fila += matrizAdyacencia[i, j] + " ";
                }
                listBox_Estaciones.Items.Add(fila);
            }
        }

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

        private void pB_Refresh_Click(object sender, EventArgs e)
        {
            estaciones = Estacion.CargarDatos(); // Recargar estaciones
            listBox_Estaciones.Items.Clear();

        }

        private void imprimirMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;

            List<Estacion> estacionesSeleccionadas = lineaSeleccionada == "Todas"
                ? new List<Estacion>(estaciones)
                : estaciones.Where(est => est.Lineas.Contains(lineaSeleccionada)).ToList();

            if (estacionesSeleccionadas.Any())
            {
                ConstruirMatrizAdyacencia(estacionesSeleccionadas);
                ImprimirMatrizAdyacencia(estacionesSeleccionadas);
            }
            else
            {
                MessageBox.Show("No hay estaciones para la línea seleccionada.");
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

    }

    
}
