using System.Collections.Generic;

namespace TestRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        /*Metodo para borrar*/
        bool Delete(T entity);
        /*Metodo para actualizar*/
        bool Update(T entity);
        /*Metodo para guardar*/
        int Insert(T entity);
        /*Metodo para obtener una lista del objeto*/
        IEnumerable<T> GetList();
        /*Metodo para obtener un elemento del objeto segun el id*/
        T GetById(int Id);
        void SetSchema(string schema);
    }
}
