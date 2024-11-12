using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WinFormsApp1
{
    // Clase que representa una estación
    internal class Estacion
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

    // Clase para manejar estaciones y cargar datos desde un archivo JSON
    internal class Estaciones
    {
        public List<Estacion> ListaEstaciones { get; private set; }

        public Estaciones()
        {
            ListaEstaciones = new List<Estacion>();
        }

        /// <summary>
        /// Carga estaciones desde un archivo JSON especificado.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo JSON.</param>
        public void CargarDesdeJson(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException($"No se encontró el archivo en la ruta: {rutaArchivo}");
            }

            try
            {
                string contenidoJson = File.ReadAllText(rutaArchivo);
                JObject jsonObj = JObject.Parse(contenidoJson);

                var estacionesArray = jsonObj["Estaciones"] as JArray;
                if (estacionesArray != null)
                {
                    ListaEstaciones = estacionesArray.Select(estacion => new Estacion(
                        (string?)estacion["Nombre"] ?? string.Empty,
                        estacion["Lineas"]?.Select(linea => (string?)linea ?? string.Empty).ToList() ?? new List<string>(),
                        (string?)estacion["ExtraCadena"] ?? string.Empty,
                        (int?)estacion["ExtraNumerico"] ?? 0
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar datos del archivo JSON: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene una lista de todas las líneas únicas.
        /// </summary>
        /// <returns>Lista de líneas únicas.</returns>
        public List<string> ObtenerLineasUnicas()
        {
            return ListaEstaciones.SelectMany(est => est.Lineas).Distinct().OrderBy(linea => linea).ToList();
        }
    }
}
