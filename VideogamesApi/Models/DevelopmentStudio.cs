﻿using System;
using System.Collections.Generic;

#nullable disable

namespace VideogamesApi
{
    public partial class DevelopmentStudio
    {
        public DevelopmentStudio()
        {
            Engines = new HashSet<Engine>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int? Employees { get; set; }
        public DateTime? FoundationDate { get; set; }

        public virtual ICollection<Engine> Engines { get; set; }
    }
}
