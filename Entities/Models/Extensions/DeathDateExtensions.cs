using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Extensions
{
    public static class DeathDateExtensions
    {
        public static void Map(this DeathDate dbDeathDate, DeathDate deathDate)
        {
            dbDeathDate.Start = deathDate.Start;
            dbDeathDate.End = deathDate.End;
            dbDeathDate.Title = deathDate.Title;
            dbDeathDate.ContactEmail = deathDate.ContactEmail;
        }
    }
}
