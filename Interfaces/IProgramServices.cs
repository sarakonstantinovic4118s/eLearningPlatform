using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Interfaces
{
    public interface IProgramServices
    {
        List<SekcijaPrograma> Read();
        void Insert(SekcijaPrograma sekcija);
    }
}
