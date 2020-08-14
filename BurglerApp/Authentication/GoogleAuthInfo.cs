using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurglerApp.Authentication
{
    public class GoogleAuthInfo
    {

        public Web web { get; set; }
    }
    public class Web
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string project_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public List<string> redirect_uris { get; set; }
    }

}
