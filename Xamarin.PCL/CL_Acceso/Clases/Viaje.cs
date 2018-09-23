using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace CL_Acceso.Clases
{
    public class Viaje
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(130)]
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({FechaInicio:d} - {FechaFin:d})";
        }
    }
}