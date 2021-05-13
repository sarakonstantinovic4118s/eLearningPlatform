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
        Korisnik FindUserById(string id);
        Korisnik Update(string id,Korisnik k);
        Korisnik Insert(Korisnik k);
    }
}
