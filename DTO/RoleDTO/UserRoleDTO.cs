using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.RoleDTO {
	public class UserRoleDTO {
		public Guid UserId { get; set; }
		public Guid RoliId { get; set; }
		public DateTime? DataCaktimit { get; set; }
	}
}
