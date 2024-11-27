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
            string estacionA = cmb_Estacion_A.SelectedItem?.ToString() ?? string.Empty;
            string estacionB = cmb_Estacion_B.SelectedItem?.ToString() ?? string.Empty;
            // Ejecutar BFS para encontrar el camino más corto
            algoritmosBusqueda(estacionA, estacionB);

        }

        public void algoritmosBusqueda(string estacionA, string estacionB)
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



            // Verificamos si el método seleccionado es "Anchura"
            if (metodoSeleccionado == "Anchura")
            {
                // Ejecutar el algoritmo correspondiente
                List<string> recorrido = new List<string>();
                recorrido = Algoritmos_Busqueda.BFS(grafo, estacionInicio, estacionDestino);
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
            else
            {
                // Definir la matriz de adyacencia (5 estaciones: A, B, C, D, E)
                int[][] matrizAdyacencia = new int[5][];
                for (int i = 0; i < 5; i++)
                {
                    matrizAdyacencia[i] = new int[5];  // Inicializa una matriz 5x5
                }

                // Luego, agregar las aristas con los pesos
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 0, 1, 5); // A - B
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 0, 2, 7); // A - C
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 0, 4, 2); // A - E
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 1, 3, 6); // B - D
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 1, 4, 3); // B - E
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 3, 4, 5); // D - E
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 2, 3, 4); // C - D
                Algoritmos_Busqueda.agregar_Arista(matrizAdyacencia, 2, 4, 4); // C - E



                switch (metodoSeleccionado)
                {
                    case "Prim":
                        Algoritmos_Busqueda.Prim(matrizAdyacencia);
                        break;

                    case "Kruskal":
                        Algoritmos_Busqueda.Kruskal(matrizAdyacencia);
                        break;

                    case "Dijkstra":
                        Algoritmos_Busqueda.Dijkstra(matrizAdyacencia, 0);
                        break;

                    default:
                        MessageBox.Show("Seleccione una opcion valida!");
                        return;
                }
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
