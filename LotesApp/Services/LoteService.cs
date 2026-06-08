using LotesApp.Models;
using Microsoft.Extensions.Options;

namespace LotesApp.Services
{    
    public class LoteService
    {
        private readonly LotesConfig _config;

        private string GenerarLoteId(DateTime fecha)
        {
            // Busca cuántos lotes ya existen con la misma fecha
            var lotesEnFecha = _lotesMock
                .Count(l => l.FechaLote.Date == fecha.Date);

            // El correlativo es la cantidad existente + 1 (número de serie: 0001, 0002, etc)
            var correlativo = (lotesEnFecha + 1).ToString("D4");

            // Resultado: LT-03102026-0001
            return $"LT-{fecha:ddMMyyyy}-{correlativo}";
        }

        public Task<LoteModel> CrearLoteAsync(DateTime fechaLote, int totalOrdenes)
        {
            var nuevoLote = new LoteModel
            {
                Id = GenerarLoteId(fechaLote),
                FechaLote = fechaLote,
                TotalOrdenesGeneradas = totalOrdenes,
                OrdenesCompletadas = 0,
                Estado = "Pendiente",
                Creado = DateTime.Now,
                Modificado = DateTime.Now
            };

            _lotesMock.Add(nuevoLote);
            return Task.FromResult(nuevoLote);
        }

        public LoteService(IOptions<LotesConfig> config)
        {
            _config = config.Value;
        }

        // ─── Datos Mock ────────────────────────────────────────────────
        // Reemplaza estos métodos con llamadas HttpClient a tu API real
        // cuando los endpoints estén listos.

        private static readonly List<LoteModel> _lotesMock = new()
        {
            new LoteModel
            {
                Id                    = "LT-02102026-0002",
                FechaLote             = new DateTime(2026, 2, 23),
                TotalOrdenesGeneradas = 3000,
                OrdenesCompletadas    = 300,
                Estado                = "Pendiente",
                Creado                = new DateTime(2026, 2, 10),
                Modificado            = new DateTime(2026, 4, 8)
            },
            new LoteModel
            {
                Id                    = "LT-03012026-0002",
                FechaLote             = new DateTime(2026, 3, 15),
                TotalOrdenesGeneradas = 1500,
                OrdenesCompletadas    = 1500,
                Estado                = "Listo para enviar",
                Creado                = new DateTime(2026, 3, 1),
                Modificado            = new DateTime(2026, 3, 16)
            },
            new LoteModel
            {
                Id                    = "LT-04052026-0003",
                FechaLote             = new DateTime(2026, 4, 5),
                TotalOrdenesGeneradas = 2200,
                OrdenesCompletadas    = 1800,
                Estado                = "Pendiente",
                Creado                = new DateTime(2026, 4, 1),
                Modificado            = new DateTime(2026, 4, 10)
            },
            new LoteModel
            {
                Id                    = "LT-22052026-0004",
                FechaLote             = new DateTime(2026, 5, 20),
                TotalOrdenesGeneradas = 4000,
                OrdenesCompletadas    = 4000,
                Estado                = "Listo para enviar",
                Creado                = new DateTime(2026, 5, 15),
                Modificado            = new DateTime(2026, 5, 22)
            },
        };

        private static readonly Dictionary<string, List<ProgresoModel>> _progresoMock = new()
        {
            ["LT01"] = new()
            {
                new ProgresoModel { LoteId = "LT013000", OrdenesCompletadas = 100,  TotalOrdenes = 3000, FechaRegistro = new DateTime(2026, 2, 24) },
                new ProgresoModel { LoteId = "LT013000", OrdenesCompletadas = 200,  TotalOrdenes = 3000, FechaRegistro = new DateTime(2026, 2, 25) },
                new ProgresoModel { LoteId = "LT013000", OrdenesCompletadas = 300,  TotalOrdenes = 3000, FechaRegistro = new DateTime(2026, 2, 26) },
            },
            ["LT02"] = new()
            {
                new ProgresoModel { LoteId = "LT02", OrdenesCompletadas = 500,  TotalOrdenes = 1500, FechaRegistro = new DateTime(2026, 3, 12) },
                new ProgresoModel { LoteId = "LT02", OrdenesCompletadas = 1000, TotalOrdenes = 1500, FechaRegistro = new DateTime(2026, 3, 14) },
                new ProgresoModel { LoteId = "LT02", OrdenesCompletadas = 1500, TotalOrdenes = 1500, FechaRegistro = new DateTime(2026, 3, 15) },
            },
            ["LT03"] = new()
            {
                new ProgresoModel { LoteId = "LT03", OrdenesCompletadas = 440, TotalOrdenes = 2200, FechaRegistro = new DateTime(2026, 4, 7) },
                new ProgresoModel { LoteId = "LT03", OrdenesCompletadas = 880, TotalOrdenes = 2200, FechaRegistro = new DateTime(2026, 4, 10) },
            },
            ["LT04"] = new()
            {
                new ProgresoModel { LoteId = "LT04", OrdenesCompletadas = 1000, TotalOrdenes = 4000, FechaRegistro = new DateTime(2026, 5, 17) },
                new ProgresoModel { LoteId = "LT04", OrdenesCompletadas = 2000, TotalOrdenes = 4000, FechaRegistro = new DateTime(2026, 5, 18) },
                new ProgresoModel { LoteId = "LT04", OrdenesCompletadas = 3000, TotalOrdenes = 4000, FechaRegistro = new DateTime(2026, 5, 19) },
                new ProgresoModel { LoteId = "LT04", OrdenesCompletadas = 4000, TotalOrdenes = 4000, FechaRegistro = new DateTime(2026, 5, 20) },
            },
        };

        // ─── Métodos públicos ──────────────────────────────────────────

        public Task<List<LoteModel>> GetLotesAsync()
            => Task.FromResult(_lotesMock.OrderByDescending(l => l.FechaLote).ToList());

        public Task<List<ProgresoModel>> GetProgresoByLoteAsync(string loteId)
            => Task.FromResult(
                _progresoMock.TryGetValue(loteId, out var progreso)
                    ? progreso
                    : new List<ProgresoModel>());

        public Task<bool> EnviarLoteAsync(string loteId)
        {
            // ── MOCK: simula el envío generando un archivo en la carpeta local ──
            // TODO: cuando la API esté lista, reemplazar por:
            //   var response = await _http.PostAsync($"api/lotes/{loteId}/enviar", null);
            //   return response.IsSuccessStatusCode;

            var lote = _lotesMock.FirstOrDefault(l => l.Id == loteId);
            if (lote is null) return Task.FromResult(false);

            // Crear carpeta destino si no existe
            var destino = Path.Combine(_config.RutaDestino, loteId);
            if (!Directory.Exists(destino))
                Directory.CreateDirectory(destino);

            // Generar archivo de prueba con info del lote
            var nombreArchivo = $"{lote.Id}_{lote.FechaLote:yyyyMMdd}.txt";
            var rutaArchivo = Path.Combine(destino, nombreArchivo);

            var contenido = $"""
                LOTE:               {lote.Id}
                FECHA:              {lote.FechaLote:dd/MM/yyyy}
                TOTAL ÓRDENES:      {lote.TotalOrdenesGeneradas}
                ÓRDENES COMPLETADAS:{lote.OrdenesCompletadas}
                ESTADO:             {lote.Estado}
                ENVIADO:            {DateTime.Now:dd/MM/yyyy HH:mm:ss}
                """;

            File.WriteAllText(rutaArchivo, contenido);

            lote.Estado = "Enviado";
            return Task.FromResult(true);
        }
    }
}
