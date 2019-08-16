using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Models
{
    [Table("Date")]
    public class Date : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column]
        public DateTime StartDate { get; set; }

        [Column]
        public DateTime EndDate { get; set; }

        [Column]
        public string Title { get; set; }
    }
}
