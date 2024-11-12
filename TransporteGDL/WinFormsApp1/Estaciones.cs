using Newtonsoft.Json.Linq;

internal class Estacion
{
    public static string RutaArchivoJson { get; set; } = "D:\\Porgramacion\\Materias\\Algoritmia\\SISTEUR\\TransporteGDL\\WinFormsApp1\\STPMG.json";

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

    public static List<Estacion> CargarDatos()
    {
        List<Estacion> estaciones = new List<Estacion>();

        if (File.Exists(RutaArchivoJson))
        {
            string jsonData = File.ReadAllText(RutaArchivoJson);
            JObject jsonObj = JObject.Parse(jsonData);

            var estacionesArray = jsonObj["Estaciones"] as JArray;

            if (estacionesArray != null)
            {
                estaciones = estacionesArray.Select(estacion => new Estacion(
                    (string?)estacion["Nombre"] ?? string.Empty,
                    estacion["Lineas"]?.Select(linea => (string?)linea ?? string.Empty).ToList() ?? new List<string>(),
                    (string?)estacion["ExtraCadena"] ?? string.Empty,
                    (int?)estacion["ExtraNumerico"] ?? 0
                )).ToList();
            }
        }
        else
        {
            MessageBox.Show($"No se encontró el archivo en la ruta: {RutaArchivoJson}");
        }

        return estaciones;
    }
}
