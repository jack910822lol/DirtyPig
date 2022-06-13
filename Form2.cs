using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DirtyPig
{
    public partial class Form2 : Form
    {
        int leftPlayerID, topPlayerID, rightPlayerID, playerID;
        Socket sckt;
        IPEndPoint endPoint;
        public Form2(string user, string ip, int port)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            sckt.Connect(endPoint);
            //register request
            string msg = "register_request"+" "+ user;
            sendtoserver(msg);

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Thread serverrecv = new Thread(recvFromServer);
            serverrecv.Start();
            serverrecv.IsBackground = true;
        }
        
        public void sendtoserver(string msg)
        {
            byte[] msgBuffer =  Encoding.Default.GetBytes(msg);
            int msgsize = msgBuffer.Length;
            Console.WriteLine(msgsize);
            byte[] msgsizeBuffer = BitConverter.GetBytes(msgsize);
            sckt.Send(msgsizeBuffer);
            sckt.Send(msgBuffer, 0, msgBuffer.Length, 0);
        }

        public void drawcards(PictureBox pb, string str)
        {
            if(str == "mud")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\Mud.png");
            }else if(str == "lc")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\LC.png");
            }else if(str == "rain")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\Rain.png");
            }else if(str == "house")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\House.png");
            }else if(str == "farmer")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\Farmer.png");
            }else if (str == "door_lock")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\Lock.png");
            }else if(str == "thunder")
            {
                pb.Image = Image.FromFile(Application.StartupPath + "\\imgs\\Thunder.png");
            }
        }

        public void submitMsg(string msg)
        {
            List<string> list = new List<string>();
            list = msg.Split().ToList();
            string msg_type = list[0];
            if (msg_type == "join_request")
            {
                string join_player = list[1];
                listBox1.Items.Add("玩家 " + join_player + " 加入遊戲");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            } else if (msg_type == "id_set")
            {
                playerID = Int32.Parse(list[1]);
                if (playerID == 0)
                {
                    leftPlayerID = 1;
                    topPlayerID = 2;
                    rightPlayerID = 3;

                } else if (playerID == 1)
                {
                    leftPlayerID = 2;
                    topPlayerID = 3;
                    rightPlayerID = 0;
                } else if (playerID == 2)
                {
                    leftPlayerID = 3;
                    topPlayerID = 0;
                    rightPlayerID = 1;
                } else if (playerID == 3)
                {
                    leftPlayerID = 0;
                    topPlayerID = 1;
                    rightPlayerID = 2;
                }
            } else if (msg_type == "no_card_picked")
            {
                listBox1.Items.Add("Pick a card first");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            } else if (msg_type == "invalid_move")
            {
                listBox1.Items.Add("invalid_move");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            } else if (msg_type == "card_picked")
            {
                string pickedType = list[1];
                listBox1.Items.Add("You picked " + pickedType);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            } else if (msg_type == "turn")
            {
                string turn_player = list[1];
                listBox1.Items.Add("玩家 " + turn_player + " 的回合");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            } else if (msg_type == "move_success")
            {
                listBox1.Items.Add("move success");
            } else if (msg_type == "game_over") 
            {
                string winner = list[1];
                listBox1.Items.Add("玩家 " + winner + " 獲勝");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                label2.Text = "玩家 " + winner + " 獲勝!!!!!!!!!";
                sendtoserver("bye");
                sckt.Close();
            } else if (msg_type == "game_start" || msg_type == "state_update")
            {
                int user0_name = 1;
                int user0_id = 2;
                int user0_card0_type = 3;
                int user0_card1_type = 4;
                int user0_card2_type = 5;
                int user0_pig0_clean = 6;
                int user0_pig0_house = 7;
                int user0_pig0_lc = 8;
                int user0_pig0_lock = 9;
                int user0_pig1_clean = 10;
                int user0_pig1_house = 11;
                int user0_pig1_lc = 12;
                int user0_pig1_lock = 13;
                int user0_pig2_clean = 14;
                int user0_pig2_house = 15;
                int user0_pig2_lc = 16;
                int user0_pig2_lock = 17;
                int user1_name = 18;
                int user1_id = 19;
                int user1_card0_type = 20;
                int user1_card1_type = 21;
                int user1_card2_type = 22;
                int user1_pig0_clean = 23;
                int user1_pig0_house = 24;
                int user1_pig0_lc = 25;
                int user1_pig0_lock = 26;
                int user1_pig1_clean = 27;
                int user1_pig1_house = 28;
                int user1_pig1_lc = 29;
                int user1_pig1_lock = 30;
                int user1_pig2_clean = 31;
                int user1_pig2_house = 32;
                int user1_pig2_lc = 33;
                int user1_pig2_lock = 34;
                int user2_name = 35;
                int user2_id = 36;
                int user2_card0_type = 37;
                int user2_card1_type = 38;
                int user2_card2_type = 39;
                int user2_pig0_clean = 40;
                int user2_pig0_house = 41;
                int user2_pig0_lc = 42;
                int user2_pig0_lock = 43;
                int user2_pig1_clean = 44;
                int user2_pig1_house = 45;
                int user2_pig1_lc = 46;
                int user2_pig1_lock = 47;
                int user2_pig2_clean = 48;
                int user2_pig2_house = 49;
                int user2_pig2_lc = 50;
                int user2_pig2_lock = 51;
                int user3_name = 52;
                int user3_id = 53;
                int user3_card0_type = 54;
                int user3_card1_type = 55;
                int user3_card2_type = 56;
                int user3_pig0_clean = 57;
                int user3_pig0_house = 58;
                int user3_pig0_lc = 59;
                int user3_pig0_lock = 60;
                int user3_pig1_clean = 61;
                int user3_pig1_house = 62;
                int user3_pig1_lc = 63;
                int user3_pig1_lock = 64;
                int user3_pig2_clean = 65;
                int user3_pig2_house = 66;
                int user3_pig2_lc = 67;
                int user3_pig2_lock = 68;
                if (playerID == 0)
                {
                    //playersname
                    player.Text = list[user0_name];
                    leftPlayer.Text = list[user1_name];
                    topPlayer.Text = list[user2_name];
                    rightPlayer.Text = list[user3_name];
                    //playersID
                    playerID = Int32.Parse(list[user0_id]);
                    leftPlayerID = Int32.Parse(list[user1_id]);
                    topPlayerID = Int32.Parse(list[user2_id]);
                    rightPlayerID = Int32.Parse(list[user3_id]);
                    //playercards
                    drawcards(hand0, list[user0_card0_type]);
                    drawcards(hand1, list[user0_card1_type]);
                    drawcards(hand2, list[user0_card2_type]);
                    //pigs
                    pig0.Image = list[user0_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig1.Image = list[user0_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig2.Image = list[user0_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig0.Image = list[user1_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig1.Image = list[user1_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig2.Image = list[user1_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig0.Image = list[user2_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig1.Image = list[user2_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig2.Image = list[user2_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig0.Image = list[user3_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig1.Image = list[user3_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig2.Image = list[user3_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    //pig attributes
                    pig0House.Visible = list[user0_pig0_house] == "True" ? true : false;
                    pig0Lock.Visible = list[user0_pig0_lock] == "True" ? true : false;
                    pig0Lc.Visible = list[user0_pig0_lc] == "True" ? true : false;
                    pig1House.Visible = list[user0_pig1_house] == "True" ? true : false;
                    pig1Lock.Visible = list[user0_pig1_lock] == "True" ? true : false;
                    pig1Lc.Visible = list[user0_pig1_lc] == "True" ? true : false;
                    pig2House.Visible = list[user0_pig2_house] == "True" ? true : false;
                    pig2Lock.Visible = list[user0_pig2_lock] == "True" ? true : false;
                    pig2Lc.Visible = list[user0_pig2_lc] == "True" ? true : false;
                    leftPig0House.Visible = list[user1_pig0_house] == "True" ? true : false;
                    leftPig0Lock.Visible = list[user1_pig0_lock] == "True" ? true : false;
                    leftPig0Lc.Visible = list[user1_pig0_lc] == "True" ? true : false;
                    leftPig1House.Visible = list[user1_pig1_house] == "True" ? true : false;
                    leftPig1Lock.Visible = list[user1_pig1_lock] == "True" ? true : false;
                    leftPig1Lc.Visible = list[user1_pig1_lc] == "True" ? true : false;
                    leftPig2House.Visible = list[user1_pig2_house] == "True" ? true : false;
                    leftPig2Lock.Visible = list[user1_pig2_lock] == "True" ? true : false;
                    leftPig2Lc.Visible = list[user1_pig2_lc] == "True" ? true : false;
                    topPig0House.Visible = list[user2_pig0_house] == "True" ? true : false;
                    topPig0Lock.Visible = list[user2_pig0_lock] == "True" ? true : false;
                    topPig0Lc.Visible = list[user2_pig0_lc] == "True" ? true : false;
                    topPig1House.Visible = list[user2_pig1_house] == "True" ? true : false;
                    topPig1Lock.Visible = list[user2_pig1_lock] == "True" ? true : false;
                    topPig1Lc.Visible = list[user2_pig1_lc] == "True" ? true : false;
                    topPig2House.Visible = list[user2_pig2_house] == "True" ? true : false;
                    topPig2Lock.Visible = list[user2_pig2_lock] == "True" ? true : false;
                    topPig2Lc.Visible = list[user2_pig2_lc] == "True" ? true : false;
                    rightPig0House.Visible = list[user3_pig0_house] == "True" ? true : false;
                    rightPig0Lock.Visible = list[user3_pig0_lock] == "True" ? true : false;
                    rightPig0Lc.Visible = list[user3_pig0_lc] == "True" ? true : false;
                    rightPig1House.Visible = list[user3_pig1_house] == "True" ? true : false;
                    rightPig1Lock.Visible = list[user3_pig1_lock] == "True" ? true : false;
                    rightPig1Lc.Visible = list[user3_pig1_lc] == "True" ? true : false;
                    rightPig2House.Visible = list[user3_pig2_house] == "True" ? true : false;
                    rightPig2Lock.Visible = list[user3_pig2_lock] == "True" ? true : false;
                    rightPig2Lc.Visible = list[user3_pig2_lc] == "True" ? true : false;
                } else if (playerID == 1)
                {
                    //playersname
                    player.Text = list[user1_name];
                    leftPlayer.Text = list[user2_name];
                    topPlayer.Text = list[user3_name];
                    rightPlayer.Text = list[user0_name];
                    //playersID
                    playerID = Int32.Parse(list[user1_id]);
                    leftPlayerID = Int32.Parse(list[user2_id]);
                    topPlayerID = Int32.Parse(list[user3_id]);
                    rightPlayerID = Int32.Parse(list[user0_id]);
                    //playercards
                    drawcards(hand0, list[user1_card0_type]);
                    drawcards(hand1, list[user1_card1_type]);
                    drawcards(hand2, list[user1_card2_type]);
                    //pigs
                    pig0.Image = list[user1_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig1.Image = list[user1_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig2.Image = list[user1_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig0.Image = list[user2_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig1.Image = list[user2_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig2.Image = list[user2_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig0.Image = list[user3_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig1.Image = list[user3_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig2.Image = list[user3_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig0.Image = list[user0_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig1.Image = list[user0_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig2.Image = list[user0_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    //pigs attributes
                    pig0House.Visible = list[user1_pig0_house] == "True" ? true : false;
                    pig0Lock.Visible = list[user1_pig0_lock] == "True" ? true : false;
                    pig0Lc.Visible = list[user1_pig0_lc] == "True" ? true : false;
                    pig1House.Visible = list[user1_pig1_house] == "True" ? true : false;
                    pig1Lock.Visible = list[user1_pig1_lock] == "True" ? true : false;
                    pig1Lc.Visible = list[user1_pig1_lc] == "True" ? true : false;
                    pig2House.Visible = list[user1_pig2_house] == "True" ? true : false;
                    pig2Lock.Visible = list[user1_pig2_lock] == "True" ? true : false;
                    pig2Lc.Visible = list[user1_pig2_lc] == "True" ? true : false;
                    leftPig0House.Visible = list[user2_pig0_house] == "True" ? true : false;
                    leftPig0Lock.Visible = list[user2_pig0_lock] == "True" ? true : false;
                    leftPig0Lc.Visible = list[user2_pig0_lc] == "True" ? true : false;
                    leftPig1House.Visible = list[user2_pig1_house] == "True" ? true : false;
                    leftPig1Lock.Visible = list[user2_pig1_lock] == "True" ? true : false;
                    leftPig1Lc.Visible = list[user2_pig1_lc] == "True" ? true : false;
                    leftPig2House.Visible = list[user2_pig2_house] == "True" ? true : false;
                    leftPig2Lock.Visible = list[user2_pig2_lock] == "True" ? true : false;
                    leftPig2Lc.Visible = list[user2_pig2_lc] == "True" ? true : false;
                    topPig0House.Visible = list[user3_pig0_house] == "True" ? true : false;
                    topPig0Lock.Visible = list[user3_pig0_lock] == "True" ? true : false;
                    topPig0Lc.Visible = list[user3_pig0_lc] == "True" ? true : false;
                    topPig1House.Visible = list[user3_pig1_house] == "True" ? true : false;
                    topPig1Lock.Visible = list[user3_pig1_lock] == "True" ? true : false;
                    topPig1Lc.Visible = list[user3_pig1_lc] == "True" ? true : false;
                    topPig2House.Visible = list[user3_pig2_house] == "True" ? true : false;
                    topPig2Lock.Visible = list[user3_pig2_lock] == "True" ? true : false;
                    topPig2Lc.Visible = list[user3_pig2_lc] == "True" ? true : false;
                    rightPig0House.Visible = list[user0_pig0_house] == "True" ? true : false;
                    rightPig0Lock.Visible = list[user0_pig0_lock] == "True" ? true : false;
                    rightPig0Lc.Visible = list[user0_pig0_lc] == "True" ? true : false;
                    rightPig1House.Visible = list[user0_pig1_house] == "True" ? true : false;
                    rightPig1Lock.Visible = list[user0_pig1_lock] == "True" ? true : false;
                    rightPig1Lc.Visible = list[user0_pig1_lc] == "True" ? true : false;
                    rightPig2House.Visible = list[user0_pig2_house] == "True" ? true : false;
                    rightPig2Lock.Visible = list[user0_pig2_lock] == "True" ? true : false;
                    rightPig2Lc.Visible = list[user0_pig2_lc] == "True" ? true : false;
                } else if (playerID == 2)
                {
                    //playername
                    player.Text = list[user2_name];
                    leftPlayer.Text = list[user3_name];
                    topPlayer.Text = list[user0_name];
                    rightPlayer.Text = list[user1_name];
                    //playersID
                    playerID = Int32.Parse(list[user2_id]);
                    leftPlayerID = Int32.Parse(list[user3_id]);
                    topPlayerID = Int32.Parse(list[user0_id]);
                    rightPlayerID = Int32.Parse(list[user1_id]);
                    //playercard
                    drawcards(hand0, list[user2_card0_type]);
                    drawcards(hand1, list[user2_card1_type]);
                    drawcards(hand2, list[user2_card2_type]);
                    //pigs
                    pig0.Image = list[user2_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig1.Image = list[user2_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig2.Image = list[user2_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig0.Image = list[user3_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig1.Image = list[user3_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig2.Image = list[user3_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig0.Image = list[user0_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig1.Image = list[user0_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig2.Image = list[user0_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig0.Image = list[user1_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig1.Image = list[user1_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig2.Image = list[user1_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    //pigs attributes
                    pig0House.Visible = list[user2_pig0_house] == "True" ? true : false;
                    pig0Lock.Visible = list[user2_pig0_lock] == "True" ? true : false;
                    pig0Lc.Visible = list[user2_pig0_lc] == "True" ? true : false;
                    pig1House.Visible = list[user2_pig1_house] == "True" ? true : false;
                    pig1Lock.Visible = list[user2_pig1_lock] == "True" ? true : false;
                    pig1Lc.Visible = list[user2_pig1_lc] == "True" ? true : false;
                    pig2House.Visible = list[user2_pig2_house] == "True" ? true : false;
                    pig2Lock.Visible = list[user2_pig2_lock] == "True" ? true : false;
                    pig2Lc.Visible = list[user2_pig2_lc] == "True" ? true : false;
                    leftPig0House.Visible = list[user3_pig0_house] == "True" ? true : false;
                    leftPig0Lock.Visible = list[user3_pig0_lock] == "True" ? true : false;
                    leftPig0Lc.Visible = list[user3_pig0_lc] == "True" ? true : false;
                    leftPig1House.Visible = list[user3_pig1_house] == "True" ? true : false;
                    leftPig1Lock.Visible = list[user3_pig1_lock] == "True" ? true : false;
                    leftPig1Lc.Visible = list[user3_pig1_lc] == "True" ? true : false;
                    leftPig2House.Visible = list[user3_pig2_house] == "True" ? true : false;
                    leftPig2Lock.Visible = list[user3_pig2_lock] == "True" ? true : false;
                    leftPig2Lc.Visible = list[user3_pig2_lc] == "True" ? true : false;
                    topPig0House.Visible = list[user0_pig0_house] == "True" ? true : false;
                    topPig0Lock.Visible = list[user0_pig0_lock] == "True" ? true : false;
                    topPig0Lc.Visible = list[user0_pig0_lc] == "True" ? true : false;
                    topPig1House.Visible = list[user0_pig1_house] == "True" ? true : false;
                    topPig1Lock.Visible = list[user0_pig1_lock] == "True" ? true : false;
                    topPig1Lc.Visible = list[user0_pig1_lc] == "True" ? true : false;
                    topPig2House.Visible = list[user0_pig2_house] == "True" ? true : false;
                    topPig2Lock.Visible = list[user0_pig2_lock] == "True" ? true : false;
                    topPig2Lc.Visible = list[user0_pig2_lc] == "True" ? true : false;
                    rightPig0House.Visible = list[user1_pig0_house] == "True" ? true : false;
                    rightPig0Lock.Visible = list[user1_pig0_lock] == "True" ? true : false;
                    rightPig0Lc.Visible = list[user1_pig0_lc] == "True" ? true : false;
                    rightPig1House.Visible = list[user1_pig1_house] == "True" ? true : false;
                    rightPig1Lock.Visible = list[user1_pig1_lock] == "True" ? true : false;
                    rightPig1Lc.Visible = list[user1_pig1_lc] == "True" ? true : false;
                    rightPig2House.Visible = list[user1_pig2_house] == "True" ? true : false;
                    rightPig2Lock.Visible = list[user1_pig2_lock] == "True" ? true : false;
                    rightPig2Lc.Visible = list[user1_pig2_lc] == "True" ? true : false;
                } else if (playerID == 3)
                {
                    //playersname
                    player.Text = list[user3_name];
                    leftPlayer.Text = list[user0_name];
                    topPlayer.Text = list[user1_name];
                    rightPlayer.Text = list[user2_name];
                    //playersID
                    playerID = Int32.Parse(list[user3_id]);
                    leftPlayerID = Int32.Parse(list[user0_id]);
                    topPlayerID = Int32.Parse(list[user1_id]);
                    rightPlayerID = Int32.Parse(list[user2_id]);
                    //playercards
                    drawcards(hand0, list[user3_card0_type]);
                    drawcards(hand1, list[user3_card1_type]);
                    drawcards(hand2, list[user3_card2_type]);
                    //pigs
                    pig0.Image = list[user3_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig1.Image = list[user3_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    pig2.Image = list[user3_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig0.Image = list[user0_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig1.Image = list[user0_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    leftPig2.Image = list[user0_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig0.Image = list[user1_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig1.Image = list[user1_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    topPig2.Image = list[user1_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig0.Image = list[user2_pig0_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig1.Image = list[user2_pig1_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    rightPig2.Image = list[user2_pig2_clean] == "True" ? (Image.FromFile(Application.StartupPath + "\\imgs\\cleanPig.png")) : (Image.FromFile(Application.StartupPath + "\\imgs\\dirtyPig.png"));
                    //pigs attributes
                    pig0House.Visible = list[user3_pig0_house] == "True" ? true : false;
                    pig0Lock.Visible = list[user3_pig0_lock] == "True" ? true : false;
                    pig0Lc.Visible = list[user3_pig0_lc] == "True" ? true : false;
                    pig1House.Visible = list[user3_pig1_house] == "True" ? true : false;
                    pig1Lock.Visible = list[user3_pig1_lock] == "True" ? true : false;
                    pig1Lc.Visible = list[user3_pig1_lc] == "True" ? true : false;
                    pig2House.Visible = list[user3_pig2_house] == "True" ? true : false;
                    pig2Lock.Visible = list[user3_pig2_lock] == "True" ? true : false;
                    pig2Lc.Visible = list[user3_pig2_lc] == "True" ? true : false;
                    leftPig0House.Visible = list[user0_pig0_house] == "True" ? true : false;
                    leftPig0Lock.Visible = list[user0_pig0_lock] == "True" ? true : false;
                    leftPig0Lc.Visible = list[user0_pig0_lc] == "True" ? true : false;
                    leftPig1House.Visible = list[user0_pig1_house] == "True" ? true : false;
                    leftPig1Lock.Visible = list[user0_pig1_lock] == "True" ? true : false;
                    leftPig1Lc.Visible = list[user0_pig1_lc] == "True" ? true : false;
                    leftPig2House.Visible = list[user0_pig2_house] == "True" ? true : false;
                    leftPig2Lock.Visible = list[user0_pig2_lock] == "True" ? true : false;
                    leftPig2Lc.Visible = list[user0_pig2_lc] == "True" ? true : false;
                    topPig0House.Visible = list[user1_pig0_house] == "True" ? true : false;
                    topPig0Lock.Visible = list[user1_pig0_lock] == "True" ? true : false;
                    topPig0Lc.Visible = list[user1_pig0_lc] == "True" ? true : false;
                    topPig1House.Visible = list[user1_pig1_house] == "True" ? true : false;
                    topPig1Lock.Visible = list[user1_pig1_lock] == "True" ? true : false;
                    topPig1Lc.Visible = list[user1_pig1_lc] == "True" ? true : false;
                    topPig2House.Visible = list[user1_pig2_house] == "True" ? true : false;
                    topPig2Lock.Visible = list[user1_pig2_lock] == "True" ? true : false;
                    topPig2Lc.Visible = list[user1_pig2_lc] == "True" ? true : false;
                    rightPig0House.Visible = list[user2_pig0_house] == "True" ? true : false;
                    rightPig0Lock.Visible = list[user2_pig0_lock] == "True" ? true : false;
                    rightPig0Lc.Visible = list[user2_pig0_lc] == "True" ? true : false;
                    rightPig1House.Visible = list[user2_pig1_house] == "True" ? true : false;
                    rightPig1Lock.Visible = list[user2_pig1_lock] == "True" ? true : false;
                    rightPig1Lc.Visible = list[user2_pig1_lc] == "True" ? true : false;
                    rightPig2House.Visible = list[user2_pig2_house] == "True" ? true : false;
                    rightPig2Lock.Visible = list[user2_pig2_lock] == "True" ? true : false;
                    rightPig2Lc.Visible = list[user2_pig2_lc] == "True" ? true : false;
                }
            }
        }

        public byte[] ReceiveLargeFile(Socket socket, int lenght)
        {
            // send first the length of total bytes of the data to server
            // create byte array with the length that you've send to the server.
            byte[] data = new byte[lenght];  


            int size = lenght; // lenght to reveive
            var total = 0; // total bytes to received
            var dataleft = size; // bytes that havend been received 

            // 1. check if the total bytes that are received < than the size you've send before to the server.
            // 2. if true read the bytes that have not been receive jet
            while (total < size) 
            {
                // receive bytes in byte array data[]
                // from position of total received and if the case data that havend been received.
                var recv = socket.Receive(data, total, dataleft, SocketFlags.None);
                if (recv == 0) // if received data = 0 than stop reseaving
                {
                    data = null;
                    break;
                }
                total += recv;  // total bytes read + bytes that are received
                dataleft -= recv; // bytes that havend been received
            }
            return data; // return byte array and do what you have to do whith the bytes.
        }

        public void recvFromServer()
        {
            while (true)
            {
                try
                {
                    byte[] len = new byte[4];
                    sckt.Receive(len, 0, len.Length, 0);
                    int msg_len = BitConverter.ToInt32(len, 0);
                    byte[] tmp = ReceiveLargeFile(sckt, msg_len);
                    string msg = Encoding.UTF8.GetString(tmp);
                    submitMsg(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("已被斷線");
                    break;
                }
            }
        }
        
        private void pig0_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = playerID.ToString();
            string pigID = "0";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void pig1_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = playerID.ToString();
            string pigID = "1";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void pig2_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = playerID.ToString();
            string pigID = "2";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }
        
        private void leftPig0_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = leftPlayerID.ToString();
            string pigID = "0";
            string msg = "click pig"+" "+pigOwnerID+" "+pigID;
            sendtoserver(msg);
        }

        private void leftPig1_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = leftPlayerID.ToString();
            string pigID = "1";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void leftPig2_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = leftPlayerID.ToString();
            string pigID = "2";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void topPig0_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = topPlayerID.ToString();
            string pigID = "0";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void topPig1_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = topPlayerID.ToString();
            string pigID = "1";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void topPig2_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = topPlayerID.ToString();
            string pigID = "2";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void rightPig0_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = rightPlayerID.ToString();
            string pigID = "0";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void rightPig1_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = rightPlayerID.ToString();
            string pigID = "1";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void rightPig2_Click(object sender, EventArgs e)
        {
            //"click"  "pig"  pig_owner_id  pig_id  
            string pigOwnerID = rightPlayerID.ToString();
            string pigID = "2";
            string msg = "click pig" + " " + pigOwnerID + " " + pigID;
            sendtoserver(msg);
        }

        private void cardSwitch_Click(object sender, EventArgs e)
        {
            string msg = "switch";
            sendtoserver(msg);
        }

        private void hand0_Click(object sender, EventArgs e)
        {
            string msg =  "click hand 0";
            sendtoserver(msg);
        }

        private void hand1_Click(object sender, EventArgs e)
        {
            string msg = "click hand 1";
            sendtoserver(msg);
        }

        private void hand2_Click(object sender, EventArgs e)
        {
            string msg = "click hand 2";
            sendtoserver(msg);
        }
    }
}