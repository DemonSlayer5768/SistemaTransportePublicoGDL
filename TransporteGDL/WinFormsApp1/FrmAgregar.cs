using My_FrmInicio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmAgregar : Form
    {
        public List<Estacion> Estaciones { get; set; } = new List<Estacion>();

        public FrmAgregar()
        {
            InitializeComponent();
            Estaciones = SistemaTransporte.CargarDatos();
        }

        private void Btn_AgregarEstacion_Click(object sender, EventArgs e)
        {
            // Obtener datos de los TextBox
            string nombreEstacion = TextB_Nombre.Text.Trim();
            string lineaEstacion = TextB_Linea.Text.Trim();
            string vecinoIzq = TextB_VecinoIzq.Text.Trim();
            string vecinoDer = TextB_VecinoDer.Text.Trim();

            // Verificar si la estación ya existe
            bool estacionExiste = Estaciones.Any(e => e.Nombre != null && e.Nombre.Equals(nombreEstacion, StringComparison.OrdinalIgnoreCase));


            if (estacionExiste)
            {
                MessageBox.Show("La estación ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Crear una nueva estación
                var nuevaEstacion = new Estacion(
                    nombreEstacion,
                    new List<string> { lineaEstacion },
                    new List<string> { vecinoIzq, vecinoDer }
                );

                // Agregar la nueva estación a la lista
                Estaciones.Add(nuevaEstacion);

                // Guardar las estaciones actualizadas en el archivo JSON
                GuardarEstaciones();

                MessageBox.Show("Estación agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                LimpiarCampos();
            }
        }

        // Método para guardar las estaciones en el archivo JSON
        private void GuardarEstaciones()
        {
            try
            {
                var jsonObj = new
                {
                    Estaciones = Estaciones.Select(est => new
                    {
                        Nombre = est.Nombre,
                        Lineas = est.Lineas,
                        Conexiones = est.Conexiones
                    })
                };

                string jsonData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(SistemaTransporte.RutaArchivoJson, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo JSON: {ex.Message}");
            }
        }

        // Método para limpiar los TextBox después de agregar una estación
        private void LimpiarCampos()
        {
            TextB_Nombre.Clear();
            TextB_Linea.Clear();
            TextB_VecinoIzq.Clear();
            TextB_VecinoDer.Clear();
        }
    }
}
