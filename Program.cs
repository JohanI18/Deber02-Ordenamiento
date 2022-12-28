namespace Deber02_Ordenamiento;
class Program
{
    static void Main1(string[] args)
    {
        int choose = -1;
        DateTime startTime, finishTime;
        int n = askLeght();
        int[] array = fillArray(n);
        while (choose != 0)
        {
            Console.WriteLine("\t\t Menu \t");
            Console.WriteLine("\t 1.Crear un nuevo array \t");
            Console.WriteLine("\t 2.Ordenamiento burbuja \t");
            Console.WriteLine("\t 3.Ordenamiento por seleccion \t");
            Console.WriteLine("\t 4.Ordenamiento por insercion \t");
            Console.WriteLine("\t 5.Ordenamiento por Quicksort \t");
            Console.WriteLine("\t 0.Salir \t");
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    n = askLeght();
                    Array.Resize(ref array, n);
                    array = fillArray(n);
                    break;
                case 2:
                    Console.WriteLine("Ordenamiento burbuja");
                    int[] arrayBubble = (int[])array.Clone();
                    Console.WriteLine("arrelgo desordenado");
                    printArray(array);
                    startTime= DateTime.Now;
                    BubbleSort(arrayBubble);
                    finishTime= DateTime.Now;
                    Console.WriteLine("arrelgo ordenado");
                    printArray(arrayBubble);
                    int millisecondsBubble= (finishTime-startTime).Milliseconds;
                    Console.WriteLine("El tiempo tomado de ejecucion fue de: {0} milisegundos", millisecondsBubble);
                    wait();
                    break;
                case 3:
                    Console.WriteLine("Ordenamiento por seleccion");
                    int[] arraySelection = (int[])array.Clone();
                    Console.WriteLine("arrelgo desordenado");
                    printArray(array);
                    startTime= DateTime.Now;
                    SelectionSort(arraySelection);
                    finishTime= DateTime.Now;
                    Console.WriteLine("arrelgo ordenado");
                    printArray(arraySelection);
                    int millisecondsSelection= (finishTime-startTime).Milliseconds;
                    Console.WriteLine("El tiempo tomado de ejecucion fue de: {0} milisegundos", millisecondsSelection);
                    wait();
                    break;
                case 4:
                    Console.WriteLine("Ordenamiento por insercion");
                    int[] arrayInsertion = (int[])array.Clone();
                    Console.WriteLine("arrelgo desordenado");
                    printArray(array);
                    startTime= DateTime.Now;
                    InsertionSort(arrayInsertion);
                    finishTime= DateTime.Now;
                    Console.WriteLine("arrelgo ordenado");
                    printArray(arrayInsertion);
                    int millisecondsInsertion = (finishTime-startTime).Milliseconds;
                    Console.WriteLine("El tiempo tomado de ejecucion fue de: {0} milisegundos", millisecondsInsertion);
                    wait();
                    break;
                case 5:
                    Console.WriteLine("Ordenamiento por Quicksort");
                    int[] arrayQuicksort = (int[])array.Clone();
                    Console.WriteLine("arrelgo desordenado");
                    printArray(array);
                    startTime= DateTime.Now;
                    quickSort(arrayQuicksort, 0, n - 1);
                    finishTime= DateTime.Now;
                    Console.WriteLine("arrelgo ordenado");
                    printArray(arrayQuicksort);
                    int millisecondsQuicksort = (finishTime-startTime).Milliseconds;
                    Console.WriteLine("El tiempo tomado de ejecucion fue de: {0} milisegundos", millisecondsQuicksort);
                    wait();
                    break;
                case 0:
                    Console.WriteLine("Adios");
                    break;
                default:
                    Console.WriteLine("Ingrese un numero valido");
                    break;
            }
        }
    }

    public static void quickSort(int[] array, int first, int last)
    {
        int i, j, middle;
        double pivot;
        middle = (first + last) / 2;
        pivot = array[middle];
        i = first;
        j = last;
        do
        {
            while (array[i] < pivot) i++;
            while (array[j] > pivot) j--;
            if (i <= j)
            {
                int temp;
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        } while (i <= j);
        if (first < j)
        {
            quickSort(array, first, j);
        }
        if (i < last)
        {
            quickSort(array, i, last);
        }
    }

    public static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int temp = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > temp)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = temp;
        }
    }

    public static void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int temp = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[temp])
                {
                    temp = j;
                }
            }
            int var = array[i];
            array[i] = array[temp];
            array[temp] = var;
        }
    }

    public static void BubbleSort(int[] array)
    {
        bool flag;
        do
        {
            flag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    flag = true;
                }
            }
        } while (flag);
    }

    public static void printArray(int[] array)
    {
        Console.Write("A = {");
        foreach (int i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("}");
    }

    static int askLeght()
    {
        Console.WriteLine("Ingrese la longitud del array");
        string input = Console.ReadLine();
        int value;
        while (!int.TryParse(input, out value))
        {
            Console.WriteLine("Ingrese un numero valido");
            input = Console.ReadLine();
        }
        return int.Parse(input);
    }

    static void wait()
    {
        Console.WriteLine("Precione una tecla para continuar");
        ConsoleKeyInfo key = Console.ReadKey(false);
    }

    static int[] fillArray(int n)
    {
        int[] array = new int[n];
        int k = 0;
        foreach (int i in array)
        {
            Console.WriteLine("Ingrese el valor {0} del arrelgo", (k + 1));
            string input = Console.ReadLine();
            int value;
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("Ingrese un numero valido");
                input = Console.ReadLine();
            }
            array[k] = int.Parse(input);
            k++;
        }
        return array;
    }
}
