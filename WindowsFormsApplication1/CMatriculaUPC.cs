using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CMatriculaUPC
    {
        //se pone static para que no se pierdan los elementos cuando los cierres
        public static List<CCurso> Cursos { get; set; }
        public static List<CAlumno> ListaAlumnos { get; set; }

        public CMatriculaUPC()
        {
            if(Cursos==null)
            {
                Cursos = new List<CCurso>();

            }
            if(ListaAlumnos==null)
            {
                ListaAlumnos = new List<CAlumno>();
            }

          }
        public void InsertarCurso(CCurso curso)
        {
            Cursos.Add(curso);
        }

        public void InsertarAlumnoEnCurso(string cod_curso,CAlumno alumno)
        {
            CCurso curso_encontrado = Cursos.Find(delegate (CCurso value)
            {
                return value.Codigo == cod_curso;

            });
            if(curso_encontrado!=null)
            {
                curso_encontrado.Alumnos.Add(alumno);
            }
            if (!ListaAlumnos.Exists(delegate (CAlumno value)
                 {
                     return value.TIU == alumno.TIU;



                 }))
                ListaAlumnos.Add(alumno);
        }
        public List<CAlumno> ListarAlumnosDeCurso(string codcurso)
        {
            CCurso curso_encontrado = Cursos.Find(delegate (CCurso value)
            {
                return value.Codigo == codcurso;
            });
            if(curso_encontrado!=null)
            {
                return curso_encontrado.Alumnos;

            }
            else
            {
                return null;
            }
        }

        public CCurso DameCursoConMasAlumnos()
        {
            CCurso temp = new CCurso();
            foreach(CCurso curso in Cursos)
                if(curso.Alumnos.Count> temp.Alumnos.Count)
                
                    temp = curso;
     
                return temp;
        }

        public bool CursoExiste(string codcurso)
        {
            return Cursos.Exists(delegate(CCurso value)
            {
                return value.Codigo == codcurso;

            });
        }

        public List<CCurso> ListarCursosQueLlevaUnAlumno(int tiu)
        {
            List<CCurso> cursos_matriculados = new List<CCurso>();
            foreach (CCurso curso in Cursos)
                if (curso.Alumnos.Exists(delegate (CAlumno value)
                     {
                         return value.TIU == tiu;
                     }))
                    cursos_matriculados.Add(curso);
            return cursos_matriculados;
        }
        public List <CCurso> ListarCursosQueNoTienenAlumnos()
        {
            List<CCurso> cursos_sin_alumnos = new List<CCurso>();
            foreach (CCurso curso in Cursos)
                if (curso.Alumnos.Count == 0)
                    cursos_sin_alumnos.Add(curso);
            return cursos_sin_alumnos;
        }

        public CAlumno DameAlumnoConTIUMayor()
        {
            CAlumno temp = new CAlumno();
            temp.TIU = -1;
            foreach (CCurso curso in Cursos)
                foreach (CAlumno alumno in curso.Alumnos)
                    if (alumno.TIU > temp.TIU)
                        temp = alumno;
            return temp;
        }







    }
}
