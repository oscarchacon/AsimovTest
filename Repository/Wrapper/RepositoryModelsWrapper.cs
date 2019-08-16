using Contracts.Models;
using Entities;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Wrapper
{
    public class RepositoryModelsWrapper : IRepositoryModelsWrapper
    {
        private readonly RepositoryContext repository;

        IDeathDateRepository deathDate;

        public RepositoryModelsWrapper(RepositoryContext repository)
        {
            this.repository = repository;
        }

        public IDeathDateRepository DeathDate
        {
            get
            {
                if (this.deathDate == null)
                {
                    this.deathDate = new DeathDateRepository(this.repository);
                }
                return this.deathDate;
            }
        }

        public void Save()
        {
            this.repository.SaveChanges();
        }
    }
}
