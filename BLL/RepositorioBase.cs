using Estudiantes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Estudiantes.BLL
{
	public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
	{
		public virtual T Buscar(int id)
		{
			T entidad;
			Contexto contexto = new Contexto();
			try
			{
				entidad = contexto.Set<T>().Find(id);
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return entidad;
		}

		public virtual void Dispose()
		{
			this.Dispose();
		}

		public virtual bool Eliminar(int id)
		{
			bool paso = false;
			Contexto contexto = new Contexto();			
			try
			{
				T entity = contexto.Set<T>().Find(id);
				contexto.Set<T>().Remove(entity);
				paso = contexto.SaveChanges() > 0;
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;
		}

		public virtual List<T> GetList(Expression<Func<T, bool>> expression)
		{
			Contexto contexto = new Contexto();
			List<T> lista = new List<T>();
			try
			{
				lista = contexto.Set<T>().Where(expression).ToList();
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return lista;
		}

		public virtual bool Guardar(T entidad)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			try
			{
				if(contexto.Set<T>().Add(entidad) != null)
					paso = contexto.SaveChanges() > 0;
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;
		}

		public virtual bool Modificar(T entidad)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			try
			{
				contexto.Entry<T>(entidad).State = System.Data.Entity.EntityState.Modified;
				paso = contexto.SaveChanges() > 0;
			}
			catch (Exception) { throw; }
			finally { contexto.Dispose(); }
			return paso;

		}
	}
}