using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NFSUOnline.Core.Database.Models
{
    public class PlayerModel
    {
        [Key]
        public long UserID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Data { get; set; }
    }
}
