﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerId { get; set; }
        [Required]
        public string BowlerLastName { get; set; }
        [Required]
        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }
        [Required]
        public string BowlerAddress { get; set;  }
        [Required]
        public string BowlerCity { get; set;  }
        [Required]
        public string BowlerState { get; set; }
        
        public string BowlerZip { get; set; }
        [Required]
        public string BowlerPhoneNumber { get; set; }
        [Required]
        public int TeamID { get; set; }
        public Team Team { get; set; }

    }
}
