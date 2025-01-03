﻿using System.ComponentModel.DataAnnotations;
namespace ModelLayer {
    public class Skill : BaseEntity {

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string PathProject { get; set; }

        public int Weight { get; set; }
    }
}
