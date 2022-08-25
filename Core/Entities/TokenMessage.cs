using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TokenMessage : BaseEntity
    {
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string TokenUid { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public string EmailAddress { get; set; }
        public string EmailText { get; set; }
        public DateTime DateSent { get; set; } = DateTime.UtcNow;    
        public bool IsSent { get; set; } = false;
    }
}