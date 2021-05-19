using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Interfaces
{
    public interface ISchoolServices
    {

        /// Citanje svih skola
        List<Skola> Read();

        /// Citanje skola sa stranicenjem prema broju i velicini stranice
        List<Skola> ReadPage(int stranica, int velicinaStranice);

        Skola FindID(string id);

        //INSERT
        Skola Insert(Skola skola);

        //DELETE
        void DeleteSchool(string id);

        //UPDATE
        void UpdateSchool(Skola skola);

        /// Brojanje rezultata upita
        //long Count(string name);


        /// Pretraga prema ID od skole
        Skola Find(string skolaID);

        /// Pretraga prema nazivu skole sa stranicenjem rezultata
        //List<Skola> FindByName(string name, int stranica, int velicinaStranice);
        /// </summary>
        (List<Skola>, int) GetSchools(string name, int page, int pageSize);
    }
}
