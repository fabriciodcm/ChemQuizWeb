
namespace ChemQuizWeb.Core.Interfaces.Repositories
{
    //Read more: http://www.linhadecodigo.com.br/artigo/3370/entity-framework-4-repositorio-generico.aspx#ixzz7iOKFlP1P
    public interface IBaseRepository<T> where T : class
    {
        T Find(long id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
    }
}
