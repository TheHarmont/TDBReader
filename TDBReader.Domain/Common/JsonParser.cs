using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TDBReader.Domain.Entities;

namespace TDBReader.Domain.Common
{
    public static class JsonParser
    {
        public static string? GetValueFromJsonByName(this string jsonString, string elementName)
        {
            try
            {
                if(string.IsNullOrEmpty(jsonString) || string.IsNullOrEmpty(elementName)) return null;
                JObject jsonObject = JObject.Parse(jsonString);

                return jsonObject[elementName]?.ToString(); 
            }
            catch (JsonException jsonEx)
            {
                // Логирование ошибок, связанных с парсингом JSON
                Console.Error.WriteLine($"Ошибка парсинга Json: {jsonEx.Message}");

                return null;
            }
            catch (Exception ex)
            {
                ///TODO Добавить логгирование
                Console.Error.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");

                throw;
            }
        }
    }
}
