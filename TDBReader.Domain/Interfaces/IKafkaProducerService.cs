using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDBReader.Domain.Interfaces
{
    public interface IKafkaProducerService
    {
        public Task SendMessageAsync(string message);
    }
}
