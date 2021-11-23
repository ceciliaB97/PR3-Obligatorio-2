﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Actividades")]
    public class Actividad
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Cupos { get; set; }
        [Required, Range(3,90)]
        public int EdadMinima { get; set; }

        [Required, Range(3, 90)]
        public int EdadMaxima { get; set; }

        public virtual List<Horario> ActividadHorarios { get; set; }

        [JsonIgnore]
        public virtual Membresia Membresia { get; set; }

        public static bool ValidarFechaHora (DateTime fechaHora)
        {
            if (fechaHora.Hour >= 7 && fechaHora.Hour <= 22)
            {
                return true;
            }

            return false;
        }
        [Index(IsUnique=true), MaxLength(30)]
        public string Nombre { get; set; }

        public bool Active { get; set; }

        //[ForeignKey("Horario")]
        //public int IdHorario { get; set; }
        //public virtual List<Horario> Horarios { get; set; }

    }
}
