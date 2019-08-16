using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Extensions
{
    public static class DeathDateExtensions
    {
        public static void Map(this DeathDate dbDeathDate, DeathDate deathDate)
        {
            dbDeathDate.StartDate = deathDate.StartDate;
            dbDeathDate.EndDate = deathDate.EndDate;
            dbDeathDate.Title = deathDate.Title;
            dbDeathDate.ContactEmail = deathDate.ContactEmail;
        }
    }
}
