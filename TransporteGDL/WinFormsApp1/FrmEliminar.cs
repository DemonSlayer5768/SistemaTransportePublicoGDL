using My_FrmInicio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmEliminar : Form
    {
        private List<Estacion> estaciones;
        private string rutaArchivo = "D:\\Porgramacion\\Materias\\Algoritmia\\SISTEUR\\TransporteGDL\\WinFormsApp1\\STPMG.json";

        public FrmEliminar()
        {
            InitializeComponent();
            estaciones = new List<Estacion>();
            CargarDatos_Lineas();
        }

        // Método para cargar líneas en cmb_Lineas
        private void CargarDatos_Lineas()
        {
            EstacionesWrapper wrapper = LeerArchivoJson(rutaArchivo);

            if (wrapper != null && wrapper.Estaciones.Any())
            {
                estaciones = wrapper.Estaciones;
                cmb_Lineas.Items.Clear();
                HashSet<string> lineasUnicas = new HashSet<string>();

                foreach (var estacion in estaciones)
                {
                    foreach (var linea in estacion.Lineas)
                    {
                        lineasUnicas.Add(linea);
                    }
                }

                foreach (var linea in lineasUnicas)
                {
                    cmb_Lineas.Items.Add(linea);
                }
                cmb_Lineas.SelectedIndexChanged += (s, e) => CargarDatos_Estaciones();
            }
            else
            {
                MessageBox.Show("No se encontraron estaciones en el archivo JSON o el archivo está vacío.");
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
                var estacionesFiltradas = estaciones
                    .Where(estacion => estacion.Lineas.Contains(lineaSeleccionada))
                    .Select(estacion => estacion.Nombre)
                    .Distinct();

                foreach (var estacion in estacionesFiltradas)
                {
                    cmb_Estaciones.Items.Add(estacion);
                }
                cmb_Estaciones.SelectedIndex = -1;
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

        // Método para guardar cambios en el archivo JSON
        private void GuardarArchivoJson()
        {
            try
            {
                var wrapper = new EstacionesWrapper { Estaciones = estaciones };
                string jsonData = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
                File.WriteAllText(rutaArchivo, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo JSON: {ex.Message}");
            }
        }


        // Método para eliminar la estación seleccionada
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string lineaSeleccionada = cmb_Lineas.SelectedItem?.ToString() ?? string.Empty;
            string estacionSeleccionada = cmb_Estaciones.SelectedItem?.ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(lineaSeleccionada) && !string.IsNullOrEmpty(estacionSeleccionada))
            {
                // Manejo de la eliminación
                if (estacionSeleccionada == "Todas")
                {
                    DialogResult dialogResult = MessageBox.Show($"¿Desea eliminar también la línea {lineaSeleccionada}?",
                                                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        estaciones.RemoveAll(estacion => estacion.Lineas.Contains(lineaSeleccionada));
                    }
                    else
                    {
                        foreach (var estacion in estaciones.Where(estacion => estacion.Lineas.Contains(lineaSeleccionada)))
                        {
                            estacion.Lineas.Remove(lineaSeleccionada);
                        }
                    }
                    MessageBox.Show($"Estaciónes y Linea {lineaSeleccionada} eliminadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // Eliminar la estación seleccionada
                    DialogResult dialogResult = MessageBox.Show($"¿Desea eliminar la estación: {estacionSeleccionada}?",
                                                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        var estacionAEliminar = estaciones.FirstOrDefault(estacion =>
                                                    estacion.Nombre == estacionSeleccionada && estacion.Lineas.Contains(lineaSeleccionada));

                        if (estacionAEliminar != null)
                        {
                            estacionAEliminar.Lineas.Remove(lineaSeleccionada);

                            if (!estacionAEliminar.Lineas.Any())
                            {
                                estaciones.Remove(estacionAEliminar);
                            }
                        }
                    }
                    MessageBox.Show("Estación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                GuardarArchivoJson(); // Guardar cambios en el archivo JSON

                // Limpiar los ComboBox
                cmb_Lineas.Items.Clear();
                cmb_Estaciones.Items.Clear();

                // Recargar líneas después de la eliminación
                CargarDatos_Lineas(); // Cargar líneas para actualizar cmb_Lineas

                // Asegúrate de que los ComboBox estén deseleccionados
                cmb_Lineas.SelectedIndex = -1;
                cmb_Estaciones.SelectedIndex = -1;

            }
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {

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
