using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace PokeGame
{
    public class Pokemon : PictureBox
    {
        public string name { get; private set; }
        public bool front { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }
        public Dictionary<string, int> stats { get; private set; }
        public MyRichTextBox tbx { get; set; }
        public Dictionary<string, bool> winnerFlags { get; set; }

        public Pokemon(int id, int x, int y, bool f)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(String.Format("https://pokeapi.co/api/v2/pokemon/{0}", id.ToString()));
            JObject jo = JObject.Parse(data);

            name = jo["species"]["name"].ToString();

            stats = new Dictionary<string, int>();
            stats.Add("hp", (int)jo["stats"][0]["base_stat"]);
            stats.Add("ap", (int)jo["stats"][1]["base_stat"]);
            stats.Add("df", (int)jo["stats"][2]["base_stat"]);
            stats.Add("sa", (int)jo["stats"][3]["base_stat"]);
            stats.Add("sd", (int)jo["stats"][4]["base_stat"]);
            stats.Add("sp", (int)jo["stats"][5]["base_stat"]);
            front = f;
            this.x = x;
            this.y = y;

            if (front)
            {
                wc.DownloadFile(jo["sprites"]["front_default"].ToString(), String.Format("pictures/{0}_front.png", name));
                this.Image = Image.FromFile(String.Format("pictures/{0}_front.png", name));
            }
            else
            {
                if (jo["sprites"]["back_default"].Type == JTokenType.Null)
                {
                    wc.DownloadFile(jo["sprites"]["front_default"].ToString(), String.Format("pictures/{0}_back.png", name));
                    this.Image = Image.FromFile(String.Format("pictures/{0}_back.png", name));
                }
                else
                {
                    wc.DownloadFile(jo["sprites"]["back_default"].ToString(), String.Format("pictures/{0}_back.png", name));
                    this.Image = Image.FromFile(String.Format("pictures/{0}_back.png", name));
                }
            }

            this.Location = new System.Drawing.Point(x, y);
            this.Width = 256;
            this.Height = 256;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
            this.front = front;

        }
    }
}
