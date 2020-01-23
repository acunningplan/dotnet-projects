using ca_sln_2.Application.Common.Interfaces;
using System;

namespace ca_sln_2.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
