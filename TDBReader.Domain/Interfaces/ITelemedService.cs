using TDBReader.Domain.Entities;

namespace TDBReader.Domain.Interfaces
{
    public interface ITelemedService
    {
        /// <summary>
        /// Возвращает список последних записей из Telemed
        /// </summary>
        public Task<List<TelemedNotice>> GetActualTelemedNotice();
    }
}
