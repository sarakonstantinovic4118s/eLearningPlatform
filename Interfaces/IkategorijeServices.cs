﻿using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eLearning.Interfaces
{
    public interface IkategorijeServices
    {
       public List<Kategorije> Read();
    }
}
