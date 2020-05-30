using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongHanhDiscordBot
{
    class Configmodel
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}
