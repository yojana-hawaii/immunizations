﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cdc
{
    public interface ICdcCvxManufacturer
    {
        /// <summary>
        /// Use GET to get data from this table
        /// Use FETCH to get data from external place to this table
        /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/TRADENAME.txt
        /// </summary>
        /// <returns></returns>
        IEnumerable<CdcCvxManufacturer> FetchAll();

        IEnumerable<CdcCvxManufacturer> GetAll();
        CdcCvxManufacturer GetByCvxCode(string cvxCode);
    }
}