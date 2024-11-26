using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmRuta : Form
    {
        public List<Estacion> Estaciones { get; set; } = new List<Estacion>();

        public FrmRuta()
        {
            InitializeComponent();
            Estaciones = SistemaTransporte.CargarDatos();
            CargarEstacionesEnComboBox();
        }

        private void CargarEstacionesEnComboBox()
        {
            var nombresEstaciones = Estaciones.Select(e => e.Nombre ?? string.Empty).ToArray();
            cmb_Estacion_A.Items.AddRange(nombresEstaciones);
            cmb_Estacion_B.Items.AddRange(nombresEstaciones);


            if (cmb_Metodo.Items.Count == 0)
            {
                cmb_Metodo.Items.Add("Anchura");
                cmb_Metodo.Items.Add("Prim");
                cmb_Metodo.Items.Add("Kruskal");
                cmb_Metodo.Items.Add("Dijkstra");
            }
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
            BuscarCaminoMasCorto(estacionA, estacionB);

        }

        public void BuscarCaminoMasCorto(string estacionA, string estacionB)
        {
            // Cargar datos y construir el grafo
            List<Estacion> Estaciones = SistemaTransporte.CargarDatos();
            GrafoEstaciones grafo = new GrafoEstaciones();
            grafo.Estaciones.AddRange(Estaciones);

            // Establecer las Estaciones de inicio y destino
            string estacionInicio = estacionA;
            string estacionDestino = estacionB;

            // Validar que haya una opción seleccionada
            if (cmb_Metodo.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un método de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el método seleccionado
            string metodoSeleccionado = cmb_Metodo.SelectedItem.ToString() ?? string.Empty;

            // Ejecutar el algoritmo correspondiente
            List<string> recorrido = new List<string>();
            switch (metodoSeleccionado)
            {
                case "Anchura":
                    recorrido = Algoritmos_Busqueda.BFS(grafo, estacionInicio, estacionDestino);
                    break;

                case "Prim":
                    List<string> recorridoPrim = Algoritmos_Busqueda.Prim(grafo, estacionInicio, estacionDestino);
                    break;

                case "Kruskal":
                    List<(string, string)> arbolKruskal = Algoritmos_Busqueda.Kruskal(grafo);
                    break;

                case "Dijkstra":
                    MessageBox.Show("Método Dijkstra no está implementado aún.", "Información");
                    break;

                default:
                    List<string> Dijkstra = Algoritmos_Busqueda.Dijkstra(grafo, estacionInicio, estacionDestino);
                    return;
            }

            // Mostrar el resultado del recorrido
            if (recorrido.Count > 0)
            {
                MostrarCaminoEnListView(recorrido);
            }
            else
            {
                MessageBox.Show("No se encontró un camino entre las Estaciones seleccionadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        private void MostrarCaminoEnListView(List<string> recorrido)
        {
            ConfigurarListView(); // Configurar el ListView si es necesario

            listView_Direccion.Items.Clear(); // Limpiar los elementos existentes en el ListView

            // Crear un string con las Estaciones separadas por " -> "
            string caminoFormateado = string.Join(" -> ", recorrido);

            // Añadir el camino formateado al ListView
            listView_Direccion.Items.Add(new ListViewItem(caminoFormateado));

            // Ajustar el ancho de la columna automáticamente
            listView_Direccion.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }




    }
}
