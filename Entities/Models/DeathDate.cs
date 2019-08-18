using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Models
{
    [Table("DeathDate")]
    public class DeathDate : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column]
        public DateTime Start { get; set; }

        [Column]
        public DateTime End { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string ContactEmail { get; set; }
    }
}
