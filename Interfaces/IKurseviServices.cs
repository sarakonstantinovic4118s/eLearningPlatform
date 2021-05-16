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
        Kursevi Insert(Kursevi kurs);

        Kursevi Find(string id);

        void UpdateCourse(Kursevi kurs);

        /// Citanje skola sa stranicenjem prema broju i velicini stranice
        List<Kursevi> ReadPage(int stranica, int velicinaStranice);

        /// Brojanje rezultata upita
        long Count(string name);
        void DeleteCourse(string id);

        List<Kursevi> findCourses(string kategorijaID);
        List<Kursevi> FindBySchool(string schoolID);

        /// Pretraga prema nazivu kursa sa stranicenjem rezultata
        List<Kursevi> CourseSearch(string name, int stranica, int velicinaStranice);
    }
}
