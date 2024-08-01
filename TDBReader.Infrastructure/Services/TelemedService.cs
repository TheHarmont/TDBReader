using TDBReader.Domain.Common;
using TDBReader.Domain.Entities;
using TDBReader.Domain.Interfaces;
using TDBReader.Domain.Interfaces.Repositories;

namespace TDBReader.Infrastructure.Services
{
    public class TelemedService : ITelemedService
    {
        private readonly ITelemedRepository _telemedRepository;

        private static DateTime? dateLastNotice { get; set; }

        public TelemedService(ITelemedRepository telemedRepository)
        {
            _telemedRepository = telemedRepository;

            //Если значение последней даты пусто, то отталкиваемся от текущей даты
            dateLastNotice ??= DateTime.Now;
        }

        public async Task<List<TelemedNotice>> GetActualTelemedNotice()
        {
            try
            {
                var processList = await _telemedRepository.GetProcessRecordAfterSpecifiedDateAsync(dateLastNotice);

                if (!processList.Any()) return new List<TelemedNotice>();

                //Сохраняем дату последней записи, чтобы отталкиваться от ней в дальнейшем
                dateLastNotice = processList.Last().Created;

                return processList.Select(x => new TelemedNotice
                {
                    ProcessId = x.Metadata?.ProcessId,
                    Urgency = x.Metadata?.ScopedMetadata?.GetValueFromJsonByName("Срочность"),
                    MedicalCareProfile = x.Metadata?.ScopedMetadata?.GetValueFromJsonByName("Профиль медицинской помощи"),
                    MOId = x.Entity?.GetValueFromJsonByName("serviceRequest")?.GetValueFromJsonByName("requesterOrganization")
                }).ToList();
            }
            catch (Exception ex)
            {
                ///TODO: Добавить логгирование
                Console.Error.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");

                return new List<TelemedNotice>();
            }
        }
    }
}
