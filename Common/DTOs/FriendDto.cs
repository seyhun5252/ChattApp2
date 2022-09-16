using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class FriendDto
    {
        public int FriendId { get; set; }
        public int RequesterUserId { get; set; }
        public int RequestedUserId { get; set; }
        public byte FriendStatusId { get; set; }
        public DateTime RequestedDate { get; set; }

    }
}
