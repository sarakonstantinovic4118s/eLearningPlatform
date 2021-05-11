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

        void DeleteCourse(string id);

        List<Kursevi> findCourses(string kategorijaID);
    }
}
