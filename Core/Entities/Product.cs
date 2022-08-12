using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // [Key]
        public int Id { get; set; }
        public Guid? UId { get; set; }
        public string Name { get; set; }

    }
}
