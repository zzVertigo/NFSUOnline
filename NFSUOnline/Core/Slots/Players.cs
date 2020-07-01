using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using NFSUOnline.Core.Database;
using NFSUOnline.Core.Database.Models;
using NFSUOnline.Networking;

namespace NFSUOnline.Core.Slots
{
    public class Players : Dictionary<long, Player>
    {
        public long seed;

        public Players()
        {
            seed = MySQL.getSeed("UserID", "players");
        }

        public void add(Player player)
        {
            if (this.ContainsKey(player.UserID))
            {
                this[player.UserID] = player;
            }
            else
            {
                this.Add(player.UserID, player);
            }
        }

        public void remove(Player player)
        {
            if (this.ContainsKey(player.UserID))
            {
                if (Remove(player.UserID))
                {
                }
            }
            else
            {
                // error - shouldn't happen
            }
        }

        public Player getPlayer(Device device, string Username, string Password)
        {
            long userid = MySQL.getIDByUsername(Username);

            if (userid != -1 && !this.ContainsKey(userid))
            {
                Player player = null;

                using (var db = new Context())
                {
                    var data = db.Players.Find(userid);

                    if (data != null)
                    {
                        if (!string.IsNullOrEmpty(data.Data))
                        {
                            player = JsonConvert.DeserializeObject<Player>(data.Data);

                            player.UserID = userid;
                            player.Username = Username;
                            player.Password = Password;

                            player.device = device;
                            device.player = player;

                            this.Add(userid, player);
                        }
                    }
                    else
                    {
                        Console.WriteLine("GET FUCKED");
                    }

                    return player;
                }
            }

            return null;
        }

        public Player createPlayer(Device device, string Username, string Password)
        {
            Player newPlayer = new Player(device, Interlocked.Increment(ref this.seed));

            newPlayer.Username = Username;
            newPlayer.Password = Password;

            using (var db = new Context())
            {
                var playerModel = new PlayerModel()
                {
                    UserID = newPlayer.UserID,
                    Username = newPlayer.Username,
                    Password = newPlayer.Password,
                    Data = JsonConvert.SerializeObject(newPlayer)
                };

                db.Players.AddRange(playerModel);
                db.SaveChanges();

                this.Add(newPlayer.UserID, newPlayer);
            }

            return newPlayer;
        }

        public void savePlayer(Player player)
        {
            using (var db = new Context())
            {
                long userid = MySQL.getIDByUsername(player.Username);

                if (userid != -1)
                {
                    var data = db.Players.Find(userid);

                    if (data != null)
                    {
                        data.UserID = player.UserID;
                        data.Username = player.Username;
                        data.Password = player.Password;
                        data.Data = JsonConvert.SerializeObject(player);
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
