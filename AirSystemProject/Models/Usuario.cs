using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSystemProject.Models
{
    class Usuario
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string confirmarSenha { get; set; }
    }
}
