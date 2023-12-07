using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Models
{
    public class SplitwiseComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CommentType { get; set; }
        public string RelationType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public SplitwiseUser User { get; set; }
    }
}
