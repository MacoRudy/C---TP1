﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSamourai
{
    public class ArtMartial : GestionId
    {
        
        public string Nom { get; set; }
    }
}
