using System.Collections.Generic;
using static ConsoleApp1.ProductRepository;

namespace ConsoleApp1
{
    public interface IProductRepository
    {
        int GetCount();

        List<Product> GetAll();

        int Insert(string name, decimal price);

    }
}
