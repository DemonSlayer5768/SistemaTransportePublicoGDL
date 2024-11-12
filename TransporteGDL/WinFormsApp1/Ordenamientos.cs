using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace My_FrmInicio

{
    internal class Ordenamientos
    {
        // Metodo para ordenar estaciones por nombre usando el algoritmo de ordenamiento por insercion
        public static void SortUsingInsertion(List<Estacion> estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

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

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Insercion: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenacion");
        }

        //Metodo para ordenar estaciones por nombre usando el algoritmo de ordenamiento por Burbuja
        public static void SortUsingBubbleSort(List<Estacion> estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            int n = estaciones.Count;
            bool intercambiado;

            // Iterar a través de la lista
            for (int i = 0; i < n - 1; i++)
            {
                intercambiado = false;

                // Comparar elementos adyacentes
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (String.Compare(estaciones[j].Nombre, estaciones[j + 1].Nombre) > 0)
                    {
                        // Intercambiar si están en el orden incorrecto
                        Estacion temp = estaciones[j];
                        estaciones[j] = estaciones[j + 1];
                        estaciones[j + 1] = temp;

                        intercambiado = true;
                    }
                }

                // Si no hubo intercambios, la lista ya está ordenada
                if (!intercambiado)
                    break;
            }

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por metodo Burbuja: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenación");
        }

        // Método para ordenar estaciones por nombre usando el algoritmo de ordenamiento por seleccion
        public static void SortUsingSelection(List<Estacion> estaciones)
        {
            // Iniciar el cronómetro
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < estaciones.Count - 1; i++)
            {
                // Suponemos que el primer elemento es el más pequeño
                int indiceMinimo = i;

                // Buscar el elemento más pequeño en la parte no ordenada
                for (int j = i + 1; j < estaciones.Count; j++)
                {
                    if (String.Compare(estaciones[j].Nombre, estaciones[indiceMinimo].Nombre) < 0)
                    {
                        indiceMinimo = j; // Actualizar el indice del elemento más pequeño
                    }
                }

                // Intercambiar el elemento más pequeño con el primer elemento no ordenado
                if (indiceMinimo != i)
                {
                    Estacion temp = estaciones[i];
                    estaciones[i] = estaciones[indiceMinimo];
                    estaciones[indiceMinimo] = temp;
                }
            }

            // Detener el cronómetro
            stopwatch.Stop();

            // Mostrar el tiempo que tardó el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Seleccion: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenación");
        }

        // Metodo para ordenar estaciones por nombre usando el algoritmo de ordenamiento por mezcla
        public static void SortUsingMerge(List<Estacion> estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Llamada al método recursivo de mezcla
            MergeSort(estaciones, 0, estaciones.Count - 1);

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Mezcla: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenación");
        }

        // Metodo auxiliar para realizar el ordenamiento por mezcla
        private static void MergeSort(List<Estacion> estaciones, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                // Encontrar el punto medio
                int medio = (izquierda + derecha) / 2;

                // Ordenar la mitad izquierda
                MergeSort(estaciones, izquierda, medio);
                // Ordenar la mitad derecha
                MergeSort(estaciones, medio + 1, derecha);

                // Mezclar las dos mitades
                Merge(estaciones, izquierda, medio, derecha);
            }
        }

        // Metodo para combinar dos subarreglos ordenados
        private static void Merge(List<Estacion> estaciones, int izquierda, int medio, int derecha)
        {
            // Calcular el tamaño de los subarreglos
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            // Crear arreglos temporales
            Estacion[] izquierdaArray = new Estacion[n1];
            Estacion[] derechaArray = new Estacion[n2];

            // Copiar datos a los arreglos temporales
            for (int i = 0; i < n1; i++)
                izquierdaArray[i] = estaciones[izquierda + i];
            for (int j = 0; j < n2; j++)
                derechaArray[j] = estaciones[medio + 1 + j];

            // Mezclar los arreglos temporales
            int k = izquierda;
            int iIndex = 0;
            int jIndex = 0;

            while (iIndex < n1 && jIndex < n2)
            {
                if (String.Compare(izquierdaArray[iIndex].Nombre, derechaArray[jIndex].Nombre) <= 0)
                {
                    estaciones[k] = izquierdaArray[iIndex];
                    iIndex++;
                }
                else
                {
                    estaciones[k] = derechaArray[jIndex];
                    jIndex++;
                }
                k++;
            }

            // Copiar los elementos restantes, si hay alguno
            while (iIndex < n1)
            {
                estaciones[k] = izquierdaArray[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                estaciones[k] = derechaArray[jIndex];
                jIndex++;
                k++;
            }
        }

        public static void SortUsingQuickSort(List<Estacion> estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Llamada inicial a Quicksort
            QuickSort(estaciones, 0, estaciones.Count - 1);

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Quicksort: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenacion");
        }

        // Funcion recursiva de Quicksort
        private static void QuickSort(List<Estacion> estaciones, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(estaciones, low, high);

                // Ordenar recursivamente las dos particiones
                QuickSort(estaciones, low, pivotIndex - 1);
                QuickSort(estaciones, pivotIndex + 1, high);
            }
        }

        // Método de particion
        //private static int Partition(List<Estacion> estaciones, int low, int high)
        //{
        //    Estacion pivot = estaciones[low];
        //    int i = low - 1;

        //    for (int j = low + 1; j <=  high; j++)
        //    {
        //        // Comparar el nombre de la estacion actual con el pivot
        //        if (String.Compare(estaciones[j].Nombre, pivot.Nombre) < 0)
        //        {
        //            Swap(estaciones, i, j);
        //            i++;
        //        }
        //    }

        //    //Swap(estaciones, i + 1, high);
        //    //return i + 1;
        //    Swap(estaciones, low, i - 1);
        //    return i - 1;
        //
        //}
        private static int Partition(List<Estacion> estaciones, int low, int high)
        {
            Estacion pivot = estaciones[low];
            int i = low;
            int j = low + 1;

            do
            {
                // Comparar el nombre de la estacion actual con el pivot
                if (String.Compare(estaciones[j].Nombre, pivot.Nombre) < 0)
                {
                    i++;
                    Swap(estaciones, i, j);
                }
                j++;
            } while (j <= high);

            // Intercambiar el pivote con el elemento en la posición i
            Swap(estaciones, low, i);
            return i;
        }



        // Metodo para intercambiar dos elementos en la lista
        private static void Swap(List<Estacion> estaciones, int i, int j)
        {   
            Estacion temp = estaciones[i];
            estaciones[i] = estaciones[j];
            estaciones[j] = temp;
        }


    }
}

