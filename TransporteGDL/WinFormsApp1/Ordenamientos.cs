using System;
using System.Collections.Generic;

namespace My_FrmInicio

{
    internal class Ordenamientos
    {
        // Método para ordenar estaciones por nombre usando el algoritmo de ordenamiento por inserción
        public static void OrdenarPorInsercion(List<Estacion> estaciones)
        {
            MessageBox.Show("si llego");
            for (int i = 1; i < estaciones.Count; i++)
            {
                Estacion clave = estaciones[i];
                int j = i - 1;

                // Comparar y mover elementos que son mayores que la clave
                while (j >= 0 && String.Compare(estaciones[j].Nombre, clave.Nombre) > 0)
                {
                    estaciones[j + 1] = estaciones[j]; // Mover el elemento hacia adelante
                    j--;
                }
                estaciones[j + 1] = clave; // Insertar la clave en su posición correcta
            }
        }
    }
}
