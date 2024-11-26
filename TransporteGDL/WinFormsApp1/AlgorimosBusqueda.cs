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


    // Función para el algoritmo de Prim
    public static List<string> Prim(GrafoEstaciones grafo, string inicio, string destino)
    {
        var arbolExpansion = new List<string>(); // Lista para almacenar el recorrido del árbol de expansión
        var visitados = new HashSet<string>();   // Conjunto para marcar las Estaciones visitadas
        var colasPrioridad = new SortedSet<(int, string)>(Comparer<(int, string)>.Create((x, y) => x.Item1 == y.Item1 ? x.Item2.CompareTo(y.Item2) : x.Item1.CompareTo(y.Item1)));

        // Empezamos desde la estación de inicio
        visitados.Add(inicio);
        arbolExpansion.Add(inicio);

        // Se añaden las conexiones de la estación de inicio con peso 1
        foreach (var vecino in grafo.ObtenerEstacion(inicio)?.Conexiones ?? new List<string>())
        {
            colasPrioridad.Add((1, vecino)); // Agregar vecinos con peso 1
        }

        while (colasPrioridad.Count > 0)
        {
            // Tomamos la estación con el menor peso (más cercano)
            var (peso, estacion) = colasPrioridad.First();
            colasPrioridad.Remove((peso, estacion));

            // Si no hemos visitado la estación, la visitamos
            if (!visitados.Contains(estacion))
            {
                visitados.Add(estacion);
                arbolExpansion.Add(estacion);

                // Si llegamos al destino, terminamos la búsqueda
                if (estacion == destino)
                {
                    Console.WriteLine(string.Join(" -> ", arbolExpansion)); // Mostrar el recorrido
                    break; // Detener la búsqueda
                }

                // Agregamos las conexiones de la estación actual al conjunto de prioridades
                foreach (var vecino in grafo.ObtenerEstacion(estacion)?.Conexiones ?? new List<string>())
                {
                    if (!visitados.Contains(vecino))
                    {
                        colasPrioridad.Add((1, vecino)); // Añadimos el peso constante
                    }
                }
            }
        }

        return arbolExpansion;
    }



    // Función para el algoritmo de Kruskal
    public static List<(string, string)> Kruskal(GrafoEstaciones grafo)
    {
        var aristas = new List<(string, string, int)>();
        foreach (var estacion in grafo.Estaciones)
        {
            foreach (var conexion in estacion.Conexiones)
            {
                aristas.Add((estacion.Nombre ?? string.Empty, conexion, 1)); // Agregamos la conexión con un peso de 1
            }
        }

        // Ordenamos las aristas por peso
        aristas.Sort((a, b) => a.Item3.CompareTo(b.Item3));

        var conjuntoDisjoint = new Dictionary<string, string>(); // Estructura para encontrar el conjunto (conjunto disjunto)
        foreach (var estacion in grafo.Estaciones)
        {
            conjuntoDisjoint[estacion.Nombre ?? string.Empty] = estacion.Nombre ?? string.Empty; // Inicializamos cada estación como su propio representante
        }

        // Función para encontrar el representante de un conjunto
        string Buscar(string estacion)
        {
            if (conjuntoDisjoint[estacion] != estacion)
            {
                conjuntoDisjoint[estacion] = Buscar(conjuntoDisjoint[estacion]);
            }
            return conjuntoDisjoint[estacion];
        }

        // Función para unir dos conjuntos
        void Unir(string estacion1, string estacion2)
        {
            var raiz1 = Buscar(estacion1);
            var raiz2 = Buscar(estacion2);
            if (raiz1 != raiz2)
            {
                conjuntoDisjoint[raiz1] = raiz2;
            }
        }

        // Algoritmo de Kruskal
        var arbolExpansión = new List<(string, string)>();
        foreach (var arista in aristas)
        {
            if (Buscar(arista.Item1) != Buscar(arista.Item2))
            {
                Unir(arista.Item1, arista.Item2);
                arbolExpansión.Add((arista.Item1, arista.Item2));
            }
        }

        // Imprimir las conexiones
        foreach (var arista in arbolExpansión)
        {
            Console.WriteLine($"{arista.Item1} -> {arista.Item2}");
        }

        return arbolExpansión;
    }


    // Función para Dijkstra (simplificado)
    public static List<string> Dijkstra(GrafoEstaciones grafo, string inicio, string destino)
    {
        var distancias = new Dictionary<string, int>(); // Almacena la distancia más corta desde el inicio a cada estación
        var padres = new Dictionary<string, string>(); // Almacena la estación previa para reconstruir el camino
        var visitados = new HashSet<string>(); // Conjunto de Estaciones visitadas
        var cola = new SortedSet<(int distancia, string estacion)>(); // Cola de prioridad con las Estaciones y sus distancias

        // Inicializar distancias y agregar la estación de inicio
        foreach (var estacion in grafo.Estaciones)
        {
            string nombreEstacion = estacion.Nombre ?? string.Empty; // Si el nombre es null, asignamos una cadena vacía
            if (string.IsNullOrEmpty(nombreEstacion))
            {
                Console.WriteLine("Advertencia: Se encontró una estación con un nombre vacío o nulo.");
                continue; // Saltamos esta estación si el nombre es inválido
            }
            distancias[nombreEstacion] = int.MaxValue; // Asignamos un valor inicial infinito
        }

        if (!distancias.ContainsKey(inicio) || !distancias.ContainsKey(destino))
        {
            Console.WriteLine("Error: La estacion de inicio o destino no se encuentra en el grafo.");
            return new List<string>(); // Si no se encuentran las Estaciones, devolvemos una lista vacía
        }

        distancias[inicio] = 0; // La distancia al nodo inicial es 0
        cola.Add((0, inicio)); // Añadimos la estación de inicio a la cola

        while (cola.Count > 0)
        {
            // Extraemos la estación con la distancia más corta
            var (distancia, estacionActual) = cola.Min;
            cola.Remove(cola.Min);

            if (estacionActual == destino)
            {
                // Si hemos llegado al destino, podemos reconstruir el camino
                var camino = new List<string>();
                string actual = destino;
                while (actual != null)
                {
                    camino.Insert(0, actual); // Insertamos al inicio del camino
                    if (padres.ContainsKey(actual))
                    {
                        actual = padres[actual];
                    }
                    else
                    {
                        break;
                    }
                }

                // Imprimir el camino más corto
                Console.WriteLine("Camino más corto:");
                Console.WriteLine(string.Join(" -> ", camino)); // Imprime el camino aquí
                return camino; // Devolvemos el camino
            }

            // Marcamos la estación actual como visitada
            visitados.Add(estacionActual);

            // Exploramos las conexiones (vecinos)
            foreach (var vecino in grafo.ObtenerEstacion(estacionActual)?.Conexiones ?? new List<string>())
            {
                if (!visitados.Contains(vecino))
                {
                    var nuevaDistancia = distancias[estacionActual] + 1; // Suponemos que todas las conexiones tienen peso 1
                    if (nuevaDistancia < distancias[vecino])
                    {
                        distancias[vecino] = nuevaDistancia;
                        padres[vecino] = estacionActual; // Guardamos el camino para reconstruirlo
                        cola.Add((nuevaDistancia, vecino)); // Añadimos el vecino a la cola de prioridad
                    }
                }
            }
        }

        // Si no se encuentra el destino
        Console.WriteLine("No se pudo encontrar un camino.");
        return new List<string>(); // Devolvemos una lista vacía si no se encuentra el camino
    }

}

