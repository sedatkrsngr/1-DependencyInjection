using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_DependencyInjection.Models
{
    public class DateService : ISingletonDateService, ITransientDateService, IScopedDateService
    {
        private readonly ILogger<DateService> logger;//Loglama için kullanılır. Göülü gelir. Nerde kullanmak istiyorsak o clası veririz.

        public DateService(ILogger<DateService> logger)
        {
            this.logger = logger;

            logger.LogWarning("DateService Constructor çalıştı");//İStediğimiz herşeyi yaaibliriz. Amaç Consolda çağırılıp çağrılmadığını görmek.
        }

        public DateTime GetDateTime { get; } = DateTime.Now;
    }
}
