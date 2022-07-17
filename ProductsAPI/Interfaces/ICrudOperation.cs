namespace ProductsAPI.Interfaces
{
    public interface ICrudOperation<T>
    {
        public void Add(T obj);
        public List<T> GetAll();
    }
}
