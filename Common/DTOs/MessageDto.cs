using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public int? GroupId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime SendDate { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
