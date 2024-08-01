using Microsoft.EntityFrameworkCore;
using System;
using TDBReader.Domain.Entities.dbEntities;
using TDBReader.Domain.Interfaces.Repositories;
using TDBReader.Presistence.Context;

namespace TDBReader.Presistence.Repositories
{
    public class TelemedRepository : ITelemedRepository
    {
        private readonly TelemedDBContext _dbContext;

        public TelemedRepository(TelemedDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Process>> GetProcessRecordAsync()
        {
            try
            {
                return await _dbContext.Processes.
                    AsNoTracking().
                    Include(x => x.MetadataId).
                    ToListAsync();
            }
            catch (Exception ex)
            {
                ///TODO: Добавить логгирование
                Console.Error.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");

                return new List<Process>();
            }
        }

        public async Task<List<Process>> GetProcessRecordAfterCurrentOrSpecifiedDateAsync(DateTime? date)
        {
            
            if (!date.HasValue) date = DateTime.Now;

            try
            {
                return await _dbContext.Processes.
                    AsNoTracking().
                    Include(x => x.Metadata).
                    Where(x => x.Created > date).
                    ToListAsync();
            }
            catch (Exception ex)
            {
                ///TODO: Добавить логгирование
                Console.Error.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");

                return new List<Process>();
            }
        }
    }
}
