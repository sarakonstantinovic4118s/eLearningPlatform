using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Interfaces
{
    public interface IKurseviServices
    {
        List<Kursevi> Read();
    

        Kursevi Find(string id);

   

        /// Citanje kurseva sa stranicenjem prema broju i velicini stranice
        List<Kursevi> ReadPage(int stranica, int velicinaStranice);
        List<Kursevi> ReadPageKat(int stranica, int velicinaStranice, string kategorijaID);

        /// Brojanje rezultata upita
        long Count(string name);
  

        List<Kursevi> findCourses(string kategorijaID);
       

        /// Pretraga prema nazivu kursa sa stranicenjem rezultata
        List<Kursevi> CourseSearch(string name, int stranica, int velicinaStranice);
        List<Kursevi> CourseSearchkat(string name, int stranica, int velicinaStranice, string kategorijaID);

    }
}
