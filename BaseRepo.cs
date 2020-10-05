using _04_generic_example.Model;
using System.Collections.Generic;

namespace _04_generic_example.Repository
{
    public class BaseRepository<T>:IRepository<T>
    {
        private IList<T> _data;



        public BaseRepository(IList<T> data)
        {
            _data = data;
        }

        public void Add(T item)
        {
            _data.Add(item);
        }

        public void Add(Class @class, T item)
        {
            _data.Add(item);
        }

        public void Add(Student student, T item)
        {
            _data.Add(item);
        }

        public IList<T> GetAll() => _data;

        public void Remove(T item)=> _data.Remove(item);

  
    }
}
