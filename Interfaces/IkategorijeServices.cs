using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eLearning.Interfaces
{
    public interface IKategorijeServices
    {
       public List<Kategorije> Read();

        Kategorije Find(string id);

        void UpdateCategory(Kategorije kategorija);
        void DeleteCategory(string id);
        Kategorije Insert(Kategorije kategorija);
       
    }
}
