using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Tests.Models
{
	public class AdmissionsWithBedRoomQuerymodel: AdmissionDataQueryModel
	{
		public Guid RoomId { get; set; }
		public Guid BedId { get; set; }
	}
}
