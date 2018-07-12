using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TallboyBLL
{
    public class NetworkSettings
    {
        private const String apiURL = "http://localhost:49184/api/";

        public static string ApiURL => apiURL;
    }
}
