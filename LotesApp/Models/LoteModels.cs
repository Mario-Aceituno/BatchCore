namespace LotesApp.Models
{
    public class LoteModel
    {
        public string Id { get; set; } = string.Empty;
        public DateTime FechaLote { get; set; }
        public int TotalOrdenesGeneradas { get; set; }
        public int OrdenesCompletadas { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public double PorcentajeProgreso =>
            TotalOrdenesGeneradas > 0
                ? Math.Round((double)OrdenesCompletadas / TotalOrdenesGeneradas * 100, 1)
                : 0;
    }

    public class ProgresoModel
    {
        public string LoteId { get; set; } = string.Empty;
        public int OrdenesCompletadas { get; set; }
        public int TotalOrdenes { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class LotesConfig
    {
        public string RutaDestino { get; set; } = string.Empty;
    }
}