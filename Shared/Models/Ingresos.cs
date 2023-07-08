using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresosWabA.Shared.Models;

public class Ingresos
{
    [Key]

    [Required(ErrorMessage = "IngresosId")]
    public int IngresoId { get; set; }

    [Required(ErrorMessage = "Fecha")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Concepto")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Monto")]
    public decimal Monto { get; set; }
}

