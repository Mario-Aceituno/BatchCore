using LotesApp.Models;

namespace LotesApp.Services
{
    public class CronogramaService
    {
        // ─── Mock data ─────────────────────────────────────────────
        // TODO: cuando la API esté lista, reemplazar cada método por
        // una llamada HttpClient:
        //   private readonly HttpClient _http;
        //   public CronogramaService(HttpClient http) { _http = http; }
        //
        //   public async Task<List<CronogramaModel>> GetCronogramasByLoteAsync(string loteId)
        //       => await _http.GetFromJsonAsync<List<CronogramaModel>>($"api/cronogramas/{loteId}") ?? [];
        //
        //   public async Task<List<DetallePrestamo>> GetDetallesByPrestamoAsync(string numeroPrestamo)
        //       => await _http.GetFromJsonAsync<List<DetallePrestamo>>($"api/cronogramas/detalles/{numeroPrestamo}") ?? [];

        private static readonly List<CronogramaModel> _cronogramasMock = new()
        {
            // Lote LT-22052026-0004
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "CARLOS LUIS ALVARENGA SUAZO",    NumeroPrestamo = "1532301411", NumeroTelefonico = "31805609", Tasa = 13.000m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "JOSE ISRAEL GONZALES HERNANDEZ", NumeroPrestamo = "1532504002", NumeroTelefonico = "32522886", Tasa = 12.500m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "MARIA ELENA FLORES MARTINEZ",    NumeroPrestamo = "1532601234", NumeroTelefonico = "33112244", Tasa = 14.000m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "ANA LUCIA REYES LOPEZ",          NumeroPrestamo = "1532701456", NumeroTelefonico = "34556677", Tasa = 11.500m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "ROBERTO MEJIA SANTOS",           NumeroPrestamo = "1532801789", NumeroTelefonico = "35998877", Tasa = 13.500m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "LAURA PATRICIA MENDOZA CRUZ",   NumeroPrestamo = "1532901023", NumeroTelefonico = "36112233", Tasa = 12.000m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "PEDRO ANTONIO GARCIA RIVAS",    NumeroPrestamo = "1533001345", NumeroTelefonico = "37445566", Tasa = 15.000m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "DIANA MARCELA TORRES VEGA",     NumeroPrestamo = "1533101678", NumeroTelefonico = "38778899", Tasa = 13.000m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "MIGUEL ANGEL CASTRO LIMA",      NumeroPrestamo = "1533201901", NumeroTelefonico = "39001122", Tasa = 11.000m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "SOFIA BEATRIZ ALVARADO PAZ",    NumeroPrestamo = "1533301234", NumeroTelefonico = "31334455", Tasa = 14.500m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "JORGE LUIS PINEDA MOLINA",      NumeroPrestamo = "1533401567", NumeroTelefonico = "32667788", Tasa = 12.500m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "CARMEN ROSA ESPINOZA DIAZ",     NumeroPrestamo = "1533501890", NumeroTelefonico = "33990011", Tasa = 13.000m, Tipo = "Libranza" },            
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "JUAN CARLOS MEJIA LOPEZ",    NumeroPrestamo = "1534001111", NumeroTelefonico = "31111111", Tasa = 12.000m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "MARIA JOSE SANTOS CRUZ",     NumeroPrestamo = "1534002222", NumeroTelefonico = "32222222", Tasa = 13.500m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "CARLOS ALBERTO GOMEZ PAZ", NumeroPrestamo = "1534003333", NumeroTelefonico = "33333333", Tasa = 14.250m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "ANA BEATRIZ MARTINEZ SOLIZ", NumeroPrestamo = "1534004444", NumeroTelefonico = "94444444", Tasa = 11.000m, Tipo = "Vivienda" },
            new CronogramaModel { LoteId = "LT-22052026-0004", NombreCliente = "LUIS FERNANDO RODRIGUEZ CASTRO", NumeroPrestamo = "1534005555", NumeroTelefonico = "95555555", Tasa = 15.000m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0005", NombreCliente = "REBECA NOHEMY ALVARADO DIAZ", NumeroPrestamo = "1534006666", NumeroTelefonico = "36666666", Tasa = 12.750m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0005", NombreCliente = "JORGE LUIS ESPINAL REYES", NumeroPrestamo = "1534007777", NumeroTelefonico = "87777777", Tasa = 13.000m, Tipo = "Vehículo" },
            new CronogramaModel { LoteId = "LT-22052026-0005", NombreCliente = "SARA ELIZABETH FUENTES FLORES", NumeroPrestamo = "1534008888", NumeroTelefonico = "88888888", Tasa = 10.500m, Tipo = "Vivienda" },
            new CronogramaModel { LoteId = "LT-22052026-0005", NombreCliente = "MAURICIO ENRIQUE CACERES PINTO", NumeroPrestamo = "1534009999", NumeroTelefonico = "99999999", Tasa = 16.000m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0006", NombreCliente = "CLAUDIA MARCELA CORRALES BANEGAS", NumeroPrestamo = "1534001234", NumeroTelefonico = "31234567", Tasa = 12.250m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0006", NombreCliente = "RICARDO ANTONIO NUÑEZ MURILLO", NumeroPrestamo = "1534005678", NumeroTelefonico = "98765432", Tasa = 14.000m, Tipo = "Vehículo" },
            new CronogramaModel { LoteId = "LT-22052026-0006", NombreCliente = "GLORIA ESTEFANI RAMOS AGUILERA", NumeroPrestamo = "1534009876", NumeroTelefonico = "87654321", Tasa = 11.750m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0006", NombreCliente = "GUSTAVO ADOLFO MENDOZA ORTIZ", NumeroPrestamo = "1534004321", NumeroTelefonico = "32145678", Tasa = 13.250m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0007", NombreCliente = "GABRIELA MARIA MOYA PADILLA", NumeroPrestamo = "1534008765", NumeroTelefonico = "95432167", Tasa = 15.500m, Tipo = "Personal" },
            new CronogramaModel { LoteId = "LT-22052026-0007", NombreCliente = "HÉCTOR JAVIER ZAVALA VALLE", NumeroPrestamo = "1534002468", NumeroTelefonico = "84682468", Tasa = 12.000m, Tipo = "Vivienda" },
            new CronogramaModel { LoteId = "LT-22052026-0007", NombreCliente = "VALERIA ALEXANDRA PONCE MEZA", NumeroPrestamo = "1534001357", NumeroTelefonico = "31357246", Tasa = 13.850m, Tipo = "Libranza" },
            new CronogramaModel { LoteId = "LT-22052026-0007", NombreCliente = "OSCAR DANILO CASTELLANOS ORELLANA", NumeroPrestamo = "1534007531", NumeroTelefonico = "97531864", Tasa = 14.500m, Tipo = "Vehículo" },
// ... más registros
        };

        private static readonly List<DetallePrestamo> _detallesMock = new()
        {
            // Detalles para 1532301411
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2024,12,25), CuotaTotal = 5712.94m, Saldo = 225976.78m, CapitalPago = 2797.19m, InteresPago = 2211.04m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025,01,25), CuotaTotal = 5712.94m, Saldo = 223179.59m, CapitalPago = 2833.16m, InteresPago = 2175.07m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025,02,25), CuotaTotal = 5712.94m, Saldo = 220346.43m, CapitalPago = 2869.55m, InteresPago = 2138.68m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025,03,25), CuotaTotal = 5712.94m, Saldo = 217476.88m, CapitalPago = 2906.37m, InteresPago = 2101.86m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025,04,25), CuotaTotal = 5712.94m, Saldo = 214570.51m, CapitalPago = 2943.63m, InteresPago = 2064.60m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 01, 25), CuotaTotal = 5712.94m, Saldo = 223148.91m, CapitalPago = 2827.87m, InteresPago = 2180.36m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 02, 25), CuotaTotal = 5712.94m, Saldo = 220319.99m, CapitalPago = 2828.92m, InteresPago = 2179.31m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 03, 25), CuotaTotal = 5712.94m, Saldo = 217462.11m, CapitalPago = 2857.88m, InteresPago = 2150.35m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 04, 25), CuotaTotal = 5712.94m, Saldo = 214575.03m, CapitalPago = 2887.08m, InteresPago = 2121.15m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 05, 25), CuotaTotal = 5712.94m, Saldo = 211658.49m, CapitalPago = 2916.54m, InteresPago = 2091.69m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 06, 25), CuotaTotal = 5712.94m, Saldo = 208712.22m, CapitalPago = 2946.27m, InteresPago = 2061.96m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 07, 25), CuotaTotal = 5712.94m, Saldo = 205735.95m, CapitalPago = 2976.27m, InteresPago = 2031.96m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 08, 25), CuotaTotal = 5712.94m, Saldo = 202729.41m, CapitalPago = 3006.54m, InteresPago = 2001.69m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 09, 25), CuotaTotal = 5712.94m, Saldo = 199692.32m, CapitalPago = 3037.09m, InteresPago = 1971.14m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 10, 25), CuotaTotal = 5712.94m, Saldo = 196624.40m, CapitalPago = 3067.92m, InteresPago = 1940.31m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 11, 25), CuotaTotal = 5712.94m, Saldo = 193525.36m, CapitalPago = 3099.04m, InteresPago = 1909.19m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2025, 12, 25), CuotaTotal = 5712.94m, Saldo = 190394.92m, CapitalPago = 3130.44m, InteresPago = 1877.79m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 01, 25), CuotaTotal = 5712.94m, Saldo = 187232.78m, CapitalPago = 3162.14m, InteresPago = 1846.09m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 02, 25), CuotaTotal = 5712.94m, Saldo = 184038.65m, CapitalPago = 3194.13m, InteresPago = 1814.10m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 03, 25), CuotaTotal = 5712.94m, Saldo = 180812.23m, CapitalPago = 3226.42m, InteresPago = 1781.81m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 04, 25), CuotaTotal = 5712.94m, Saldo = 177553.22m, CapitalPago = 3259.01m, InteresPago = 1749.22m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 05, 25), CuotaTotal = 5712.94m, Saldo = 174261.32m, CapitalPago = 3291.90m, InteresPago = 1716.33m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 06, 25), CuotaTotal = 5712.94m, Saldo = 170936.23m, CapitalPago = 3325.09m, InteresPago = 1683.14m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 5.00m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 07, 25), CuotaTotal = 5712.94m, Saldo = 167577.64m, CapitalPago = 3358.59m, InteresPago = 1649.64m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532301411", FechaPago = new DateTime(2026, 08, 25), CuotaTotal = 5712.94m, Saldo = 164185.24m, CapitalPago = 3392.40m, InteresPago = 1615.83m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },


            // Detalles para 1532504002
            new DetallePrestamo { NumeroPrestamo = "1532504002", FechaPago = new DateTime(2024,12,25), CuotaTotal = 5712.94m, Saldo = 225976.78m, CapitalPago = 2625.17m, InteresPago = 2383.06m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532504002", FechaPago = new DateTime(2025,01,25), CuotaTotal = 5712.94m, Saldo = 223351.61m, CapitalPago = 2657.97m, InteresPago = 2350.26m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532504002", FechaPago = new DateTime(2025,02,25), CuotaTotal = 5712.94m, Saldo = 220693.64m, CapitalPago = 2691.11m, InteresPago = 2317.12m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532504002", FechaPago = new DateTime(2025,03,25), CuotaTotal = 5712.94m, Saldo = 218002.53m, CapitalPago = 2724.60m, InteresPago = 2283.63m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
            new DetallePrestamo { NumeroPrestamo = "1532504002", FechaPago = new DateTime(2025,04,25), CuotaTotal = 5712.94m, Saldo = 215277.93m, CapitalPago = 2758.45m, InteresPago = 2249.78m, Cuota = 5008.23m, Seguros = 704.71m, CargoAdministrativo = 0m },
        };

        // ─── Métodos públicos ──────────────────────────────────────

        public Task<List<CronogramaModel>> GetCronogramasByLoteAsync(string loteId, int pagina = 1, int porPagina = 15, string? filtro = null)
        {
            var resultado = _cronogramasMock
                .Where(c => c.LoteId == loteId)
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtro))
                resultado = resultado.Where(c =>
                    c.NombreCliente.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    c.NumeroPrestamo.Contains(filtro, StringComparison.OrdinalIgnoreCase));

            resultado = resultado
                .Skip((pagina - 1) * porPagina)
                .Take(porPagina);

            return Task.FromResult(resultado.ToList());
        }

        public Task<int> GetTotalCronogramasAsync(string loteId, string? filtro = null)
        {
            var total = _cronogramasMock
                .Where(c => c.LoteId == loteId)
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtro))
                total = total.Where(c =>
                    c.NombreCliente.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    c.NumeroPrestamo.Contains(filtro, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(total.Count());
        }

        public Task<CronogramaModel?> GetCronogramaByPrestamoAsync(string numeroPrestamo)
            => Task.FromResult(_cronogramasMock.FirstOrDefault(c => c.NumeroPrestamo == numeroPrestamo));

        public Task<List<DetallePrestamo>> GetDetallesByPrestamoAsync(string numeroPrestamo, int pagina = 1, int porPagina = 12, string? filtroFecha = null)
        {
            var resultado = _detallesMock
                .Where(d => d.NumeroPrestamo == numeroPrestamo)
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtroFecha) && DateTime.TryParse(filtroFecha, out var fecha))
                resultado = resultado.Where(d => d.FechaPago.Year == fecha.Year && d.FechaPago.Month == fecha.Month);

            resultado = resultado
                .OrderBy(d => d.FechaPago)
                .Skip((pagina - 1) * porPagina)
                .Take(porPagina);

            return Task.FromResult(resultado.ToList());
        }

        public Task<int> GetTotalDetallesAsync(string numeroPrestamo, string? filtroFecha = null)
        {
            var total = _detallesMock
                .Where(d => d.NumeroPrestamo == numeroPrestamo)
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtroFecha) && DateTime.TryParse(filtroFecha, out var fecha))
                total = total.Where(d => d.FechaPago.Year == fecha.Year && d.FechaPago.Month == fecha.Month);

            return Task.FromResult(total.Count());
        }
    }
}

