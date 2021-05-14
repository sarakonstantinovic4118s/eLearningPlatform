using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Interfaces
{
    public interface IKorisnikServices
    {
        List<Korisnik> Read();
        Korisnik Find(string korisnickoIme);
        Korisnik FindID(string id);

        void UpdateUser(Korisnik korisnik);
        void DeleteUser(string id);
        Korisnik Insert(Korisnik k);
    }
}
