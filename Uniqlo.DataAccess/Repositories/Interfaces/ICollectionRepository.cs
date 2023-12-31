﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface ICollectionRepository : IRepositoryBase<Collection>
    {
        Task<List<Collection>> GetCollectionsShow();
    }
}
