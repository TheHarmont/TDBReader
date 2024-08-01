using TDBReader.Domain.Interfaces;

namespace TDBReader.Infrastructure.Services
{
    public class TimerService : ITimerService
    {
        private Timer _timer;
        public event EventHandler Elapsed;

        public void Start()
        {
            _timer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        public void Stop()
        {
            _timer?.Change(Timeout.Infinite, 0);
        }

        private void OnTimerElapsed(object? state)
        {
            Elapsed?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
