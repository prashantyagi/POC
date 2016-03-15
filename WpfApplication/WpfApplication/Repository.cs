using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{


    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindByID(int id);
        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll();
    }

    public abstract class BaseRepository<T> : IRepository<T>
    {
        private string tableName;

        public BaseRepository(string tableName)
        {
            this.tableName = tableName;
        }

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual T FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductLocalRepository : BaseRepository<Product>
    {
        List<Product> _products;
        public ProductLocalRepository() : base("File")
        {
            _products = new List<Product>();
        }

        public override void Add(Product item)
        {
            _products.Add(item);
        }

        public override void Update(Product item)
        {
            var product = _products.FirstOrDefault(x => x.Id == item.Id);
            product = item;
        }

        public override void Remove(Product item)
        {
            var product = _products.FirstOrDefault(x => x.Id == item.Id);
            _products.Remove(product);
        }

        public override IEnumerable<Product> FindAll()
        {
            return _products.ToList();
        }

        public override Product FindByID(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
    }

    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository() : base("Product") { }
    }
}
