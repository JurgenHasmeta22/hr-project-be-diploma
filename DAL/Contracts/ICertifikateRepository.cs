﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ICertifikateRepository : IRepository<Certifikate, Guid>
    {
        Certifikate GetbyId(Guid id);
    }
}
