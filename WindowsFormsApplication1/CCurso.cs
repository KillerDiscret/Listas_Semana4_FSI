using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CCurso
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public List<CAlumno> Alumnos { get; set; }
        public CCurso()
        {
            Alumnos = new List<CAlumno>();

        }


    }
}
