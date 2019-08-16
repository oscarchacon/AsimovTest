using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Models
{
    public interface IDeathDateRepository: IRepositoryBase<DeathDate>
    {
        IEnumerable<DeathDate> GetAllDates();

        IEnumerable<DeathDate> GetAllDateBetween(DateTime startDate, DateTime endDate);

        DeathDate GetDateById(Guid Id);

        void CreateDate(DeathDate deathDate);

        void UpdateDate(DeathDate dbDeathDate, DeathDate deathDate);

        void DeleteDate(DeathDate deathDate);
    }
}
