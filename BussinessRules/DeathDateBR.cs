﻿using Entities.Models;
using Entities.Utils;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public IEnumerable<DeathDate> GetAllDates(int? year = null, int? month = null)
        {
            try
            {
                var deathDatesFind = this.repository.DeathDate.GetAllDates(year, month);
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

        public bool CreateDate(DeathDate deathDateNew)
        {
            try
            {
                if (!this.IsOfficeHours(deathDateNew.Start) || !this.IsOfficeHours(deathDateNew.End)) { return false; }
                if (this.IsWeekend(deathDateNew.Start) || this.IsWeekend(deathDateNew.End)) { return false; }
                if (this.IsDifferentDay(deathDateNew.Start, deathDateNew.End)) { return false; }
                if (this.DiffHoursInSeconds(deathDateNew.Start, deathDateNew.End) > 3600) { return false; }

                var deathDatesFind = this.repository.DeathDate.GetAllDateBetween(deathDateNew.Start, deathDateNew.End);
                if (deathDatesFind != null)
                {
                    if (deathDatesFind.Count() > 0) { return false; }
                }

                this.repository.DeathDate.CreateDate(deathDateNew);
                this.repository.Save();
                return true;
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
                if (dbDeathDate.IsEmptyObject() || dbDeathDate.IsObjectNull()) { return false; }
                if (dbDeathDate.Start != deathDateUpdated.Start || dbDeathDate.End != deathDateUpdated.End)
                {
                    if (!this.IsOfficeHours(deathDateUpdated.Start) || !this.IsOfficeHours(deathDateUpdated.End)) { return false; }
                    if (this.IsWeekend(deathDateUpdated.Start) || this.IsWeekend(deathDateUpdated.End)) { return false; }
                    if (this.IsDifferentDay(deathDateUpdated.Start, deathDateUpdated.End)) { return false; }
                    if (this.DiffHoursInSeconds(deathDateUpdated.Start, deathDateUpdated.End) > 3600) { return false; }

                    var deathDatesFind = this.repository.DeathDate.GetAllDateBetween(deathDateUpdated.Start, deathDateUpdated.End, dateId);
                    if (deathDatesFind != null)
                    {
                        if (deathDatesFind.Count() > 0) { return false; }
                    }
                }

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

        private bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday);
        }

        private bool IsDifferentDay(DateTime startDate, DateTime endDate)
        {
            if (startDate.Year != endDate.Year) { return true; }
            if (startDate.Month != endDate.Month) { return true; }
            if (startDate.Day != endDate.Day) { return true; }

            return false;
        }

        private int DiffHoursInSeconds(DateTime startDate, DateTime endDate)
        {
            var seconds = (endDate - startDate).TotalSeconds;
            return Convert.ToInt32(seconds);
        }

        private bool IsOfficeHours(DateTime date)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            var startOfficeHour = new DateTime(year, month, day, 9, 0, 0);
            var endOfficeHour = new DateTime(year, month, day, 18, 0, 0);
            return date >= startOfficeHour && date <= endOfficeHour;
        }
    }

    
}
