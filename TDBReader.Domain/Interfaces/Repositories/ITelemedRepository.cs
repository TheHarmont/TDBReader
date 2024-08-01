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
        /// <returns>
        /// <para>Список <see cref="Process"/> отсортированный по указанной дате <paramref name="lastDateTime"/></para>   
        /// <para>Список <see cref="Process"/> отсортированный по <see cref="DateTime.Now"/>, если <paramref name="lastDateTime"/> не имеет значения</para>
        /// </returns>
        public Task<List<Process>> GetProcessRecordAfterSpecifiedDateAsync(DateTime? lastDateTime);
    }
}
