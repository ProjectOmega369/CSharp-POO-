using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula06102025
{
    public class Circulo
    {
        public double Raio { get; set; }

        public double CalcularRaio()
        {
            return Math.PI * Raio * 2;
        }

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }
    }
}
