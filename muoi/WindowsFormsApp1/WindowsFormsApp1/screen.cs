using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class screen : Form
    {
  
        string pathToResource = string.Format("{0}Resources",Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
        public int currentPlayerLevel;
        public PushGame game;
        private Players players;
        public screen()
        {
            InitializeComponent();
            HomeScreenComponent(pathToResource);
        }
        private void changesSceen(WaveDetailTag tag , bool removeClick, bool removePress)
        {
            
            string screenName = tag.callFuntion;
            if (removeClick) removeClickEvent();
            if (removePress) removePressEvent();
            var controlsRef = this.Controls;
            this.Controls.Clear();
            foreach (Control control in controlsRef)
            {
                control.Dispose();
            }
            GC.Collect();
            if (screenName == "MenuScreen")
            {
                MenuScreenComponent(pathToResource);
            }
            else if (screenName == "LevelScreen")
            {
                LevelScreenComponent(pathToResource, tag.Name == "NewgameButton" ? true : false);
            }
            else if (screenName == "GameScreen")
            {
                GameScreenComponent(pathToResource, game.level);
            }
            else if (screenName == "EndScreen")
            {
                EndScreenComponent(pathToResource);
            }

           
        }
        private void removeClickEvent()
        {
            var controlsRef = this.Controls;
            foreach (Control control in controlsRef)
            {
                FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(control);
                PropertyInfo pi = control.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(control, null);
                list.RemoveHandler(obj, list[obj]);
            }
            
        }
        private void removePressEvent()
        {
            var controlsRef = this.Controls;
            foreach (Control control in controlsRef)
            {
                this.KeyUp -= eventKeyPush;
            }

        }
        private void eventChangesSceen(object sender, EventArgs e)
        {
            WaveDetailTag tag = (WaveDetailTag)((Button)sender).Tag; //Tao một opject wave..tag truyền thông tin tag button "new game". sau đó gọi hàm changesceen
            changesSceen(tag, true, false );
        }

        private void eventExitGame(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void eventLoadPlayer(object sender, EventArgs e)
        {
            WaveDetailTag tag = (WaveDetailTag)((Button)sender).Tag;

            players = new Players(pathToResource);
            players.SetCurrentPlayer("player_1");
            currentPlayerLevel = 1;
            if (tag.Name == "NewgameButton")
            {
                players.SaveLevel(pathToResource, 1);
            }
            else
            {
                currentPlayerLevel = players.currentPlayer.Level;
            }
            eventChangesSceen(sender,e);

        }

        private void eventGameStart(object sender, EventArgs e)
        {
            WaveDetailTag tag = (WaveDetailTag)((Button)sender).Tag;
            game = new PushGame(pathToResource, Int32.Parse(tag.Name.Replace("LevelButton_", "")));// gan biên pulic game bằng một new opject pushgame với biến là đường dẫn hiện lại và đường dẫn truyền vô là level hiện tại
            eventChangesSceen(sender, e);

        }
        private void eventGameExit(object sender, EventArgs e)
        {
            WaveDetailTag tag = (WaveDetailTag)((Button)sender).Tag;
            game = null;
            changesSceen(tag, true, true);
        }

        private void eventKeyPush(object sender, KeyEventArgs e)
        {
            if (game != null)
            {
                
                int m = 0;
                if (e.KeyCode == Keys.Down)
                {
                    m = game.moveDown();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    m = game.moveUp();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    m = game.moveLeft();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    m = game.moveRight();
                }

                if (m == 1)
                {
                    Control c = this.Controls.Find("character", true).First();
                    c.Refresh();
                    c.Location = new Point(game.board.minLocationX + game.board.character.positionX, game.board.minLocationY + game.board.character.positionY);
                    foreach(Box box in game.board.boxes)
                    {
                        Control b = this.Controls.Find(string.Format("Box_{0}", box.id), true).First();
                        b.Location = new Point(game.board.minLocationX + box.positionX, game.board.minLocationY + box.positionY);
                    }
                }
                int end = game.checkEnd();
                if (end == 1) {
                    if (game.level < 20 && game.level == currentPlayerLevel)
                    {
                        players.SaveLevel(pathToResource, game.level + 1);
                        currentPlayerLevel = currentPlayerLevel + 1;
                    }
                    changesSceen(new WaveDetailTag { Name = "End", callFuntion = "EndScreen" }, true, true);
                }
            }
            else
            {
                MessageBox.Show("out");
            }
            
        

        }

        private void screen_Load(object sender, EventArgs e)
        {


        }
    }
}
