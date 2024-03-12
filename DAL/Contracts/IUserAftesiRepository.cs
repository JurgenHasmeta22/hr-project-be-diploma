﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DAL.Contracts
{
    public interface IUserAftesiRepository : IRepository<UserAftesi, Guid>
    {
        public UserAftesi GetByUserIdAndAftesiId(Guid userId, Guid aftesiId);
    }
}
