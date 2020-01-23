using ca_sln_2.Application.Common.Interfaces;

namespace ca_sln_2.WebUI.IntegrationTests
{
    public class TestCurrentUserService : ICurrentUserService
    {
        public string UserId => "00000000-0000-0000-0000-000000000000";
    }
}
