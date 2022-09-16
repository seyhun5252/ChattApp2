﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class GroupMemberDto
    {
        public int GroupMemberId { get; set; }

        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int AddedUserId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
