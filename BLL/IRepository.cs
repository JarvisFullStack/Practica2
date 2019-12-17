using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Estudiantes.BLL
{
	public interface IRepository<T> where T : class
	{
		T Buscar(int id);
		List<T> GetList(Expression<Func<T, bool>> expression);
		bool Guardar(T entidad);
		bool Modificar(T entidad);
		bool Eliminar(int id);


	}
}