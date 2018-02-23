using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntToRoman.Models
{
    public class DataModel
    {
        [Required]
        public int Number { get; set; }
        [Display(Name = "Evaluate me?")]
        public string RomanNumber { get; set; }
    }
}