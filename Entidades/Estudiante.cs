using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudiantes.Entidades
{
	[Serializable]
	public class Estudiante
	{
		[Key]
		public int Id_Estudiante { get; set; }
		public string Nombre { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Total_Puntos { get; set; }

		public Estudiante()
		{
			this.Fecha = DateTime.Now;	
		}
	}
}