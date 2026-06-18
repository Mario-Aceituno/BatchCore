namespace LotesApp.Models
{
    // ── Cronograma (datos del cliente) ─────────────────────────────
    public class CronogramaModel
    {
        public string LoteId { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public string NumeroPrestamo { get; set; } = string.Empty;
        public string NumeroTelefonico { get; set; } = string.Empty;
        public decimal Tasa { get; set; }
        public string Tipo { get; set; } = string.Empty;
    }

    // ── Detalle de préstamo (cuotas) ───────────────────────────────
    public class DetallePrestamo
    {
        public string NumeroPrestamo { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
        public decimal CuotaTotal { get; set; }
        public decimal Saldo { get; set; }
        public decimal CapitalPago { get; set; }
        public decimal InteresPago { get; set; }
        public decimal Cuota { get; set; }
        public decimal Seguros { get; set; }
        public decimal CargoAdministrativo { get; set; }
    }
}

