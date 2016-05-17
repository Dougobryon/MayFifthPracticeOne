using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MayFifthPracticeOne.Models
{
    public class FitnessOfferings
    { 
    [Key]
        public int GroupID { get; set; }
        public string GroupTraining { get; set; }
    }
}