using TDBReader.Domain.Entities.dbEntities;

namespace TDBReader.Domain.Interfaces.Repositories
{
    public interface ITelemedRepository
    {
        /// <summary>
        /// Возвращает все записи
        /// </summary>
        public Task<List<Process>> GetProcessRecordAsync();

        /// <summary>
        /// Возвращает список записей, старше указанной даты
        /// </summary>
        public Task<List<Process>> GetProcessRecordAfterDateAsync(DateTime? lastDateTime);
    }
}
