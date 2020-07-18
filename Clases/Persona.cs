using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Clases
{
    public abstract class Persona
    {
        //Atributos
        public int id;
        public string cedula;
        public string nombre;
        public string telefono;
        public string email;

        //Metodos
        public abstract DataTable LlenarGrid();
        
    }
}
