using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDBReader.Domain.Interfaces
{
    public interface ITimerService
    {
        public event EventHandler Elapsed;

        public void Start();

        public void Stop();

        public void Dispose();

    }
}
