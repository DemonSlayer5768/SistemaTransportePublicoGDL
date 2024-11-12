using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmRuta : Form
    {
        private List<Estacion> estaciones;

        public FrmRuta()
        {
            InitializeComponent();
            estaciones = Estacion.CargarDatos();
            CargarEstacionesEnComboBox();
        }

        private void CargarEstacionesEnComboBox()
        {
            // Cargar nombres de las estaciones en los ComboBox
            var nombresEstaciones = estaciones.Select(e => e.Nombre).ToList();
            cmb_Estacion_A.Items.AddRange(nombresEstaciones.ToArray());
            cmb_Estacion_B.Items.AddRange(nombresEstaciones.ToArray());
        }

        private void ConfigurarListView()
        {
            listView_Direccion.View = View.Details; // Cambiar a vista detallada
            listView_Direccion.Columns.Clear(); // Limpiar columnas anteriores
            listView_Direccion.Columns.Add("Ruta", listView_Direccion.Width - 5); // Agregar columna con ancho dinámico
            listView_Direccion.HeaderStyle = ColumnHeaderStyle.None; // Opcional: ocultar encabezado de la columna
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar que ambos ComboBox tengan una selección
            if (cmb_Estacion_A.SelectedItem == null || cmb_Estacion_B.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una estación de partida y una estación de destino.", "Error");
                return;
            }

            string estacionA = cmb_Estacion_A.SelectedItem?.ToString() ?? string.Empty;
            string estacionB = cmb_Estacion_B.SelectedItem?.ToString() ?? string.Empty;


            // Ejecutar BFS para encontrar el camino más corto
            List<string> camino = BuscarCaminoMasCorto(estacionA, estacionB);

            // Mostrar el resultado en el ListView
            MostrarCaminoEnListView(camino);
        }

        private List<string> BuscarCaminoMasCorto(string estacionA, string estacionB)
        {
            // Crear un diccionario para representar el grafo (adyacencias)
            var grafo = new Dictionary<string, List<string>>();

            foreach (var estacion in estaciones)
            {
                if (!grafo.ContainsKey(estacion.Nombre))
                {
                    grafo[estacion.Nombre] = new List<string>();
                }

                // Agregar conexiones con otras estaciones que compartan al menos una línea
                foreach (var otraEstacion in estaciones)
                {
                    if (estacion.Nombre != otraEstacion.Nombre &&
                        estacion.Lineas.Intersect(otraEstacion.Lineas).Any())
                    {
                        if (!grafo[estacion.Nombre].Contains(otraEstacion.Nombre))
                        {
                            grafo[estacion.Nombre].Add(otraEstacion.Nombre);
                        }
                    }
                }
            }

            // BFS para encontrar el camino más corto
            var visitados = new HashSet<string>();
            var cola = new Queue<List<string>>();
            cola.Enqueue(new List<string> { estacionA });

            while (cola.Count > 0)
            {
                var caminoActual = cola.Dequeue();
                string ultimaEstacion = caminoActual.Last();

                // Si llegamos al destino
                if (ultimaEstacion == estacionB)
                {
                    return caminoActual;
                }

                if (!visitados.Contains(ultimaEstacion))
                {
                    visitados.Add(ultimaEstacion);

                    foreach (var vecino in grafo[ultimaEstacion])
                    {
                        // Crear un nuevo camino extendido
                        var nuevoCamino = new List<string>(caminoActual) { vecino };
                        cola.Enqueue(nuevoCamino);
                    }
                }
            }

            // Si no hay camino
            return new List<string> { "No se encontró un camino." };
        }


        private void MostrarCaminoEnListView(List<string> camino)
        {
            ConfigurarListView(); // Configurar el ListView

            listView_Direccion.Items.Clear();
            foreach (var estacion in camino)
            {
                string nombreFormateado = estacion.Replace("\r", "").Replace("\n", "").Trim();
                listView_Direccion.Items.Add(new ListViewItem(nombreFormateado));
            }

            // Ajustar el ancho de la columna automáticamente
            listView_Direccion.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


    }
}
