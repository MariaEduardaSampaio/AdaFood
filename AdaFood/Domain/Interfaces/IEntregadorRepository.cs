namespace AdaFood.Domain.Interfaces
{
    public interface IEntregadorRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T? Delete(int id);
        IEnumerable<T> GetAll();

        T? GetById(int id);
        T? GetByCPF(string cpf);

    }
}
