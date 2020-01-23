using ca_sln_2.Application.Common.Interfaces;
using System;

namespace ca_sln_2.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
