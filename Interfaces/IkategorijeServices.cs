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
        Kategorije FindByName(string name);
        void UpdateCategory(Kategorije kategorija);
        void DeleteCategory(string id);
        Kategorije Insert(Kategorije kategorija);
        List<Kategorije> searchReadCategory(string name);

    }
}
