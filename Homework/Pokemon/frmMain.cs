using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Text;

namespace PokeGame
{
    public partial class frmMain : Form
    {
        private Random rng = new Random();
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private List<Pokemon> pks = new List<Pokemon>();
        private Font pokefont;
        private string selectedButton = "";
        private List<Button> buttons;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pbxBg.Image = Image.FromFile("resources/bg.png");
            pbxBg.SizeMode = PictureBoxSizeMode.StretchImage;

            pfc.AddFontFile("resources/pokefont.ttf");
            pokefont = new Font(pfc.Families[0], 10);

            this.KeyDown += FrmMain_KeyDown;
            this.KeyPreview = true;

            Init_Menu();
        }

        private void Init_Menu()
        {
            PictureBox pbxLogo = new PictureBox();
            pbxLogo.Image = Image.FromFile("resources/logo.png");
            pbxLogo.BackColor = Color.Transparent;
            pbxLogo.Location = new Point(50, 50);
            pbxLogo.Width = 400;
            pbxLogo.Height = 150;
            pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

            Label start = new Label();
            start.BackColor = Color.Black;
            start.Font = new Font(pfc.Families[0], 12);
            start.Dock = DockStyle.Fill;
            start.BorderStyle = BorderStyle.None;
            start.ForeColor = Color.White;
            start.Text = "Press ENTER to Start!";
            start.TextAlign = ContentAlignment.MiddleCenter;

            Panel pnlStart = new Panel();
            pnlStart.Location = new Point(75, 225);
            pnlStart.Width = 350;
            pnlStart.Height = 50;
            pnlStart.BackColor = Color.Black;
            pnlStart.Padding = new Padding(10);
            pnlStart.BorderStyle = BorderStyle.FixedSingle;

            pnlStart.Controls.Add(start);

            pbxBg.Controls.Add(pnlStart);
            pbxBg.Controls.Add(pbxLogo);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pbxBg.Controls.Clear();
                foreach (Pokemon pk in pks)
                {
                    pk.Image.Dispose();
                }
                pks.Clear();
                selectedButton = "";

                if (Directory.Exists("pictures"))
                {
                    Directory.Delete("pictures", true);
                    Directory.CreateDirectory("pictures");
                }
                else if (!Directory.Exists("pictures"))
                {
                    Directory.CreateDirectory("pictures");
                }

                int id1 = rng.Next(1, 1026);
                int id2 = rng.Next(1, 1026);

                AddPokemon(id1, 100, 250, false);
                AddPokemon(id2, 480, 96, true);
                foreach (Pokemon p in pks)
                {
                    AddTextBox(p, true);
                }
                AddChoiceButtons();
            }
        }

        private void AddChoiceButtons()
        {
            Button hp = new Button();
            Button ap = new Button();
            Button df = new Button();
            Button sa = new Button();
            Button sd = new Button();
            Button sp = new Button();

            hp.Text = "HP";
            ap.Text = "AP";
            df.Text = "DF";
            sa.Text = "SA";
            sd.Text = "SD";
            sp.Text = "SP";

            int x = 550;
            int y = 355;

            hp.Location = new Point(x, y);
            df.Location = new Point(x, y + 35);
            sd.Location = new Point(x, y + 70);
            ap.Location = new Point(x + 55, y);
            sa.Location = new Point(x + 55, y + 35);
            sp.Location = new Point(x + 55, y + 70);

            buttons = new List<Button>() { hp, ap, df, sa, sd, sp };

            foreach (Button b in buttons)
            {
                b.Font = pokefont;
                b.Width = 50;
                b.Height = 30;
                b.BackColor = Color.Black;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.Click += B_Click;
                b.TabStop = false;
                pbxBg.Controls.Add(b);
            }

        }

        private void B_Click(object sender, EventArgs e)
        {            
            if (selectedButton != "")
            {
                pbxBg.Focus();
                return;
            }
            
            Button b = (Button)sender;
            selectedButton = b.Text;
            b.BackColor = Color.LightBlue;
            pbxBg.Focus();
            string winnerName = "";

            foreach (Pokemon p in pks)
            {
                p.tbx.Text = "";
                p.tbx.AppendText(p.tbx.nameText, Color.White);
                AddStats(p, p.tbx, p.winnerFlags);
                if (p.winnerFlags[selectedButton.ToLower()])
                {
                    winnerName = p.name;
                }
            }

            Label winner = new Label();
            winner.BackColor = Color.Black;
            winner.Font = new Font(pfc.Families[0], 14);
            winner.Dock = DockStyle.Fill;
            winner.BorderStyle = BorderStyle.None;
            winner.ForeColor = Color.White;
            winner.TextAlign = ContentAlignment.MiddleCenter;            
            winner.Text = String.Format("{0} wins!", winnerName);

            Panel pnl = new Panel();
            pnl.Location = new Point(70, 90);
            pnl.Width = 350;
            pnl.Height = 50;
            pnl.BackColor = Color.Black;
            pnl.Padding = new Padding(10);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            pnl.Controls.Add(winner);
            pbxBg.Controls.Add(pnl);
        }

        private void AddPokemon(int id, int x, int y, bool f)
        {
            Pokemon pk = new Pokemon(id, x, y, f);
            pks.Add(pk);
            pbxBg.Controls.Add(pk);
        }

        private void AddTextBox(Pokemon pk, bool plain)
        {
            pk.winnerFlags = new Dictionary<string, bool>();
            foreach (KeyValuePair<string, int> kvp in pk.stats)
            {
                pk.winnerFlags.Add(kvp.Key, IsWinner(kvp.Key, pk));
            }

            MyRichTextBox tb = new MyRichTextBox();
            tb.BackColor = Color.Black;
            tb.Font = pokefont;
            tb.ReadOnly = true;
            tb.Dock = DockStyle.Fill;
            tb.ScrollBars = RichTextBoxScrollBars.None;
            tb.BorderStyle = BorderStyle.None;
            tb.TabStop = false;

            tb.nameText = String.Format("Name: {0}", pk.name);
            tb.AppendText(tb.nameText, Color.White);
            if (plain)
            {
                AddStats_Plain(pk, tb, pk.winnerFlags);
            }
            else
            {
                AddStats_Plain(pk, tb, pk.winnerFlags);
            }

            pk.tbx = tb;

            Panel pn = new Panel();
            pn.Padding = new Padding(10);
            pn.BackColor = Color.Black;
            pn.BorderStyle = BorderStyle.FixedSingle;
            pn.Controls.Add(tb);
            pn.Width = 250;
            pn.Height = 85;
            pn.Location = new Point(pk.x + 10, pk.y - 85);

            pbxBg.Controls.Add(pn);
        }

        private bool IsWinner(string property, Pokemon pk)
        {
            int i = pks.IndexOf(pk);
            if (i == 0)
            {
                if (pk.stats[property] > pks[1].stats[property])
                {
                    return true;
                }
                return false;
            }
            else if (i == 1)
            {
                if (pk.stats[property] > pks[0].stats[property])
                {
                    return true;
                }
                return false;
            }
            throw new Exception("pk not in pks");
        }

        private void AddStats_Plain(Pokemon pk, MyRichTextBox tb, Dictionary<string, bool> winnerFlags)
        {
            int i = 0;
            foreach (KeyValuePair<string, bool> kvp in winnerFlags)
            {
                if (i == 0)
                {
                    i = 1;
                    tb.AppendText(String.Format("\n{0}: {1}", kvp.Key.ToUpper(), "???"), Color.White);
                }
                else
                {
                    i = 0;
                    tb.AppendText(String.Format("  {0}: {1}", kvp.Key.ToUpper(), "???"), Color.White);
                }
            }
        }

        private void AddStats(Pokemon pk, MyRichTextBox tb, Dictionary<string, bool> winnerFlags)
        {
            int i = 0;
            foreach (KeyValuePair<string, bool> kvp in winnerFlags)
            {
                if (kvp.Value)
                {
                    if (i == 0)
                    {
                        i = 1;
                        tb.AppendText(String.Format("\n{0}: {1}", kvp.Key.ToUpper(), pk.stats[kvp.Key]), Color.Green);
                    }
                    else
                    {
                        i = 0;
                        tb.AppendText(String.Format("  {0}: {1}", kvp.Key.ToUpper(), pk.stats[kvp.Key]), Color.Green);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        i = 1;
                        tb.AppendText(String.Format("\n{0}: {1}", kvp.Key.ToUpper(), pk.stats[kvp.Key]), Color.Red);
                    }
                    else
                    {
                        i = 0;
                        tb.AppendText(String.Format("  {0}: {1}", kvp.Key.ToUpper(), pk.stats[kvp.Key]), Color.Red);
                    }
                }
            }
        }
    }
}
