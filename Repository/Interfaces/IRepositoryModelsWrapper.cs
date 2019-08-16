using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Models;

namespace Repository.Interfaces
{
    public interface IRepositoryModelsWrapper
    {
        IDeathDateRepository DeathDate { get; }

        void Save();
    }
}
