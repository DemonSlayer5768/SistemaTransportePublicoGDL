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
        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void Btn_AgregarEstacion_Click(object sender, EventArgs e)
        {
            // Obtener datos de los TextBox
            string nombreEstacion = TextB_Nombre.Text.Trim();
            string lineaEstacion = TextB_Linea.Text.Trim();
            string extraCadena = TextB_Cadena.Text.Trim();
            int extraNumerico = int.TryParse(TextB__Numerico.Text, out int num) ? num : 0;

            // Cargar estaciones existentes
            List<Estacion> estaciones = Estacion.CargarDatos();

            // Verificar si la estación ya existe
            bool estacionExiste = estaciones.Any(e => e.Nombre.Equals(nombreEstacion, StringComparison.OrdinalIgnoreCase));

            if (estacionExiste)
            {
                MessageBox.Show("La estación ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Crear una nueva estación
                Estacion nuevaEstacion = new Estacion(
                    nombreEstacion,
                    new List<string> { lineaEstacion },
                    extraCadena,
                    extraNumerico
                );

                // Agregar la nueva estación a la lista
                estaciones.Add(nuevaEstacion);

                // Guardar estaciones actualizadas en el archivo JSON
                GuardarEstaciones(estaciones);

                MessageBox.Show("Estación agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                LimpiarCampos();
            }
        }

        // Método para guardar las estaciones en el archivo JSON
        private void GuardarEstaciones(List<Estacion> estaciones)
        {
            try
            {
                var jsonObj = new
                {
                    Estaciones = estaciones.Select(est => new
                    {
                        est.Nombre,
                        est.Lineas,
                        est.ExtraCadena,
                        est.ExtraNumerico
                    })
                };

                string jsonData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(Estacion.RutaArchivoJson, jsonData);
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
            TextB_Cadena.Clear();
            TextB__Numerico.Clear();
        }
    }
}
