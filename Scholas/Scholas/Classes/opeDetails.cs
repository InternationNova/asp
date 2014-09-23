﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Scholas.Models;
using System.ComponentModel.DataAnnotations;

namespace Scholas.Classes
{
    public class opeDetails
    {
        [Key] public int id { get; set; }
        public string nome { get; set; }
        public string numero_processo { get; set; }
        public string numero_projeto { get; set; }
        public List<opeVis> opeVis = new List<opeVis>();
       

    }
}