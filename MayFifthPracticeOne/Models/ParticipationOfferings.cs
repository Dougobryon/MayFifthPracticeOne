using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MayFifthPracticeOne.Models
{
    public class ParticipationOfferings
    { 
        [Key]
        public int ParticpationID { get; set; }


        public int GroupID { get; set; }
        public FitnessOfferings FitnessOffering { get; set; }

        public int MemberID { get; set; }
        public ClubMembers ClubMember { get; set; }


    }
}