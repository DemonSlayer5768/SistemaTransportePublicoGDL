using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace My_FrmInicio

{
    internal class Ordenamientos
    {
        // Metodo para ordenar Estaciones por Estaciones usando el algoritmo de ordenamiento por insercion
        public static void SortUsingInsertion(List<Estacion> Estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 1; i < Estaciones.Count; i++)
            {
                Estacion clave = Estaciones[i];
                int j = i - 1;

                // Comparar y mover elementos que son mayores que la clave
                while (j >= 0 && String.Compare(Estaciones[j].Nombre, clave.Nombre) > 0)
                {
                    Estaciones[j + 1] = Estaciones[j]; // Mover el elemento hacia adelante
                    j--;
                }
                Estaciones[j + 1] = clave; // Insertar la clave en su posición correcta
            }

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Insercion: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenacion");
        }

        //Metodo para ordenar Estaciones por Estaciones usando el algoritmo de ordenamiento por Burbuja
        public static void SortUsingBubbleSort(List<Estacion> Estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            int n = Estaciones.Count;
            bool intercambiado;

            // Iterar a través de la lista
            for (int i = 0; i < n - 1; i++)
            {
                intercambiado = false;

                // Comparar elementos adyacentes
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (String.Compare(Estaciones[j].Nombre, Estaciones[j + 1].Nombre) > 0)
                    {
                        // Intercambiar si están en el orden incorrecto
                        Estacion temp = Estaciones[j];
                        Estaciones[j] = Estaciones[j + 1];
                        Estaciones[j + 1] = temp;

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

        // Método para ordenar Estaciones por Estaciones usando el algoritmo de ordenamiento por seleccion
        public static void SortUsingSelection(List<Estacion> Estaciones)
        {
            // Iniciar el cronómetro
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Estaciones.Count - 1; i++)
            {
                // Suponemos que el primer elemento es el más pequeño
                int indiceMinimo = i;

                // Buscar el elemento más pequeño en la parte no ordenada
                for (int j = i + 1; j < Estaciones.Count; j++)
                {
                    if (String.Compare(Estaciones[j].Nombre, Estaciones[indiceMinimo].Nombre) < 0)
                    {
                        indiceMinimo = j; // Actualizar el indice del elemento más pequeño
                    }
                }

                // Intercambiar el elemento más pequeño con el primer elemento no ordenado
                if (indiceMinimo != i)
                {
                    Estacion temp = Estaciones[i];
                    Estaciones[i] = Estaciones[indiceMinimo];
                    Estaciones[indiceMinimo] = temp;
                }
            }

            // Detener el cronómetro
            stopwatch.Stop();

            // Mostrar el tiempo que tardó el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Seleccion: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenación");
        }

        // Metodo para ordenar Estaciones por Estaciones usando el algoritmo de ordenamiento por mezcla
        public static void SortUsingMerge(List<Estacion> Estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Llamada al método recursivo de mezcla
            MergeSort(Estaciones, 0, Estaciones.Count - 1);

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Mezcla: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenación");
        }

        // Metodo auxiliar para realizar el ordenamiento por mezcla
        private static void MergeSort(List<Estacion> Estaciones, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                // Encontrar el punto medio
                int medio = (izquierda + derecha) / 2;

                // Ordenar la mitad izquierda
                MergeSort(Estaciones, izquierda, medio);
                // Ordenar la mitad derecha
                MergeSort(Estaciones, medio + 1, derecha);

                // Mezclar las dos mitades
                Merge(Estaciones, izquierda, medio, derecha);
            }
        }

        // Metodo para combinar dos subarreglos ordenados
        private static void Merge(List<Estacion> Estaciones, int izquierda, int medio, int derecha)
        {
            // Calcular el tamaño de los subarreglos
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            // Crear arreglos temporales
            Estacion[] izquierdaArray = new Estacion[n1];
            Estacion[] derechaArray = new Estacion[n2];

            // Copiar datos a los arreglos temporales
            for (int i = 0; i < n1; i++)
                izquierdaArray[i] = Estaciones[izquierda + i];
            for (int j = 0; j < n2; j++)
                derechaArray[j] = Estaciones[medio + 1 + j];

            // Mezclar los arreglos temporales
            int k = izquierda;
            int iIndex = 0;
            int jIndex = 0;

            while (iIndex < n1 && jIndex < n2)
            {
                if (String.Compare(izquierdaArray[iIndex].Nombre, derechaArray[jIndex].Nombre) <= 0)
                {
                    Estaciones[k] = izquierdaArray[iIndex];
                    iIndex++;
                }
                else
                {
                    Estaciones[k] = derechaArray[jIndex];
                    jIndex++;
                }
                k++;
            }

            // Copiar los elementos restantes, si hay alguno
            while (iIndex < n1)
            {
                Estaciones[k] = izquierdaArray[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                Estaciones[k] = derechaArray[jIndex];
                jIndex++;
                k++;
            }
        }
        //QuickSort
        public static void SortUsingQuickSort(List<Estacion> Estaciones)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Llamada inicial a Quicksort
            QuickSort(Estaciones, 0, Estaciones.Count - 1);

            // Detener el cronometro
            stopwatch.Stop();

            // Mostrar el tiempo que tardo el algoritmo
            MessageBox.Show($"Tiempo de ordenacion por Quicksort: {stopwatch.ElapsedMilliseconds} ms", "Tiempo de Ordenacion");
        }

        // Funcion recursiva de Quicksort
        private static void QuickSort(List<Estacion> Estaciones, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(Estaciones, low, high);

                // Ordenar recursivamente las dos particiones
                QuickSort(Estaciones, low, pivotIndex - 1);
                QuickSort(Estaciones, pivotIndex + 1, high);
            }
        }

        //partition
        private static int Partition(List<Estacion> Estaciones, int low, int high)
        {
            // Iniciar el cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();
            Estacion pivot = Estaciones[low];
            int i = low;
            int j = low + 1;

            do
            {
                // Comparar el Estaciones de la estacion actual con el pivot
                if (String.Compare(Estaciones[j].Nombre, pivot.Nombre) < 0)
                {
                    i++;
                    Swap(Estaciones, i, j);
                }
                j++;
            } while (j <= high);

            // Intercambiar el pivote con el elemento en la posición i
            Swap(Estaciones, low, i);
            return i;
        }



        // Metodo para intercambiar dos elementos en la lista
        private static void Swap(List<Estacion> Estaciones, int i, int j)
        {
            Estacion temp = Estaciones[i];
            Estaciones[i] = Estaciones[j];
            Estaciones[j] = temp;
        }


    }
}

