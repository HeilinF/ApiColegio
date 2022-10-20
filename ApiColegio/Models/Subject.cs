﻿using System.ComponentModel.DataAnnotations;

namespace ApiColegio.Models
{
    public class Subject
    {
       // public Materia()
       // {
          //  Estudiantes= new HashSet<Student>();
       //     Profesores = new HashSet<Profesor>();
       // }

        public int IdSubject { get; set; }
        public string Name { get; set; } = null!;
        //public string Level { get; set; }=null!;
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; }= null!;

        public virtual Teacher? Teacher { get; set; }
       // public virtual ICollection<Student> Estudiantes { get;}


    }
}