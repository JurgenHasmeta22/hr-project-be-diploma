using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.RoleDTO {
	public class RoleDTO {
		public Guid RoliId { get; set; }
		public string RoliEmri { get; set; } = null!;
		public string RoliPershkrim { get; set; } = null!;
	}
}
