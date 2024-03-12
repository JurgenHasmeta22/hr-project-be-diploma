using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AccountDTO
{
    public class LoginDTO
    {
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
