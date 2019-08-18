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

        public IEnumerable<DeathDate> GetAllDateBetween(DateTime startDate, DateTime endDate, Guid? dateNotIncludedId = null)
        {
            var deathDatesFind = this.FindByCondition(deathDate =>
                                        (deathDate.Start >= startDate && deathDate.Start <= endDate) ||
                                        (deathDate.End > startDate && deathDate.End < endDate));
            if (dateNotIncludedId != null)
            {
                deathDatesFind = deathDatesFind.Where(deathDate => !deathDate.Id.Equals(dateNotIncludedId));
            }
                                    
            return deathDatesFind.ToList();
        }

        public IEnumerable<DeathDate> GetAllDates(int? year = null, int? month = null)
        {
            var deathDatesFind = this.FindAll();
            if (year != null && month != null)
            {
                deathDatesFind = deathDatesFind.Where(deathDate => deathDate.Start.Year == year.Value && deathDate.Start.Month == month);
            }
            return deathDatesFind.ToList();
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
