using Estudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Estudiantes.DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Estudiante> Estudiante { get; set; }
		public DbSet<Seleccion> Seleccion { get; set; }
		public Contexto(): base("ConStr")
		{

		}
	}
}