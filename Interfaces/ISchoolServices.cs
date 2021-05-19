﻿using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Interfaces
{
    public interface ISchoolServices
    {
        /// <summary>
        /// Citanje svih skola
        /// </summary>
        List<Skola> Read();

        /// <summary>
        /// Citanje skola sa stranicenjem prema broju i velicini stranice
        /// </summary>
        List<Skola> ReadPage(int stranica, int velicinaStranice);

        /// <summary>
        /// Pretraga prema ID od skole
        /// </summary>
        Skola Find(string skolaID);

        /// <summary>
        /// Pretraga prema nazivu skole sa stranicenjem rezultata
        /// </summary>
        (List<Skola>, int) GetSchools(string name, int page, int pageSize);
    }
}
