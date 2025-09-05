using System.Net.Sockets;
using MafiaGame;

namespace MafiaVisual
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Play_b = new Button();
            Exit_b = new Button();
            CreateRoom_b = new Button();
            Join_b = new Button();
            Back_b1 = new Button();
            Input_tb = new TextBox();
            SendRequest_b = new Button();
            InpText_l = new Label();
            Back_b2 = new Button();
            YourIP_l = new Label();
            Nick_tb = new TextBox();
            Confirm_b = new Button();
            AddPlayer = new Button();
            chat_lb = new ListBox();
            chatbox_tb = new TextBox();
            Send_b = new Button();
            Ready_b = new Button();
            pictureRole_b = new Button();
            yourRole_l = new Label();
            kill_b = new Button();
            check_b = new Button();
            heal_b = new Button();
            voit_b = new Button();
            Skip_b = new Button();
            End_text = new Label();
            mi = new Button();
            si = new Button();
            dk = new Button();
            sh = new Button();
            nn = new Button();
            SuspendLayout();
            // 
            // Play_b
            // 
            Play_b.BackColor = Color.FromArgb(192, 255, 192);
            Play_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Play_b.Location = new Point(280, 204);
            Play_b.Name = "Play_b";
            Play_b.Size = new Size(200, 50);
            Play_b.TabIndex = 0;
            Play_b.Text = "Play";
            Play_b.UseVisualStyleBackColor = false;
            Play_b.Click += Play_b_Click;
            // 
            // Exit_b
            // 
            Exit_b.BackColor = Color.FromArgb(255, 192, 192);
            Exit_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Exit_b.Location = new Point(280, 273);
            Exit_b.Name = "Exit_b";
            Exit_b.Size = new Size(200, 50);
            Exit_b.TabIndex = 1;
            Exit_b.Text = "Exit";
            Exit_b.UseVisualStyleBackColor = false;
            Exit_b.Click += Exit_b_Click;
            // 
            // CreateRoom_b
            // 
            CreateRoom_b.BackColor = Color.FromArgb(192, 255, 192);
            CreateRoom_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            CreateRoom_b.Location = new Point(280, 158);
            CreateRoom_b.Name = "CreateRoom_b";
            CreateRoom_b.Size = new Size(200, 50);
            CreateRoom_b.TabIndex = 2;
            CreateRoom_b.Text = "Create Room";
            CreateRoom_b.UseVisualStyleBackColor = false;
            CreateRoom_b.Visible = false;
            CreateRoom_b.Click += CreateRoom_b_Click;
            // 
            // Join_b
            // 
            Join_b.BackColor = Color.FromArgb(192, 255, 192);
            Join_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Join_b.Location = new Point(280, 232);
            Join_b.Name = "Join_b";
            Join_b.Size = new Size(200, 50);
            Join_b.TabIndex = 3;
            Join_b.Text = "Join";
            Join_b.UseVisualStyleBackColor = false;
            Join_b.Visible = false;
            Join_b.Click += Join_b_Click;
            // 
            // Back_b1
            // 
            Back_b1.BackColor = Color.FromArgb(255, 192, 192);
            Back_b1.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Back_b1.Location = new Point(280, 306);
            Back_b1.Name = "Back_b1";
            Back_b1.Size = new Size(200, 50);
            Back_b1.TabIndex = 4;
            Back_b1.Text = "Back";
            Back_b1.UseVisualStyleBackColor = false;
            Back_b1.Visible = false;
            Back_b1.Click += Back_b1_Click;
            // 
            // Input_tb
            // 
            Input_tb.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Input_tb.Location = new Point(266, 185);
            Input_tb.Name = "Input_tb";
            Input_tb.RightToLeft = RightToLeft.No;
            Input_tb.Size = new Size(228, 40);
            Input_tb.TabIndex = 5;
            Input_tb.TextAlign = HorizontalAlignment.Center;
            Input_tb.Visible = false;
            // 
            // SendRequest_b
            // 
            SendRequest_b.BackColor = Color.FromArgb(192, 255, 192);
            SendRequest_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SendRequest_b.Location = new Point(280, 232);
            SendRequest_b.Name = "SendRequest_b";
            SendRequest_b.Size = new Size(200, 50);
            SendRequest_b.TabIndex = 6;
            SendRequest_b.Text = "Send Request";
            SendRequest_b.UseVisualStyleBackColor = false;
            SendRequest_b.Visible = false;
            SendRequest_b.Click += SendRequest_b_Click;
            // 
            // InpText_l
            // 
            InpText_l.AutoSize = true;
            InpText_l.BackColor = Color.LightGray;
            InpText_l.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            InpText_l.Location = new Point(268, 144);
            InpText_l.Name = "InpText_l";
            InpText_l.Size = new Size(228, 33);
            InpText_l.TabIndex = 7;
            InpText_l.Text = "Input IP Adress";
            InpText_l.Visible = false;
            // 
            // Back_b2
            // 
            Back_b2.BackColor = Color.FromArgb(255, 192, 192);
            Back_b2.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Back_b2.Location = new Point(280, 291);
            Back_b2.Name = "Back_b2";
            Back_b2.Size = new Size(200, 50);
            Back_b2.TabIndex = 8;
            Back_b2.Text = "Back";
            Back_b2.UseVisualStyleBackColor = false;
            Back_b2.Visible = false;
            Back_b2.Click += Back_b2_Click;
            // 
            // YourIP_l
            // 
            YourIP_l.AutoSize = true;
            YourIP_l.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            YourIP_l.Location = new Point(525, 9);
            YourIP_l.Name = "YourIP_l";
            YourIP_l.Size = new Size(120, 47);
            YourIP_l.TabIndex = 9;
            YourIP_l.Text = "label1";
            YourIP_l.Visible = false;
            // 
            // Nick_tb
            // 
            Nick_tb.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Nick_tb.Location = new Point(268, 214);
            Nick_tb.Name = "Nick_tb";
            Nick_tb.RightToLeft = RightToLeft.No;
            Nick_tb.Size = new Size(228, 40);
            Nick_tb.TabIndex = 10;
            Nick_tb.Text = "...";
            Nick_tb.TextAlign = HorizontalAlignment.Center;
            Nick_tb.Visible = false;
            // 
            // Confirm_b
            // 
            Confirm_b.BackColor = Color.FromArgb(192, 255, 192);
            Confirm_b.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Confirm_b.Location = new Point(280, 288);
            Confirm_b.Name = "Confirm_b";
            Confirm_b.Size = new Size(200, 50);
            Confirm_b.TabIndex = 11;
            Confirm_b.Text = "Confirm";
            Confirm_b.UseVisualStyleBackColor = false;
            Confirm_b.Visible = false;
            Confirm_b.Click += Confirm_b_Click;
            // 
            // AddPlayer
            // 
            AddPlayer.BackColor = Color.FromArgb(255, 224, 192);
            AddPlayer.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddPlayer.Location = new Point(666, 338);
            AddPlayer.Name = "AddPlayer";
            AddPlayer.Size = new Size(100, 90);
            AddPlayer.TabIndex = 20;
            AddPlayer.Text = "Add player";
            AddPlayer.UseVisualStyleBackColor = false;
            AddPlayer.Visible = false;
            AddPlayer.Click += AddPlayer_Click;
            // 
            // chat_lb
            // 
            chat_lb.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            chat_lb.FormattingEnabled = true;
            chat_lb.ItemHeight = 29;
            chat_lb.Location = new Point(476, 59);
            chat_lb.Name = "chat_lb";
            chat_lb.Size = new Size(290, 207);
            chat_lb.TabIndex = 21;
            chat_lb.Visible = false;
            // 
            // chatbox_tb
            // 
            chatbox_tb.Font = new Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            chatbox_tb.Location = new Point(476, 291);
            chatbox_tb.Name = "chatbox_tb";
            chatbox_tb.Size = new Size(192, 43);
            chatbox_tb.TabIndex = 22;
            chatbox_tb.Visible = false;
            // 
            // Send_b
            // 
            Send_b.BackColor = Color.FromArgb(192, 255, 192);
            Send_b.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Send_b.Location = new Point(674, 291);
            Send_b.Name = "Send_b";
            Send_b.Size = new Size(92, 43);
            Send_b.TabIndex = 23;
            Send_b.Text = "Send";
            Send_b.UseVisualStyleBackColor = false;
            Send_b.Visible = false;
            Send_b.Click += Send_b_Click;
            // 
            // Ready_b
            // 
            Ready_b.BackColor = Color.FromArgb(192, 255, 192);
            Ready_b.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Ready_b.Location = new Point(476, 340);
            Ready_b.Name = "Ready_b";
            Ready_b.Size = new Size(184, 88);
            Ready_b.TabIndex = 24;
            Ready_b.Text = "Ready";
            Ready_b.UseVisualStyleBackColor = false;
            Ready_b.Visible = false;
            Ready_b.Click += Ready_b_Click;
            // 
            // pictureRole_b
            // 
            pictureRole_b.BackColor = Color.Fuchsia;
            pictureRole_b.BackgroundImage = (Image)resources.GetObject("pictureRole_b.BackgroundImage");
            pictureRole_b.BackgroundImageLayout = ImageLayout.Stretch;
            pictureRole_b.Location = new Point(268, 31);
            pictureRole_b.Name = "pictureRole_b";
            pictureRole_b.Size = new Size(239, 287);
            pictureRole_b.TabIndex = 25;
            pictureRole_b.UseVisualStyleBackColor = false;
            pictureRole_b.Visible = false;
            // 
            // yourRole_l
            // 
            yourRole_l.AutoSize = true;
            yourRole_l.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            yourRole_l.Location = new Point(318, 340);
            yourRole_l.Name = "yourRole_l";
            yourRole_l.Size = new Size(140, 33);
            yourRole_l.TabIndex = 26;
            yourRole_l.Text = "Your role";
            yourRole_l.Visible = false;
            // 
            // kill_b
            // 
            kill_b.BackColor = Color.FromArgb(255, 192, 192);
            kill_b.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            kill_b.Location = new Point(15, 163);
            kill_b.Name = "kill_b";
            kill_b.Size = new Size(62, 37);
            kill_b.TabIndex = 27;
            kill_b.Text = "Kill";
            kill_b.UseVisualStyleBackColor = false;
            kill_b.Visible = false;
            kill_b.Click += kill_b_Click;
            // 
            // check_b
            // 
            check_b.BackColor = Color.FromArgb(192, 192, 255);
            check_b.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            check_b.Location = new Point(15, 206);
            check_b.Name = "check_b";
            check_b.Size = new Size(62, 37);
            check_b.TabIndex = 28;
            check_b.Text = "Chek";
            check_b.UseVisualStyleBackColor = false;
            check_b.Visible = false;
            check_b.Click += check_b_Click;
            // 
            // heal_b
            // 
            heal_b.BackColor = Color.FromArgb(192, 255, 192);
            heal_b.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            heal_b.Location = new Point(104, 162);
            heal_b.Name = "heal_b";
            heal_b.Size = new Size(62, 37);
            heal_b.TabIndex = 29;
            heal_b.Text = "Heal";
            heal_b.UseVisualStyleBackColor = false;
            heal_b.Visible = false;
            heal_b.Click += heal_b_Click;
            // 
            // voit_b
            // 
            voit_b.BackColor = Color.FromArgb(255, 192, 192);
            voit_b.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            voit_b.Location = new Point(15, 344);
            voit_b.Name = "voit_b";
            voit_b.Size = new Size(167, 89);
            voit_b.TabIndex = 30;
            voit_b.Text = "Voit";
            voit_b.UseVisualStyleBackColor = false;
            voit_b.Visible = false;
            voit_b.Click += voit_b_Click;
            // 
            // Skip_b
            // 
            Skip_b.BackColor = Color.FromArgb(192, 255, 192);
            Skip_b.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Skip_b.Location = new Point(621, 349);
            Skip_b.Name = "Skip_b";
            Skip_b.Size = new Size(167, 89);
            Skip_b.TabIndex = 31;
            Skip_b.Text = "Skip";
            Skip_b.UseVisualStyleBackColor = false;
            Skip_b.Visible = false;
            Skip_b.Click += Skip_b_Click;
            // 
            // End_text
            // 
            End_text.AutoSize = true;
            End_text.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            End_text.Location = new Point(291, 120);
            End_text.Name = "End_text";
            End_text.Size = new Size(120, 47);
            End_text.TabIndex = 32;
            End_text.Text = "label1";
            End_text.Visible = false;
            // 
            // mi
            // 
            mi.BackgroundImage = (Image)resources.GetObject("mi.BackgroundImage");
            mi.Location = new Point(28, 17);
            mi.Name = "mi";
            mi.Size = new Size(1, 1);
            mi.TabIndex = 33;
            mi.Text = "button1";
            mi.UseVisualStyleBackColor = true;
            mi.Visible = false;
            // 
            // si
            // 
            si.BackgroundImage = (Image)resources.GetObject("si.BackgroundImage");
            si.Location = new Point(28, 46);
            si.Name = "si";
            si.Size = new Size(1, 1);
            si.TabIndex = 34;
            si.Text = "button2";
            si.UseVisualStyleBackColor = true;
            si.Visible = false;
            // 
            // dk
            // 
            dk.BackgroundImage = (Image)resources.GetObject("dk.BackgroundImage");
            dk.Location = new Point(28, 75);
            dk.Name = "dk";
            dk.Size = new Size(1, 1);
            dk.TabIndex = 35;
            dk.Text = "button3";
            dk.UseVisualStyleBackColor = true;
            dk.Visible = false;
            // 
            // sh
            // 
            sh.BackgroundImage = (Image)resources.GetObject("sh.BackgroundImage");
            sh.Location = new Point(28, 104);
            sh.Name = "sh";
            sh.Size = new Size(1, 1);
            sh.TabIndex = 36;
            sh.Text = "button1";
            sh.UseVisualStyleBackColor = true;
            sh.Visible = false;
            // 
            // nn
            // 
            nn.BackgroundImage = (Image)resources.GetObject("nn.BackgroundImage");
            nn.Location = new Point(64, 12);
            nn.Name = "nn";
            nn.Size = new Size(1, 1);
            nn.TabIndex = 37;
            nn.Text = "button1";
            nn.UseVisualStyleBackColor = true;
            nn.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(nn);
            Controls.Add(sh);
            Controls.Add(dk);
            Controls.Add(si);
            Controls.Add(mi);
            Controls.Add(End_text);
            Controls.Add(Skip_b);
            Controls.Add(voit_b);
            Controls.Add(heal_b);
            Controls.Add(check_b);
            Controls.Add(kill_b);
            Controls.Add(yourRole_l);
            Controls.Add(pictureRole_b);
            Controls.Add(Ready_b);
            Controls.Add(Send_b);
            Controls.Add(chatbox_tb);
            Controls.Add(chat_lb);
            Controls.Add(AddPlayer);
            Controls.Add(Confirm_b);
            Controls.Add(Nick_tb);
            Controls.Add(YourIP_l);
            Controls.Add(Back_b2);
            Controls.Add(InpText_l);
            Controls.Add(SendRequest_b);
            Controls.Add(Input_tb);
            Controls.Add(Back_b1);
            Controls.Add(Join_b);
            Controls.Add(CreateRoom_b);
            Controls.Add(Exit_b);
            Controls.Add(Play_b);
            Name = "Form1";
            Text = "Mafia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Play_b;
        private Button Exit_b;
        private Button CreateRoom_b;
        private Button Join_b;
        private Button Back_b1;
        private TextBox Input_tb;
        private Button SendRequest_b;
        private Label InpText_l;
        private Button Back_b2;
        private Label YourIP_l;


        bool createdType = false;
        int PlayerNumber = 0;
        string NickName = "";
        bool register = false;
        bool is_game = false;
        bool is_night = true;
        string your_role;
        List<int> choosed = new List<int>();
        string CNick;
        List<int> dead = new List<int>();
        List<int> randoms = new List<int>();
        List<string> roles = new List<string> {
            "The Mafia",
            "The Sheriff",
            "The Doctor",
            "The Citizen",
            "The Citizen",
            "The Citizen",
            "The Citizen",
            "The Mafia",
            "The Citizen"
        };
        TcpClient client = new TcpClient();
        Stream stream;
        List<Stream>streams = new List<Stream>();
        private static TcpListener listener;
        private static List<TcpClient> clients = new List<TcpClient>();
        int endGame = 3;
        PlayerService DbPart;

        private TextBox Nick_tb;
        private Button Confirm_b;
        private Button AddPlayer;
        private ListBox chat_lb;
        private TextBox chatbox_tb;
        private Button Send_b;
        private Button Ready_b;
        private Button pictureRole_b;
        private Label yourRole_l;
        private Button kill_b;
        private Button check_b;
        private Button heal_b;
        private Button voit_b;
        private Button Skip_b;
        private Label End_text;
        private Button mi;
        private Button si;
        private Button dk;
        private Button sh;
        private Button nn;
    }
}
