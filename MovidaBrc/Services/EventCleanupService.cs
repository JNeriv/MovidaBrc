using MovidaBrc.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MovidaBrc.Services
{
    //Éste servicio es para eliminar los eventos, una vez se haya cumplido un día de su realización.
    public class EventCleanupService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public EventCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Establece el tiempo hasta la primera ejecución, por ejemplo, a las 00:00 de hoy
            var now = DateTime.Now;
            var nextRun = DateTime.Today.AddDays(1); // Día siguiente a medianoche
            var timeUntilNextRun = nextRun - now;

            _timer = new Timer(async _ =>
            {
                await ExecuteAsync(cancellationToken);
            }, null, timeUntilNextRun, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // Crear un scope para obtener el contexto de base de datos correctamente
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var eventosPasados = context.Fiestas
                    .Where(f => f.FechaRealizacionFiesta < DateTime.Now)
                    .ToList();

                context.Fiestas.RemoveRange(eventosPasados);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
