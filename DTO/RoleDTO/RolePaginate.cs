﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DTO.RoleDTO
{
    public class RolePaginate
    {
        public IEnumerable<RoleDTO> list { get; set; }
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
