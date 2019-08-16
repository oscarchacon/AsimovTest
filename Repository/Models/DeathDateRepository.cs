using Contracts.Models;
using Entities;
using Entities.Models;
using Entities.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Models
{
    public class DeathDateRepository : RepositoryBase<DeathDate>, IDeathDateRepository
    {
        public DeathDateRepository(RepositoryContext repository) : base(repository) { }

        public void CreateDate(DeathDate deathDate)
        {
            deathDate.Id = new Guid();
            this.Create(deathDate);
        }

        public void DeleteDate(DeathDate deathDate)
        {
            this.Delete(deathDate);
        }

        public IEnumerable<DeathDate> GetAllDateBetween(DateTime startDate, DateTime endDate)
        {
            var deathDatesFind = this.FindByCondition(deathDate => deathDate.StartDate >= startDate && deathDate.StartDate <= endDate)
                                    .ToList();
            return deathDatesFind;
        }

        public IEnumerable<DeathDate> GetAllDates()
        {
            var deathDatesFind = this.FindAll().ToList();
            return deathDatesFind;
        }

        public DeathDate GetDateById(Guid Id)
        {
            var deathDateFind = this.FindByCondition(deathDate => deathDate.Id.Equals(Id))
                                    .DefaultIfEmpty(new DeathDate())
                                    .FirstOrDefault();
            return deathDateFind;
        }

        public void UpdateDate(DeathDate dbDeathDate, DeathDate deathDate)
        {
            dbDeathDate.Map(deathDate);
            this.Update(dbDeathDate);
        }
    }
}
