using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost1.ConfigurationHelper
{
    public static class Clients
    {
        private static Lazy<ClientSection> section = new Lazy<ClientSection>(() => (ClientSection)ConfigurationManager.GetSection("apiClients"));

        public static bool VerifyKey(string apiKey)
        {
            return section.Value.Clients.Cast<ClientSection.ClientElement>().Any(ce => ce.ApiKey == apiKey);
        }
    }
}
