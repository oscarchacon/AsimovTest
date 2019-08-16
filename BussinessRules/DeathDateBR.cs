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
    }
}
