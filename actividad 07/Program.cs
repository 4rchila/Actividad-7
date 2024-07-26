using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
var continuarMenu = true;
double opcionMenu = 0;

Console.WriteLine("Ingresa la cantidad de numeros que quieres utilizar:");
double numerosIngresados = double.Parse(Console.ReadLine());

List<double> listaNumeros = new List<double>();

Console.Clear();

for (double i = 0; i < numerosIngresados;i++) 
{
    Console.WriteLine($"Ingresa el nuemro: {i+1}");
    listaNumeros.Add(double.Parse(Console.ReadLine()));

}

//FUNCIONES
static double mediaNumeros(List<double> lista)
    {
    double sumaMedia = 0;
    double cantidadNumerosMedia = 0;
    foreach (double i in lista)
    {
         sumaMedia = sumaMedia + i;
         cantidadNumerosMedia++;
    }
        return sumaMedia/cantidadNumerosMedia;
    }

static double medianaNumeros(List<double> lista)
{
    var listaOrdenada = lista.OrderBy(n => n).ToList();

    int cantidad = listaOrdenada.Count;

    if (cantidad == 0)
    {
        throw new InvalidOperationException("La lista está vacía y no se puede calcular la mediana.");
    }

    if (cantidad % 2 == 0)
    {
        double valor1 = listaOrdenada[cantidad / 2 - 1];
        double valor2 = listaOrdenada[cantidad / 2];
        return (double)((valor1 + valor2) / 2.0);
    }
    else
    {
        return (double)listaOrdenada[cantidad / 2];
    }
}
static List<double> modaNumeros(List<double> lista)
{
    var frecuencia = new Dictionary<double, double>();

    foreach (double numero in lista)
        {
        if (frecuencia.ContainsKey(numero))
        {
            frecuencia[numero]++;
        }
        else
        {
            frecuencia[numero] = 1;
        }
    }

    double frecuenciaMaxima = frecuencia.Values.Max();

    var moda = frecuencia
        .Where(par => par.Value == frecuenciaMaxima)
        .Select(par => par.Key)
        .ToList();

    return moda;
}

static double desviacionEstandar(List<double> numeros)
{

    double media = numeros.Average();

    double sumaCuadrados = numeros.Sum(num => Math.Pow(num - media, 2));
    double varianza = sumaCuadrados / numeros.Count;

    double desviacionEstandar = Math.Sqrt(varianza);

    return desviacionEstandar;
}

while (continuarMenu)
    {
    try
    {
        Console.Clear();
        Console.WriteLine("--MENU--");
        Console.WriteLine("1. MEDIA");
        Console.WriteLine("2. MEDIANA");
        Console.WriteLine("3. MODA");
        Console.WriteLine("4. DESVIACION ESTANDAR");
        Console.WriteLine("5. SALIR");
        Console.WriteLine("\nElije una opcion: ");
        opcionMenu = double.Parse(Console.ReadLine());
    }catch (Exception ex) { Console.WriteLine(ex.Message);}
    switch (opcionMenu) 
    {
        case 1:
            Console.Clear();
            Console.WriteLine("La media de los numeros que ingreso es:") ;
            Console.WriteLine(mediaNumeros(listaNumeros));
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("La mediana de los numeros que ingreso es:");
            Console.WriteLine(medianaNumeros(listaNumeros));
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            List<double> moda = modaNumeros(listaNumeros);

            Console.WriteLine("La moda de los numeros que ingresaste es:");
            if (moda.Count > 0)
            {
                foreach (var num in moda)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("No hay moda (todos los valores tienen la misma frecuencia).");
            }
            Console.ReadKey();
       break;
        case 4:
            Console.Clear();
            Console.WriteLine("La desviacion estandar de los numeros que ingreso es:");
            Console.WriteLine(desviacionEstandar(listaNumeros));
            Console.ReadKey();
            break;
        case 5:
            Console.WriteLine("gracias por utilizar el programa");
            continuarMenu = false;
            break;
    }    

    }
