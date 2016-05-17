using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MayFifthPracticeOne.Models
{
    public class ClubMembers
    {
        [Key]
        public int MemberID {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        
    }
}

