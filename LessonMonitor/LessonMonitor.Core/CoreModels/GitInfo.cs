using Newtonsoft.Json;

namespace LessonMonitor.Core.CoreModels
{
    public class GitInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("login")]
        public string Nickname { get; set; }

        [JsonProperty("html_url")]
        public string Link { get; set; }
    }
}
