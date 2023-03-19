using System;
using System.Collections.Generic;
using System.Text;
using SQLite; 

namespace P4EXAMEN119020051.Models
{
    public  class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Double Latitud { get; set; }
        public Double Longitud { get; set; }
        [MaxLength (200)]
        public String descripcion_larga { get; set; }
        [MaxLength(60)]
        public String descripcion_corta { get; set; }
    }
}
