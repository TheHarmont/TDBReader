using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDBReader.Domain.Entities
{
    public class TelemedNotice
    {
        /// <summary>
        /// Срочность
        /// </summary>
        public string? Urgency { get; set; }

        /// <summary>
        /// Профиль медицинского обслуживания 
        /// </summary>
        public string? MedicalCareProfile { get; set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public string? MOId { get; set; }

    }
}
