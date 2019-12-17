using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estudiantes.Entidades
{
	[Serializable]
	public class Materia
	{
		[Key]
		public int Id_Materia { get; set; }
		public int Id_Seleccion { get; set; }
		public string Nombre { get; set; }
		public decimal Puntos_Obtenidos { get; set; }
		
  
		[ForeignKey("Id_Seleccion")]
		public Seleccion Seleccion { get; set; }
		public Materia()
		{

		}
	}
}