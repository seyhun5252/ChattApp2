using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? GroupProfilePhoto { get; set; }
        public int CreaterUserId { get; set; }
        //public DateTime CreateDate { get; set; }
    }
}
