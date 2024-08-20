
namespace ParcialCopesR
{
    class Programa
    {
        static Cono[] conos = new Cono[10];
        static int indice = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Ingresar cono");
                Console.WriteLine("2. Mostrar datos de los conos");
                Console.WriteLine("3. Modificar datos de un cono");
                Console.WriteLine("4. Mostrar estadísticas");
                Console.WriteLine("5. Mostrar conos con volumen inferior al promedio");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarCono();
                        break;
                    case "2":
                        MostrarDatosConos();
                        break;
                    case "3":
                        ModificarCono();
                        break;
                    case "4":
                        MostrarEstadisticas();
                        break;
                    case "5":
                        MostrarConosInferioresAlPromedio();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void IngresarCono()
        {
            if (IndiceLleno())
            {
                Console.WriteLine("El array de conos está lleno.");
                return;
            }

            Console.WriteLine("Ingrese el radio del cono:");
            double radio = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la altura del cono:");
            double altura = double.Parse(Console.ReadLine());

            Cono cono = new Cono();
            cono.AsignarValores(radio, altura);

            if (cono.ValidarValores())
            {
                conos[indice] = cono;
                indice++;
                Console.WriteLine("Cono ingresado con éxito.");
            }
            else
            {
                Console.WriteLine("Valores del cono no válidos.");
            }
        }

        static bool IndiceLleno()
        {
            return indice >= conos.Length;
        }

        static void MostrarDatosConos()
        {
            if (IndiceVacío())
            {
                Console.WriteLine("No hay conos en el array.");
                return;
            }

            Console.WriteLine("Datos de los conos:");
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine($"Cono {i + 1}:");
                conos[i].MostrarDatos();
                Console.WriteLine();
            }
        }

        static bool IndiceVacío()
        {
            return indice == 0;
        }

        static void ModificarCono()
        {
            if (IndiceVacío())
            {
                Console.WriteLine("No hay conos para modificar.");
                return;
            }

            Console.WriteLine("Ingrese el número del cono que desea modificar (1 a {0}):", indice);
            int numero = int.Parse(Console.ReadLine()) - 1;

            if (numero < 0 || numero >= indice)
            {
                Console.WriteLine("Número de cono inválido.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo radio del cono:");
            double radio = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la nueva altura del cono:");
            double altura = double.Parse(Console.ReadLine());

            Cono cono = conos[numero];
            cono.AsignarValores(radio, altura);

            if (cono.ValidarValores())
            {
                conos[numero] = cono;
                Console.WriteLine("Cono modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Valores del cono no válidos.");
            }
        }

        static void MostrarEstadisticas()
        {
            if (IndiceVacío())
            {
                Console.WriteLine("No hay conos para mostrar estadísticas.");
                return;
            }

            double[] volúmenes = new double[indice];
            for (int i = 0; i < indice; i++)
            {
                volúmenes[i] = conos[i].CalcularVolumen();
            }

            double volumenMaximo = volúmenes.Max();
            double volumenMinimo = volúmenes.Min();
            double promedioVolúmenes = volúmenes.Average();

            Console.WriteLine($"Volumen máximo: {volumenMaximo}");
            Console.WriteLine($"Volumen mínimo: {volumenMinimo}");
            Console.WriteLine($"Promedio de volúmenes: {promedioVolúmenes}");
        }

        static void MostrarConosInferioresAlPromedio()
        {
            if (IndiceVacío())
            {
                Console.WriteLine("No hay conos para mostrar.");
                return;
            }

            double promedioVolúmenes = conos.Select(c => c.CalcularVolumen()).Average();

            Console.WriteLine($"Conos con volumen inferior al promedio ({promedioVolúmenes}):");
            for (int i = 0; i < indice; i++)
            {
                double volumen = conos[i].CalcularVolumen();
                if (volumen < promedioVolúmenes)
                {
                    Console.WriteLine($"Cono {i + 1}: Volumen: {volumen}");
                }
            }
        }
    }
}