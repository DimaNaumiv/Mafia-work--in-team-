using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Server;
using MafiaGame;

namespace MafiaVisual
{
    public partial class Form1 : Form
    {
        public List<Button> player_bs = new List<Button>();
        Server.GameServer ServerPart = new GameServer();
        public Form1()
        {
            InitializeComponent();
        }
        public async Task StartServerAsync()
        {
            listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                string ansver;
                string massege = await ServerPart.ReceiveMessage(client.GetStream());
                if (massege[0] == 'r')
                {
                    clients.Add(client);
                    streams.Add(client.GetStream());
                    StringBuilder sb = new StringBuilder();
                    ansver = "c " + NickName;
                    for(int i = 1; i < player_bs.Count; i++)
                    {
                        ansver = ansver + " " +player_bs[i].Text;
                    }
                    for (int i = 2; i < massege.Length; i++)
                    {
                        sb.Append(massege[i]);
                    }
                    await AddPlayerr(sb.ToString());
                    if (clients.Count >= 2)
                    {
                        foreach(var i in streams)
                        {
                            ServerPart.SendMessage(i, "a " + sb.ToString());
                        }
                    }
                    ServerPart.SendMessage(streams[streams.Count-1], ansver);
                }
                else if (massege[0] == 'a')
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 2; i < massege.Length; i++)
                    {
                        sb.Append(massege[i]);
                    }
                    await AddPlayerr(sb.ToString());
                }
                else if (massege[0] == 'm')
                {
                    massege.Remove(massege.First());
                    //string newmassege = "t" + massege;
                    massege.Remove(massege.First());
                    //foreach(var i in clients)
                    //{
                    //    ServerPart.SendMessage(i,newmassege);
                    //}
                    chat_lb.Invoke(new Action(() => chat_lb.Items.Add(massege)));
                    chatbox_tb.Text = "";
                }
                else if (massege[0]=='t')
                {
                    //AddPlayer.Text = "Get message";
                    massege.Remove(massege.First());
                    massege.Remove(massege.First());
                    chat_lb.Invoke(new Action(() => chat_lb.Items.Add(massege)));
                    chatbox_tb.Text = "";
                }
            }
        }
        private void Exit_b_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Play_b_Click(object sender, EventArgs e)
        {
            Play_b.Visible = false;
            Exit_b.Visible = false;
            End_text.Visible = false;


            if (register == false)
            {
                Nick_tb.Visible = true;
                Confirm_b.Visible = true;
            }
            else
            {
                CreateRoom_b.Visible = true;
                Join_b.Visible = true;
                Back_b1.Visible = true;
            }
        }
        private void Confirm_b_Click(object sender, EventArgs e)
        {
            if (Nick_tb.Text != "..." && Nick_tb.Text.Length > 1)
            {
                NickName = Nick_tb.Text;
                register = true;

                Nick_tb.Visible = false;
                Confirm_b.Visible = false;

                CreateRoom_b.Visible = true;
                Join_b.Visible = true;
                Back_b1.Visible = true;
            }


        }
        private void Back_b1_Click(object sender, EventArgs e)
        {
            Play_b.Visible = true;
            Exit_b.Visible = true;

            CreateRoom_b.Visible = false;
            Join_b.Visible = false;
            Back_b1.Visible = false;
        }
        private void Join_b_Click(object sender, EventArgs e)
        {
            CreateRoom_b.Visible = false;
            Join_b.Visible = false;
            Back_b1.Visible = false;

            InpText_l.Visible = true;
            Input_tb.Visible = true;
            SendRequest_b.Visible = true;
            Back_b2.Visible = true;
        }

        private void Back_b2_Click(object sender, EventArgs e)
        {
            InpText_l.Visible = false;
            Input_tb.Visible = false;
            SendRequest_b.Visible = false;
            Back_b2.Visible = false;

            CreateRoom_b.Visible = true;
            Join_b.Visible = true;
            Back_b1.Visible = true;
        }
        private async void SendRequest_b_Click(object sender, EventArgs e)
        {
            await client.ConnectAsync(Input_tb.Text, 12345);
            stream = client.GetStream();
            ServerPart.SendMessage(stream, "r "+NickName);
            string massege = await ServerPart.ReceiveMessage(stream);

            if (massege[0] == 'c')
            {
                SendRequest_b.Visible = false;
                InpText_l.Visible = false;
                Input_tb.Visible = false;
                Back_b2.Visible = false;
                createdType = false;
                List<string> names = new List<string>();
                StringBuilder sb = new StringBuilder();
                foreach(char i in massege)
                {
                    if(i !=' ')
                    {
                        sb.Append(i);
                    }
                    else
                    {
                        names.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                names.Add(sb.ToString());
                names.Remove(names.First());

                PlayerNumber = 1;
                player_bs.Add(new Button
                {
                    Size = new Size(113, 133),
                    BackColor = Color.FromArgb(192, 255, 192),
                    Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Text = names[0],
                    TextAlign = ContentAlignment.BottomCenter,
                    Visible = true,
                    Location = new Point(12, 20),
                    TabIndex = 999
                });
                player_bs.Add(new Button
                {
                    Size = new Size(113, 133),
                    BackColor = Color.FromArgb(192, 255, 192),
                    Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Text = NickName,
                    TextAlign = ContentAlignment.BottomCenter,
                    Visible = true,
                    Location = new Point(162, 20),
                    TabIndex = 999
                });

                this.Controls.Add(player_bs[0]);
                for (int i = 1; i < names.Count; i++)
                {
                    await AddPlayerr(names[i]);
                }
                this.Controls.Add(player_bs[1]);

                chatbox_tb.Visible = true;
                Send_b.Visible = true;
                chat_lb.Visible = true;
                Ready_b.Visible = true;
            }
        }
        async Task<string> CleanInfo(StringBuilder info)
        {
            StringBuilder word = new StringBuilder();
            bool cline = false;
            foreach (char i in info.ToString())
            {
                if (i == ' ' && cline == false)
                {
                    word.Clear();
                }
                else if (i != '.' && cline == false)
                {
                    word.Append(i);
                }
                else if (cline == true && i == '\n')
                {
                    break;
                }
                else if (cline == true && word.ToString() == "IPv4 Address. . . . . . . . . . . :")
                {
                    word.Clear();
                }
                else if (cline == true)
                {
                    word.Append(i);
                }
                if (word.ToString() == "IPv4")
                {
                    cline = true;
                }
            }
            info = word;

            return info.ToString();
        }
        async Task<string> GetIP()
        {
            StringBuilder IP = new StringBuilder();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                FileName = "cmd.exe",
                Arguments = "/c ipconfig",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    IP.AppendLine(e.Data);
                }
            };
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            string NewIp = await CleanInfo(IP);
            return NewIp;
        }
        private async void CreateRoom_b_Click(object sender, EventArgs e)
        {
            DbPart = new PlayerService();
            CreateRoom_b.Visible = false;
            Join_b.Visible = false;
            Back_b1.Visible = false;

            YourIP_l.Text = await GetIP();
            YourIP_l.Visible = true;

            chatbox_tb.Visible = true;
            Send_b.Visible = true;
            chat_lb.Visible = true;
            Ready_b.Visible = true;
            createdType = true;
            AddPlayer.Visible = true;

            player_bs.Add(new Button
            {
                Size = new Size(113, 133),
                BackColor = Color.FromArgb(192, 255, 192),
                Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Text = NickName,
                TextAlign = ContentAlignment.BottomCenter,
                Visible = true,
                Location = new Point(12, 20),
                TabIndex = 999,
            });
            this.Controls.Add(player_bs[0]);

            await StartServerAsync();
        }
        public async Task AddPlayerr(string nick)
        {
            AddPlayer.Text = PlayerNumber.ToString();
            int y = player_bs[PlayerNumber].Location.Y;
            int x = player_bs[PlayerNumber].Location.X;
            PlayerNumber++;
            if (PlayerNumber == 3)
            {
                y = y + 140;
                x = player_bs[0].Location.X - 150;
            }
            else if (PlayerNumber == 6)
            {
                y = y + 140;
                x = player_bs[0].Location.X - 150;
            }
            if (PlayerNumber <= 8)
            {
                AddPlayer.Text = PlayerNumber.ToString();
                Button nb = new Button();
                nb.Size = player_bs[0].Size;
                nb.Location = new Point(x + 150, y);
                nb.Text = nick;
                nb.Font = player_bs[0].Font;
                nb.BackColor = player_bs[0].BackColor;
                nb.TabIndex = 1000 + PlayerNumber;
                nb.TextAlign = ContentAlignment.BottomCenter;
                player_bs.Add(nb);
                this.Controls.Add(player_bs[PlayerNumber]);
                chat_lb.Invoke(new Action(() => chat_lb.Items.Add(player_bs[PlayerNumber].Text + ": " + "conected")));
            }
            else
            {
                /////////////////////////////////
            }
        }
        public string GetName()
        {
            return NickName;
        }
        public void ChatAddText(string a)
        {
            chat_lb.Invoke(new Action(() => chat_lb.Items.Add(a)));
        }
        private async void AddPlayer_Click(object sender, EventArgs e)
        {
            await AddPlayerr($"x{PlayerNumber}");
            chat_lb.Invoke(new Action(() => chat_lb.Items.Add(player_bs[PlayerNumber].Text + ": " + "hi")));
        }
        private async void Send_b_Click(object sender, EventArgs e)
        {
            if(createdType == true)
            {
                if (chatbox_tb.Text.Length > 0)
                {
                    string massege = "t " + NickName + ": " + chatbox_tb.Text;
                    foreach (var i in streams)
                    {
                        ServerPart.SendMessage(i, massege);
                    }
                    chat_lb.Invoke(new Action(() => chat_lb.Items.Add(chatbox_tb.Text)));
                    chatbox_tb.Text = "";
                }
            }
            else
            {
                if (chatbox_tb.Text.Length > 0)
                {
                    string massege = "m " + NickName + ": " + chatbox_tb.Text;
                    ServerPart.SendMessage(stream, massege);
                    chat_lb.Invoke(new Action(() => chat_lb.Items.Add(chatbox_tb.Text)));
                    chatbox_tb.Text = "";
                }
            }
        }
        private void Reloc(ref List<Button> a)
        {
            foreach (var i in a)
            {
                i.Location = new Point(100, 20);
            }
            int x = player_bs.Last().Location.X;
            int y = player_bs.Last().Location.Y;
            for (int i = 0; i < a.Count; i++)
            {
                if (i > 0)
                {
                    a[i].Location = new Point(a[i - 1].Location.X + 150, y);
                }
                if (i == 4)
                {
                    y = y + 140;
                    a[i].Location = new Point(x, y);
                }
            }
        }
        private void Reloc2(ref List<Button> a)
        {
            foreach (var i in a)
            {
                i.Location = new Point(5, 5);
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (i > 0)
                {
                    a[i].Location = new Point(a[i - 1].Location.X + 120, a[i - 1].Location.Y);
                }
                if (i == 2 || i == 6)
                {
                    a[i].Location = new Point(a[i - 1].Location.X + 430, a[i - 1].Location.Y);
                }
                else if (i == 4)
                {
                    a[i].Location = new Point(a[0].Location.X, a[0].Location.Y + 150);
                }
            }
        }
        private void SetRoles()
        {
            int rnum = new Random().Next(0, player_bs.Count);
            bool tf = false;
            while (true)
            {
                if (randoms.Count == player_bs.Count)
                {
                    break;
                }
                foreach (int j in randoms)
                {
                    if (rnum == j)
                    {
                        tf = true;
                        break;
                    }
                }
                if (tf == false)
                {
                    randoms.Add(rnum);
                }
                else
                {
                    tf = false;
                }
                rnum = new Random().Next(0, player_bs.Count);
            }

        }
        private void Ready_b_Click(object sender, EventArgs e)
        {
            AddPlayer.Visible = false;

            is_game = true;
            foreach (var i in player_bs)
            {
                i.Visible = false;
            }

            chatbox_tb.Visible = false;
            Send_b.Visible = false;
            chat_lb.Visible = false;
            chat_lb.Items.Clear();
            Ready_b.Visible = false;
            YourIP_l.Visible = false;

            chatbox_tb.Location = new Point(chatbox_tb.Location.X - 225, chatbox_tb.Location.Y + 100);
            Send_b.Location = new Point(Send_b.Location.X - 225, Send_b.Location.Y + 100);
            chat_lb.Height = chat_lb.Height + 175;
            chat_lb.Location = new Point(chat_lb.Location.X - 225, chat_lb.Location.Y - 53);

            if (createdType == true)
            {
                SetRoles();
                your_role = roles[randoms[0]];
                DbPart.AddPlayer(NickName, your_role, true);
                randoms.Remove(randoms[0]);
            }
            if (your_role == roles[0])
            {
                pictureRole_b.BackgroundImage = mi.BackgroundImage;
            }
            else if (your_role == roles[1])
            {
                pictureRole_b.BackgroundImage = sh.BackgroundImage;
            }
            else if (your_role == roles[2])
            {
                pictureRole_b.BackgroundImage = dk.BackgroundImage;
            }
            else if (your_role == roles[3])
            {
                pictureRole_b.BackgroundImage = si.BackgroundImage;
            }

            yourRole_l.Text = your_role;
            yourRole_l.Visible = true;
            pictureRole_b.Visible = true;
            Task.Delay(3000).Wait();
            yourRole_l.Visible = false;
            pictureRole_b.Visible = false;

            if (player_bs[0].Text == NickName)
            {
                player_bs.Remove(player_bs[0]);
            }
            else
            {
                player_bs.Remove(player_bs[1]);
            }
            PlayerNumber--;

            Reloc(ref player_bs);
            for (int i = 0; i < player_bs.Count; i++)
            {
                player_bs[i].Visible = true;
                DbPart.AddPlayer( player_bs[i].Text,roles[randoms[i]],true );
                switch (i)
                {
                    case 0:
                        player_bs[0].Click += PrsonClick1;
                        break;
                    case 1:
                        player_bs[1].Click += PrsonClick2;
                        break;
                    case 2:
                        player_bs[2].Click += PrsonClick3;
                        break;
                    case 3:
                        player_bs[3].Click += PrsonClick4;
                        break;
                    case 4:
                        player_bs[4].Click += PrsonClick5;
                        break;
                    case 5:
                        player_bs[5].Click += PrsonClick6;
                        break;
                    case 6:
                        player_bs[6].Click += PrsonClick7;
                        break;
                    case 7:
                        player_bs[7].Click += PrsonClick8;
                        break;
                    case 8:
                        player_bs[8].Click += PrsonClick9;
                        break;
                }
            }

        }
        private void ShowChat()
        {
            chatbox_tb.Visible = true;
            Send_b.Visible = true;
            chat_lb.Visible = true;
        }
        private void KilledMifia()
        {
            if (dead.Count >= 1 && roles[randoms[dead.Last()]] == "The Mafia")
            {
                foreach(var i in player_bs)
                {
                    i.Visible = false;
                }
                endGame = 1;
                DbPart.End();
                End_text.Text = "City won";

                End_text.Visible = true;
                Play_b.Visible = true;
                Exit_b.Visible = true;
            }
        }
        private void KilledPeople()
        {
            int count = 0;
            int ms = 1;
            foreach(var i in dead)
            {
                if (roles[randoms[i]]!="The Mafia")
                {
                    count++;
                }
            }
            if (player_bs.Count == 9)
            {
                ms++;
            }
            if(player_bs.Count+1-ms-count == ms)
            {
                foreach (var i in player_bs)
                {
                    i.Visible = false;
                }
                endGame = 0;
                DbPart.End();
                End_text.Text = "Mafias won";

                End_text.Visible = true;
                Play_b.Visible = true;
                Exit_b.Visible = true;
            }
        }
        private void VisualKCH()
        {
            kill_b.Visible = false;
            heal_b.Visible = false;
            check_b.Visible = false;

            KilledMifia();

            if (endGame == 3)
            {
                Skip_b.Visible = true;
                voit_b.Visible = true;



                ShowChat();

                is_night = false;
                Reloc2(ref player_bs);
                if (dead.Count > 0)
                {
                    player_bs[dead.Last()].Text = "Dead";
                    player_bs[dead.Last()].BackColor = Color.Red;
                    player_bs[dead.Last()].Enabled = false;
                }
            }   
        }
        private void heal_b_Click(object sender, EventArgs e)
        {
            if (dead.Count > 0)
            {
                if (dead.Last() == choosed.Last())
                {
                    chat_lb.Items.Remove(chat_lb.Items[chat_lb.Items.Count-1]);
                    ChatAddText($"{player_bs[choosed.Last()].Text} was healed");
                    DbPart.ChengeState(player_bs[choosed.Last()].Text, true);
                    dead.Remove(dead.Last());
                }
            }
            else
            {
                ChatAddText($"{player_bs[choosed.Last()].Text} was healed");

            }
            VisualKCH();
        }
        private void kill_b_Click(object sender, EventArgs e)
        {
            dead.Add(choosed.Last());
            DbPart.ChengeState(player_bs[dead.Last()].Text,false);
            ChatAddText($"{player_bs[dead.Last()].Text} was killed");
            choosed.Clear();
            choosed.Add(999);
            KilledPeople();
            VisualKCH();
        }
        private void check_b_Click(object sender, EventArgs e)
        {
            ChatAddText($"{player_bs[choosed.Last()].Text} has role {roles[randoms[choosed.Last()]]}");
            VisualKCH();
        }

        private void ClickOper(int l)
        {
            if (is_night == true)
            {
                choosed.Add(l);
                if(your_role == "The Mafia")
                {
                    kill_b.Location = player_bs[l].Location;

                    kill_b.Visible = true;
                }
                else if (your_role == "The Sheriff")
                {
                    kill_b.Location = player_bs[l].Location;
                    check_b.Location = new Point(kill_b.Location.X, kill_b.Location.Y + 95);

                    kill_b.Visible = true;
                    check_b.Visible = true;
                }
                else if (your_role == "The Doctor")
                {
                    heal_b.Location = player_bs[l].Location;

                    heal_b.Visible = true;
                }
            }
            else
            {
                if (choosed.Count == 1)
                {
                    CNick = player_bs[l].Text;
                    player_bs[l].Text = "Choosen";
                }
                else
                {
                    if (CNick != "Skip")
                    {
                        player_bs[choosed.Last()].Text = CNick;
                        CNick = player_bs[l].Text;
                        player_bs[l].Text = "Choosen";
                    }
                    else
                    {
                        Skip_b.Text = "Skip";
                        CNick = player_bs[l].Text;
                        player_bs[l].Text = "Cossed";
                    }
                }
                choosed.Add(l);
            }
        }
        private void Skip_b_Click(object sender, EventArgs e)
        {
             if(choosed.Count>1)
            {
                if (choosed.Last() != 999)
                {
                    player_bs[choosed.Last()].Text = CNick;
                }
                CNick = "Skip";
                Skip_b.Text = "Cossed";
            }
            else
            {
                CNick = "Skip";
                Skip_b.Text = "Cossed";
            }
            choosed.Add(999);
        }

        private void voit_b_Click(object sender, EventArgs e)
        {
            if(choosed.Count != 0)
            {
                if (choosed.Last() != 999)
                {
                    dead.Add(choosed.Last());
                    KilledMifia();
                    KilledPeople();
                    player_bs[dead.Last()].Text = "Dead";
                    player_bs[dead.Last()].BackColor = Color.Red;
                    player_bs[dead.Last()].Enabled = false;
                }
                else
                {
                    Skip_b.Text = "Skip";
                }
                choosed.Clear();
                chat_lb.Items.Clear();

                chatbox_tb.Visible = false;
                Send_b.Visible = false;
                chat_lb.Visible = false;
                Skip_b.Visible=false;
                voit_b.Visible=false;

                is_night = true;


                Reloc(ref player_bs);
            }
        }
        private void PrsonClick1(object sender, EventArgs e)
        {
            ClickOper(0);
        }
        private void PrsonClick2(object sender, EventArgs e)
        {
            ClickOper(1);
        }
        private void PrsonClick3(object sender, EventArgs e)
        {
            ClickOper(2);
        }
        private void PrsonClick4(object sender, EventArgs e)
        {
            ClickOper(3);
        }
        private void PrsonClick5(object sender, EventArgs e)
        {
            ClickOper(4);
        }
        private void PrsonClick6(object sender, EventArgs e)
        {
            ClickOper(5);
        }
        private void PrsonClick7(object sender, EventArgs e)
        {
            ClickOper(6);
        }
        private void PrsonClick8(object sender, EventArgs e)
        {
            ClickOper(7);
        }
        private void PrsonClick9(object sender, EventArgs e)
        {
            ClickOper(8);
        }
    }
}
