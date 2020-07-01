using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NFSUOnline.Networking
{
    public class Player
    {
        [JsonIgnore] public Device device { get; set; }

        [JsonIgnore] public long UserID { get; set; }
        [JsonIgnore] public string Username { get; set; }
        [JsonIgnore] public string Password { get; set; }

        [JsonProperty("gender")] public string Gender { get; set; }
        [JsonProperty("mail")] public string Mail { get; set; }
        [JsonProperty("born")] public string Born { get; set; }
        [JsonProperty("age")] public int Age { get; set; }
        [JsonProperty("personas")] public string[][] Personas { get; set; }

        public Player(Device device, long UserID)
        {
            this.device = device;
            this.UserID = UserID;
        }
    }
}
