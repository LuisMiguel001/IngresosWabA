using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresosWabA.Shared.Models
{
	public class IngresosDetalle
	{
		[Key]

		public string? Emisor { get; set; }

        public string? Mensaje { get; set; }
    }
}
