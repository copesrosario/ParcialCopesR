using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialCopesR
{
    public struct Cono
    {
        public double Radio { get; private set; }
        public double Altura { get; private set; }

        public Cono(double radio, double altura)
        {
            Radio = radio;
            Altura = altura;
        }

        public void AsignarValores(double radio, double altura)
        {
            Radio = radio;
            Altura = altura;
        }

        public (double radio, double altura) ObtenerValores()
        {
            return (Radio, Altura);
        }

        public double CalcularVolumen()
        {
            return Math.PI * Math.Pow(Radio, 2) * Altura / 3;
        }

        public double CalcularArea()
        {
            double generatriz = Math.Sqrt(Math.Pow(Radio, 2) + Math.Pow(Altura, 2));
            return Math.PI * Radio * (Radio + generatriz);
        }

        public double CalcularDiagonal()
        {
            return Math.Sqrt(Math.Pow(Radio, 2) + Math.Pow(Altura, 2));
        }

        public bool ValidarValores()
        {
            return Radio > 0 && Altura > 0;
        }

        public void MostrarDatos()
        {
            if (ValidarValores())
            {
                Console.WriteLine($"Radio: {Radio}");
                Console.WriteLine($"Altura: {Altura}");
                Console.WriteLine($"Volumen: {CalcularVolumen()}");
                Console.WriteLine($"Área: {CalcularArea()}");
                Console.WriteLine($"Diagonal: {CalcularDiagonal()}");
            }
            else
            {
                Console.WriteLine("Los valores del cono no son válidos.");
            }
        }
    }
}