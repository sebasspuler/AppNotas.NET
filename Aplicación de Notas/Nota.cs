using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicación_de_Notas
{
    public class Nota
    {
        public string Titulo { get; set; }

        public string Notas { get; set; }

        public Nota()
        {

        }

        public Nota(string titulo, string notas)
        {
            Titulo = titulo;
            Notas = notas;
        }
    }
}
