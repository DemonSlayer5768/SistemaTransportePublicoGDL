using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


public class Estacion
{
    public string? Nombre { get; set; }
    public List<string> Lineas { get; set; }
    public List<string> Conexiones { get; set; }
    public int Marca { get; set; } // Añadimos un campo Marca para el contador.

    public Estacion(string? nombre, List<string> lineas, List<string> conexiones)
    {
        Nombre = nombre;
        Lineas = lineas;
        Conexiones = conexiones;
        Marca = 0;
    }
}

public class GrafoEstaciones
{
    public List<Estacion> Estaciones { get; set; } = new List<Estacion>();
    // private int contador = 0; // Contador global para la marca.

    // Método para agregar Estaciones al grafo
    public void AgregarEstacion(Estacion estacion)
    {
        Estaciones.Add(estacion);
    }

    // Método para agregar una conexión entre dos Estaciones
    public void AgregarConexion(Estacion estacion1, Estacion estacion2)
    {
        if (!estacion1.Conexiones.Contains(estacion2.Nombre ?? string.Empty))
        {
            estacion1.Conexiones.Add(estacion2.Nombre ?? string.Empty);
        }
        if (!estacion2.Conexiones.Contains(estacion1.Nombre ?? string.Empty))
        {
            estacion2.Conexiones.Add(estacion1.Nombre ?? string.Empty);
        }
    }

    // Método para obtener una estación por nombre
    public Estacion? ObtenerEstacion(string nombre)
    {
        return Estaciones.FirstOrDefault(e => e.Nombre == nombre);
    }
}

internal class SistemaTransporte
{
    public static string RutaArchivoJson { get; set; } = "STPMG.json";

    public static List<Estacion> CargarDatos()
    {
        List<Estacion> Estaciones = new List<Estacion>();

        if (File.Exists(RutaArchivoJson))
        {
            string jsonData = File.ReadAllText(RutaArchivoJson);
            JObject jsonObj = JObject.Parse(jsonData);

            var EstacionesArray = jsonObj["Estaciones"] as JArray;

            if (EstacionesArray != null)
            {
                Estaciones = EstacionesArray.Select(estacion => new Estacion(
                    (string?)estacion["Nombre"], // Nombre de la estación
                    estacion["Lineas"]?.Select(linea => (string?)linea ?? string.Empty).ToList() ?? new List<string>(),
                    estacion["Conexiones"]?.Select(conexion => (string?)conexion ?? string.Empty).ToList() ?? new List<string>()
                )).ToList();

            }
        }
        else
        {
            Console.WriteLine($"No se encontró el archivo en la ruta: {RutaArchivoJson}");
        }

        Console.WriteLine($"Estaciones cargadas: {Estaciones.Count}");
        return Estaciones;
    }

    // Método para agregar una conexión entre dos Estaciones
    public static void AgregarConexion(Estacion estacion1, Estacion estacion2)
    {
        if (!estacion1.Conexiones.Contains(estacion2.Nombre ?? string.Empty))
        {
            estacion1.Conexiones.Add(estacion2.Nombre ?? string.Empty);
        }
        if (!estacion2.Conexiones.Contains(estacion1.Nombre ?? string.Empty))
        {
            estacion2.Conexiones.Add(estacion1.Nombre ?? string.Empty);
        }
    }
}


//Método para construir la matriz de adyacencia
class Matriz
{

    public static void ConstruirMatrizAdyacencia(List<Estacion> EstacionesSeleccionadas)
    {
        int n = EstacionesSeleccionadas.Count;
        var matrizAdyacencia = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                bool compartenLinea = EstacionesSeleccionadas[i].Lineas.Intersect(EstacionesSeleccionadas[j].Lineas).Any();
                if (compartenLinea)
                {
                    matrizAdyacencia[i, j] = 1;
                    matrizAdyacencia[j, i] = 1;
                }
            }
        }

        // Convertir la matriz a texto para mostrar
        string matrizTexto = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrizTexto += matrizAdyacencia[i, j] + " ";
            }
            matrizTexto += Environment.NewLine;
        }

        // Mostrar la matriz en un MessageBox
        MessageBox.Show(matrizTexto, "Matriz de Adyacencia");
    }
}

