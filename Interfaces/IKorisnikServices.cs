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
        List<Korisnik> Read(Korisnik korisnik);
        Korisnik Insert(Korisnik k);
    }
}
