using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmEliminar : Form
    {
        private List<Estacion> Estaciones;
        private string RutaArchivoJson = SistemaTransporte.RutaArchivoJson;

        public FrmEliminar()
        {
            InitializeComponent();
            Estaciones = new List<Estacion>();
            CargarDatos_Lineas();
        }

        // Método para cargar líneas en cmb_Lineas
        private void CargarDatos_Lineas()
        {
            Estaciones = SistemaTransporte.CargarDatos();

            if (Estaciones.Any())
            {
                cmb_Lineas.Items.Clear();
                var lineasUnicas = Estaciones
                    .SelectMany(estacion => estacion.Lineas)
                    .Distinct()
                    .ToList();

                foreach (var linea in lineasUnicas)
                {
                    cmb_Lineas.Items.Add(linea);
                }

                cmb_Lineas.SelectedIndexChanged += (s, e) => CargarDatos_Estaciones();
            }
            else
            {
                MessageBox.Show("No se encontraron estaciones en el archivo JSON.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para cargar estaciones en cmb_Estaciones dependiendo de la línea seleccionada
        private void CargarDatos_Estaciones()
        {
            cmb_Estaciones.Items.Clear();
            cmb_Estaciones.Items.Add("Todas");

            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(lineaSeleccionada))
            {
                var estacionesFiltradas = Estaciones
                    .Where(estacion => estacion.Lineas.Contains(lineaSeleccionada) && !string.IsNullOrEmpty(estacion.Nombre)) // Filtrar nombres nulos o vacíos
                    .Select(estacion => estacion.Nombre)
                    .Distinct();

                foreach (var estacion in estacionesFiltradas)
                {
                    if (!string.IsNullOrEmpty(estacion)) // Verificar nuevamente antes de agregar
                    {
                        cmb_Estaciones.Items.Add(estacion);
                    }
                }

                cmb_Estaciones.SelectedIndex = -1;
            }

        }

        // Método para eliminar la estación o línea seleccionada
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;
            string estacionSeleccionada = cmb_Estaciones.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(lineaSeleccionada) || string.IsNullOrEmpty(estacionSeleccionada))
            {
                MessageBox.Show("Por favor selecciona una línea y una estación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (estacionSeleccionada == "Todas")
            {
                DialogResult dialogResult = MessageBox.Show($"¿Deseas eliminar la línea {lineaSeleccionada} y todas sus estaciones asociadas?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    // Eliminar estaciones asociadas a la línea
                    Estaciones.RemoveAll(estacion => estacion.Lineas.Contains(lineaSeleccionada));
                    MessageBox.Show($"La línea {lineaSeleccionada} y sus estaciones asociadas fueron eliminadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"¿Deseas eliminar la estación {estacionSeleccionada} de la línea {lineaSeleccionada}?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    var estacionAEliminar = Estaciones.FirstOrDefault(estacion =>
                        estacion.Nombre == estacionSeleccionada && estacion.Lineas.Contains(lineaSeleccionada));

                    if (estacionAEliminar != null)
                    {
                        estacionAEliminar.Lineas.Remove(lineaSeleccionada);
                        if (!estacionAEliminar.Lineas.Any())
                        {
                            Estaciones.Remove(estacionAEliminar);
                        }
                        MessageBox.Show($"La estación {estacionSeleccionada} fue eliminada de la línea {lineaSeleccionada}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            GuardarArchivoJson();
            RecargarDatos();
        }

        // Método para guardar los cambios en el archivo JSON
        private void GuardarArchivoJson()
        {
            try
            {
                var jsonObj = new
                {
                    Estaciones = Estaciones.Select(est => new
                    {
                        est.Nombre,
                        est.Lineas,
                        est.Conexiones
                    })
                };

                string jsonData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(RutaArchivoJson, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para recargar los datos en los ComboBox
        private void RecargarDatos()
        {
            cmb_Lineas.Items.Clear();
            cmb_Estaciones.Items.Clear();
            CargarDatos_Lineas();
        }
    }
}
