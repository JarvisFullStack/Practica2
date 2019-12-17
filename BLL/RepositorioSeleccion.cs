using Estudiantes.DAL;
using Estudiantes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Estudiantes.BLL
{
	public class RepositorioSeleccion : RepositorioBase<Seleccion>
	{
		RepositorioBase<Estudiante> rEstudiante = new RepositorioBase<Estudiante>();
		public override Seleccion Buscar(int id)
		{
			Seleccion seleccion;
			Contexto contexto = new Contexto();
			try
			{		
				seleccion = contexto.Seleccion.Include("Detalle").Where(x => x.Id_Seleccion == id).FirstOrDefault();				
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return seleccion;	
		}

		public override List<Seleccion> GetList(Expression<Func<Seleccion, bool>> expression)
		{
			List<Seleccion> lista = new List<Seleccion>();
			Contexto contexto = new Contexto();
			try
			{
				lista = contexto.Seleccion.Include("Detalle").Where(expression).ToList();
				foreach(var item in lista)
				{
					item.Detalle = item.Detalle.ToList();
				}
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return lista;
		}

		public override bool Eliminar(int id)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			try
			{
				Seleccion seleccion = contexto.Seleccion.Find(id);
				if (seleccion == null)
					return paso;
				Estudiante estudiante = this.rEstudiante.Buscar(seleccion.Id_Estudiante);
				foreach(var item in seleccion.Detalle.ToList())
				{
					estudiante.Total_Puntos -= item.Puntos_Obtenidos;
				}
				if (this.rEstudiante.Modificar(estudiante))
					return base.Eliminar(id);
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;

		}

		public override bool Guardar(Seleccion entidad)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			Estudiante estudiante = this.rEstudiante.Buscar(entidad.Id_Estudiante);
			try
			{
				foreach(var item in entidad.Detalle.ToList())
				{
					estudiante.Total_Puntos += item.Puntos_Obtenidos;
				}
				if (this.rEstudiante.Modificar(estudiante))
					return base.Guardar(entidad);
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;
		}


		public override bool Modificar(Seleccion entidad)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			Estudiante estudiante = this.rEstudiante.Buscar(entidad.Id_Estudiante);
			Seleccion seleccionA = this.Buscar(entidad.Id_Seleccion);
			try
			{
				using (Contexto contextoA = new Contexto())
				{
					foreach(var item in seleccionA.Detalle.ToList())
					{
						if(!entidad.Detalle.Exists(x=>x.Id_Seleccion == item.Id_Seleccion))
						{
							estudiante.Total_Puntos -= item.Puntos_Obtenidos;
						}
						contextoA.Entry(item).State = System.Data.Entity.EntityState.Deleted;
					}
					contextoA.SaveChanges();
				}

				foreach(var item in entidad.Detalle.ToList())
				{
					var estado = EntityState.Unchanged;
					if(item.Id_Materia == 0)
					{
						estudiante.Total_Puntos += item.Puntos_Obtenidos;
						estado = EntityState.Added;
					}
					contexto.Entry(item).State = estado;
				}
				contexto.Entry(entidad).State = EntityState.Modified;
				paso = contexto.SaveChanges() > 0;
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;

		}
	}
}