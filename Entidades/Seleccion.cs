using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estudiantes.Entidades
{
	[Serializable]
	public class Seleccion
	{
		[Key]
		public int Id_Seleccion { get; set; }
		public int Id_Estudiante { get; set; }
		public DateTime Fecha { get; set; }
		public virtual List<Materia> Detalle { get; set; }
		[ForeignKey("Id_Estudiante")]
		public virtual Estudiante Estudiante { get; set; }
		public Seleccion()
		{
			this.Fecha = DateTime.Now;
			this.Detalle = new List<Materia>();
		}
	}
}