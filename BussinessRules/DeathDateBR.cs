using Entities.Models;
using Entities.Utils;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public class DeathDateBR
    {
        private readonly IRepositoryModelsWrapper repository;
        public DeathDateBR(IRepositoryModelsWrapper repository)
        {
            this.repository = repository;
        }


        public IEnumerable<DeathDate> GetAllDates()
        {
            try
            {
                var deathDatesFind = this.repository.DeathDate.GetAllDates();
                return deathDatesFind;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public DeathDate GetDateById (Guid Id)
        {
            try
            {
                var deathDateFind = this.repository.DeathDate.GetDateById(Id);
                return deathDateFind;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void CreateDate(DeathDate deathDateNew)
        {
            try
            {
                this.repository.DeathDate.CreateDate(deathDateNew);
                this.repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool UdpdateDate(Guid dateId, DeathDate deathDateUpdated)
        {
            try
            {
                var dbDeathDate = this.repository.DeathDate.GetDateById(dateId);
                if (dbDeathDate.IsEmptyObject()) { return false; }

                this.repository.DeathDate.UpdateDate(dbDeathDate, deathDateUpdated);
                this.repository.Save();

                deathDateUpdated.Id = dateId;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool DeleteDate(Guid dateId)
        {
            try
            {
                var dbDeathDate = this.repository.DeathDate.GetDateById(dateId);
                if (dbDeathDate.IsEmptyObject()) { return false; }


                this.repository.DeathDate.DeleteDate(dbDeathDate);
                this.repository.Save();

                return true;
            }
            catch (ArgumentNullException anex)
            {
                throw new Exception(anex.Message, anex.InnerException);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
