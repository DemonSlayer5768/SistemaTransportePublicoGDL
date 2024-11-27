using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class Algoritmos_Busqueda
{
    // Función para el algoritmo de Búsqueda en Anchura (BFS)
    public static List<string> BFS(GrafoEstaciones grafo, string inicio, string destino)
    {
        List<string> recorrido = new List<string>();
        var visitados = new HashSet<string>(); // Conjunto para marcar las Estaciones visitadas
        var cola = new Queue<string>();        // Cola para BFS
        var padres = new Dictionary<string, string>(); // Diccionario para rastrear el camino

        // Encolamos la estación de inicio y la marcamos como visitada
        cola.Enqueue(inicio);
        visitados.Add(inicio);

        // Mientras haya Estaciones en la cola
        while (cola.Count > 0)
        {
            var estacion = cola.Dequeue(); // Extraemos la estación de la cola

            // Si hemos llegado al destino, reconstruimos el recorrido
            if (estacion == destino)
            {
                var temp = destino;
                while (temp != null)
                {
                    recorrido.Insert(0, temp); // Insertamos la estación en la primera posición
                    padres.TryGetValue(temp, out temp); // Recuperamos el padre de la estación
                }
                Console.WriteLine(string.Join(" -> ", recorrido)); // Mostramos el recorrido
                break;
            }

            // Visitamos los vecinos de la estación actual
            foreach (var vecino in grafo.ObtenerEstacion(estacion)?.Conexiones ?? new List<string>())
            {
                if (!visitados.Contains(vecino)) // Si el vecino no ha sido visitado
                {
                    cola.Enqueue(vecino); // Lo agregamos a la cola
                    visitados.Add(vecino); // Lo marcamos como visitado
                    padres[vecino] = estacion; // Establecemos la estación actual como su "padre"
                }
            }
        }

        return recorrido; // Retornamos el recorrido más corto
    }

    public static void agregar_Arista(int[][] matriz, int i, int j, int peso)
    {
        // Verificar si los índices son válidos
        if (i < 0 || j < 0 || i >= matriz.Length || j >= matriz.Length)
        {
            throw new ArgumentException("Los índices de la estación no son válidos.");
        }

        // Asignar el peso en la posición (i, j) y (j, i) ya que es un grafo no dirigido
        matriz[i][j] = peso;
        matriz[j][i] = peso;
    }



    // Función para el algoritmo de Prim
    public static void Prim(int[][] matrizAdyacencia)
    {
        int n = 5; // Número de estaciones (A, B, C, D, E)
        int[] clave = new int[n];  // Guardará el peso mínimo de cada estación
        bool[] visitado = new bool[n];  // Marca las estaciones visitadas
        int[] padre = new int[n];  // Guardará el nodo anterior de cada estación en el AEM

        // Inicializar los valores
        for (int i = 0; i < n; i++)
        {
            clave[i] = int.MaxValue; // Inicializar con un valor muy alto
            visitado[i] = false; // Inicializar como no visitado
            padre[i] = -1; // No hay nodo anterior aún
        }

        clave[0] = 0; // Comenzamos desde la estación A (índice 0)

        for (int i = 0; i < n - 1; i++)
        {
            // Seleccionar el nodo con el valor mínimo de clave
            int u = MinClave(clave, visitado, n);
            visitado[u] = true; // Marcar el nodo como visitado

            // Actualizar los valores de las estaciones adyacentes
            for (int v = 0; v < n; v++)
            {
                if (matrizAdyacencia[u][v] != 0 && !visitado[v] && matrizAdyacencia[u][v] < clave[v])
                {
                    clave[v] = matrizAdyacencia[u][v];
                    padre[v] = u;
                }
            }
        }

        // Mostrar el árbol de expansión mínima
        string resultado = "Árbol de Expansión Mínima (Prim):\n";
        for (int i = 1; i < n; i++)
        {
            resultado += $"Estación {Convert.ToChar('A' + i)} - Estación {Convert.ToChar('A' + padre[i])} con peso {matrizAdyacencia[i][padre[i]]}\n";
        }

        // Mostrar toda la matriz de adyacencia
        string matrizTexto = "Matriz de Adyacencia:\n";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizTexto += matrizAdyacencia[i][j] + "\t";
            }
            matrizTexto += "\n";
        }

        // Mostrar todo en un solo MessageBox
        MessageBox.Show(resultado + "\n" + matrizTexto, "Resultado de Prim", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    // Función para encontrar el nodo con la clave mínima
    private static int MinClave(int[] clave, bool[] visitado, int n)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < n; v++)
        {
            if (!visitado[v] && clave[v] < min)
            {
                min = clave[v];
                minIndex = v;
            }
        }

        return minIndex;
    }




    // Función para el algoritmo de Kruskal
    public static void Kruskal(int[][] matrizAdyacencia)
    {
        int n = matrizAdyacencia.Length;  // Número de estaciones
        List<Edge> aristas = new List<Edge>();  // Lista para almacenar las aristas

        // Paso 1: Crear una lista de todas las aristas con sus pesos
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)  // Evitar duplicar aristas, ya que la matriz es simétrica
            {
                if (matrizAdyacencia[i][j] != 0)  // Si hay una arista (peso != 0)
                {
                    aristas.Add(new Edge(i, j, matrizAdyacencia[i][j]));  // Guardamos la arista
                }
            }
        }

        // Paso 2: Ordenar las aristas por peso (de menor a mayor)
        aristas.Sort((a, b) => a.Peso.CompareTo(b.Peso));

        // Paso 3: Inicializar el conjunto disjunto
        DisjointSet ds = new DisjointSet(n);

        List<Edge> aem = new List<Edge>();  // Lista para el árbol de expansión mínima

        // Paso 4: Procesar las aristas en orden creciente
        foreach (var arista in aristas)
        {
            int root1 = ds.Find(arista.Estacion1);
            int root2 = ds.Find(arista.Estacion2);

            // Si no están en el mismo conjunto (no forman un ciclo), las unimos
            if (root1 != root2)
            {
                aem.Add(arista);  // Agregar la arista al AEM
                ds.Union(root1, root2);  // Unir los conjuntos de las estaciones
            }
        }

        // Mostrar el árbol de expansión mínima
        string resultado = "Árbol de Expansión Mínima (Kruskal):\n";
        foreach (var arista in aem)
        {
            resultado += $"Estación {Convert.ToChar('A' + arista.Estacion1)} - Estación {Convert.ToChar('A' + arista.Estacion2)} con peso {arista.Peso}\n";
        }

        // Mostrar toda la matriz de adyacencia
        string matrizTexto = "Matriz de Adyacencia:\n";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizTexto += matrizAdyacencia[i][j] + "\t";
            }
            matrizTexto += "\n";
        }

        // Mostrar todo en un solo MessageBox
        MessageBox.Show(resultado + "\n" + matrizTexto, "Resultado de Kruskal", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    // Clase que representa una arista
    public class Edge
    {
        public int Estacion1 { get; set; }
        public int Estacion2 { get; set; }
        public int Peso { get; set; }

        public Edge(int estacion1, int estacion2, int peso)
        {
            Estacion1 = estacion1;
            Estacion2 = estacion2;
            Peso = peso;
        }
    }

    // Clase para el conjunto disjunto (Union-Find)
    public class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i;  // Cada estación es su propio padre inicialmente
                rank[i] = 0;    // Inicializamos el rango en 0
            }
        }

        // Encontrar el representante del conjunto
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);  // Compresión de caminos
            }
            return parent[x];
        }

        // Unir dos conjuntos
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                // Unir los conjuntos, con el de mayor rango como raíz
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;  // Aumentar el rango
                }
            }
        }
    }



    // Función para Dijkstra (simplificado)
    // Función para Dijkstra (simplificado)
    public static void Dijkstra(int[][] matrizAdyacencia, int estacionInicio)
    {
        int n = matrizAdyacencia.Length;  // Número de estaciones
        int[] distancias = new int[n];  // Arreglo de distancias mínimas
        bool[] visitado = new bool[n];  // Arreglo para marcar las estaciones visitadas

        // Inicializamos las distancias: a la estación de inicio 0, a las demás infinito
        for (int i = 0; i < n; i++)
        {
            distancias[i] = int.MaxValue;  // Distancia infinita
            visitado[i] = false;  // Ninguna estación está visitada
        }
        distancias[estacionInicio] = 0;  // La distancia a la estación de inicio es 0

        // Ejecutamos el algoritmo de Dijkstra
        for (int i = 0; i < n - 1; i++)  // Se repite n-1 veces, ya que no necesitamos más
        {
            // Paso 1: Seleccionar la estación no visitada con la distancia más corta
            int u = -1;
            int distanciaMinima = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (!visitado[j] && distancias[j] < distanciaMinima)
                {
                    u = j;
                    distanciaMinima = distancias[j];
                }
            }

            // Marcar la estación u como visitada
            visitado[u] = true;

            // Paso 2: Actualizar las distancias de las estaciones vecinas
            for (int v = 0; v < n; v++)
            {
                // Si hay una arista entre u y v, y v no ha sido visitada
                if (matrizAdyacencia[u][v] != 0 && !visitado[v])
                {
                    int nuevaDistancia = distancias[u] + matrizAdyacencia[u][v];
                    if (nuevaDistancia < distancias[v])
                    {
                        distancias[v] = nuevaDistancia;  // Actualizamos la distancia mínima
                    }
                }
            }
        }

        // Mostrar las distancias mínimas desde la estación de inicio
        string resultado = $"Distancias mínimas desde la estación {Convert.ToChar('A' + estacionInicio)}:\n";
        for (int i = 0; i < n; i++)
        {
            if (distancias[i] == int.MaxValue)
            {
                resultado += $"Estación {Convert.ToChar('A' + i)}: Inalcanzable\n";
            }
            else
            {
                resultado += $"Estación {Convert.ToChar('A' + i)}: {distancias[i]}\n";
            }
        }

        // Mostrar toda la matriz de adyacencia
        string matrizTexto = "Matriz de Adyacencia:\n";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizTexto += matrizAdyacencia[i][j] + "\t";
            }
            matrizTexto += "\n";
        }

        // Mostrar todo en un solo MessageBox
        MessageBox.Show(resultado + "\n" + matrizTexto, "Resultado de Dijkstra", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


}

