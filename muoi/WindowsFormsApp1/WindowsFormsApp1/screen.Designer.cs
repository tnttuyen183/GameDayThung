using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
namespace WindowsFormsApp1
{
    partial class screen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "screen";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Game Day Thung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.screen_Load);
            this.ResumeLayout(false);

        }

        private void HomeScreenComponent(String pathToResource)
        {
            string BackgroundPath = string.Format("{0}\\Image\\background\\homescreen.png", pathToResource);
            // khung
            PictureBox BorderImage = new PictureBox()
            {
                Name = "BorderImage",
                Height = 785,
                Width = 1207,
                Location = new Point((this.ClientSize.Width - 1207) / 2, (this.ClientSize.Height - 785 - 104) / 2),
                BackColor = Color.Transparent,
                Image = Image.FromFile(string.Format("{0}\\Image\\icon\\khungtuong.png", pathToResource))
            };
            // button
            Button PlayButton;
            PlayButton = new Button()
            {
                Name = "PlayButton",
                Height = 93,
                Width = 430,
                Location = new Point((this.ClientSize.Width - 430) / 2, this.ClientSize.Height - 465),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\play.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "PlayButton",
                    callFuntion = "MenuScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            PlayButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PlayButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.Click += eventChangesSceen;

            // screen
            this.BackgroundImage = Image.FromFile(BackgroundPath);
            this.Controls.Add(PlayButton);
            this.Controls.Add(BorderImage);
        }

        private void MenuScreenComponent(String pathToResource)
        {
            // khung
            PictureBox BorderImage = new PictureBox()
            {

                Name = "MenuImage",
                Height = 380,
                Width = 525,
                Location = new Point((this.ClientSize.Width - 525) / 2, (this.ClientSize.Height - 631 - 104) / 2),
                BackColor = Color.Transparent,
                Image = Image.FromFile(string.Format("{0}\\Image\\icon\\menu.png", pathToResource))
            };
            BorderImage.TabIndex = 1;
            BorderImage.TabStop = false;

            // button
            Button PlayButton;
            PlayButton = new Button()
            {
                Name = "NewgameButton",
                Height = 169,
                Width = 316,
                Location = new Point((this.ClientSize.Width - 316) / 2 - 366, this.ClientSize.Height - 465),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\newgame.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "NewgameButton",
                    callFuntion = "LevelScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            PlayButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PlayButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.Click += eventLoadPlayer;

            Button ContinueButton;
            ContinueButton = new Button()
            {
                Name = "ContinuteButton",
                Height = 169,
                Width = 316,
                Location = new Point((this.ClientSize.Width - 316) / 2, this.ClientSize.Height - 465),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\continute.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "ContinuteButton",
                    callFuntion = "LevelScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ContinueButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ContinueButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ContinueButton.FlatAppearance.BorderSize = 0;
            ContinueButton.Click += eventLoadPlayer;

            Button ExitButton;
            ExitButton = new Button()
            {
                Name = "ExitButton",
                Height = 169,
                Width = 316,
                Location = new Point((this.ClientSize.Width - 316) / 2 + 366, this.ClientSize.Height - 465),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\exit.png", pathToResource)),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ExitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.Click += eventExitGame;

            // screen
            this.Controls.Add(BorderImage);
            this.Controls.Add(PlayButton);
            this.Controls.Add(ContinueButton);
            this.Controls.Add(ExitButton);
        }

        private void LevelScreenComponent(String pathToResource, bool isNewGame)
        {

            string BackgroundPath = string.Format("{0}\\Image\\background\\homescreen_2.png", pathToResource);
            // khung
            PictureBox BorderImage = new PictureBox()
            {

                Name = "LevelImage",
                Height = 231,
                Width = 701,
                Location = new Point((this.ClientSize.Width - 701) / 2, 10),
                BackColor = Color.Transparent,
                Image = Image.FromFile(string.Format("{0}\\Image\\icon\\level.png", pathToResource))
            };

            // button
            Button ExitButton;
            ExitButton = new Button()
            {
                Name = "ReturnButton",
                Height = 85,
                Width = 203,
                Location = new Point(130, this.ClientSize.Height - 135),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\return.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "ReturnButton",
                    callFuntion = "MenuScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ExitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.Click += eventChangesSceen;
            ;

            List<Button> LevelButtonList = new List<Button>();
            for (int r = 1; r < 5; r++)
            {
                for (int i = 1; i < 6; i++)
                {
                    int l = 5 * (r - 1) + i;
                    Button LevelButton;
                    string bg;
                    string name = string.Format("LevelButton_{0}", l);
                    if (l < currentPlayerLevel)
                    {
                        bg = string.Format("{0}\\Image\\button\\level_1_{1}.png", pathToResource, l);
                    }
                    else if (l == currentPlayerLevel)
                    {
                        bg = string.Format("{0}\\Image\\button\\level_2_{1}.png", pathToResource, l);
                    }
                    else
                    {
                        bg = string.Format("{0}\\Image\\button\\level_3_{1}.png", pathToResource, l);
                    }
                    LevelButton = new Button()
                    {
                        Name = name,
                        Height = 180,
                        Width = 180,
                        Location = new Point((this.ClientSize.Width - 200 * 5 + 20) / 2 + 200 * (i - 1), 250 + 200 * (r - 1)),
                        BackgroundImage = Image.FromFile(bg),
                        Tag = new WaveDetailTag()
                        {
                            Name = name,
                            callFuntion = "GameScreen"
                        },
                        BackColor = Color.Transparent,
                        FlatStyle = FlatStyle.Flat
                    };
                    LevelButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    LevelButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    LevelButton.FlatAppearance.BorderSize = 0;
                    if (l <= currentPlayerLevel)
                    {
                        LevelButton.Click += eventGameStart;
                    }

                    LevelButtonList.Add(LevelButton);
                }

            }

            //// screen
            this.BackgroundImage = Image.FromFile(BackgroundPath);
            this.Controls.Add(BorderImage);
            this.Controls.Add(ExitButton);
            foreach (Button b in LevelButtonList.ToArray())
            {
                this.Controls.Add(b);
            }
        }
        private void GameScreenComponent(String pathToResource, int level)
        {
            string BackgroundPath = string.Format("{0}\\Image\\background\\homescreen_3.png", pathToResource);
            Bitmap board = CombineBitmap(pathToResource, game.board.Cells);

            // khung
            Button BorderImage = new Button()
            {

                Name = "TagImage",
                Height = 79,
                Width = 365,
                Location = new Point((this.ClientSize.Width - 365) / 2, 25),
                BackColor = Color.Transparent,
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\icon\\tag.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "TagImage"
                },
                FlatStyle = FlatStyle.Flat,
                Text = string.Format("Level {0}", level),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(new FontFamily("Arial"), 36, FontStyle.Bold, GraphicsUnit.Pixel)
            };

            // button
            Button ExitButton;
            ExitButton = new Button()
            {
                Name = "ReturnButton",
                Height = 85,
                Width = 203,
                Location = new Point(130, this.ClientSize.Height - 185),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\return.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "ReturnButton",
                    callFuntion = "LevelScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ExitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.Click += eventGameExit;

            
            PictureBox Character = new PictureBox()
            {
                Name = "Character",
                Height = 100,
                Width = 100,
                Location = new Point(
                    (this.ClientSize.Width - board.Width) / 2 + game.board.character.positionX,
                    (this.ClientSize.Height - board.Height) / 2 + game.board.character.positionY
                ),
                BackColor = Color.Transparent,
                Image = Image.FromFile(string.Format("{0}\\Image\\icon\\character.png", pathToResource)),
                
            };
            PictureBox GameBoard = new PictureBox()
            {
                Name = "GameBoard",
                Height = board.Height,
                Width = board.Width,
                Location = new Point((this.ClientSize.Width - board.Width) / 2, (this.ClientSize.Height - board.Height) / 2),
                //BackColor = Color.Transparent,
                Parent = Character,
                Image = board
            };
            game.board.minLocationX = (this.ClientSize.Width - board.Width) / 2;
            game.board.minLocationY = (this.ClientSize.Height - board.Height) / 2;

            List<PictureBox> Boxes = new List<PictureBox>();
            foreach (Box b in game.board.boxes)
            {
                Boxes.Add(new PictureBox()
                {
                    Name = string.Format("Box_{0}", b.id),
                    Height = 100,
                    Width = 100,
                    Location = new Point(
                                    (this.ClientSize.Width - board.Width) / 2 + b.positionX,
                                    (this.ClientSize.Height - board.Height) / 2 + b.positionY
                                ),
                    BackColor = Color.Transparent,
                    Image = Image.FromFile(string.Format("{0}\\Image\\icon\\box.png", pathToResource)),
                    Parent = GameBoard
                });
            }

            //// screen
            this.BackgroundImage = Image.FromFile(BackgroundPath);
            this.KeyUp += new KeyEventHandler(this.eventKeyPush);
            this.Controls.Add(BorderImage);
            this.Controls.Add(Character);
            foreach (PictureBox b in Boxes)
            {
                this.Controls.Add(b);
            }
            this.Controls.Add(GameBoard);
            Character.BringToFront();
            this.Controls.Add(ExitButton);
        }


        private void EndScreenComponent(String pathToResource)
        {
            string BackgroundPath = string.Format("{0}\\Image\\background\\homescreen_4.png", pathToResource);

            // button
            Button ReturnButton;
            ReturnButton = new Button()
            {
                Name = "ReturnButton",
                Height = 85,
                Width = 203,
                Location = new Point(130, this.ClientSize.Height - 285),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\return.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = "ReturnButton",
                    callFuntion = "LevelScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ReturnButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ReturnButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ReturnButton.FlatAppearance.BorderSize = 0;
            ReturnButton.Click += eventGameExit;

            Button ReloadButton;
            ReloadButton = new Button()
            {
                Name = "ReloadButton",
                Height = 94,
                Width = 175,
                Location = new Point(this.ClientSize.Width/2 -50 -175, (this.ClientSize.Height - 104)/2 +50),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\replay.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = string.Format("LevelButton_{0}", game.level),
                    callFuntion = "GameScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            ReloadButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ReloadButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ReloadButton.FlatAppearance.BorderSize = 0;
            ReloadButton.Click += eventGameStart;

            Button NextButton;
            NextButton = new Button()
            {
                Name = "NextButton",
                Height = 94,
                Width = 175,
                Location = new Point(this.ClientSize.Width / 2 + 50, (this.ClientSize.Height - 104) / 2 + 50),
                BackgroundImage = Image.FromFile(string.Format("{0}\\Image\\button\\continute_2.png", pathToResource)),
                Tag = new WaveDetailTag()
                {
                    Name = string.Format("LevelButton_{0}", game.level + 1),
                    callFuntion = "GameScreen"
                },
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            NextButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            NextButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            NextButton.FlatAppearance.BorderSize = 0;
            if (game.level < 20) { 
                NextButton.Click += eventGameStart; 
            }

            //// screen
            this.BackgroundImage = Image.FromFile(BackgroundPath);
            this.Controls.Add(ReturnButton);
            this.Controls.Add(NextButton);
            this.Controls.Add(ReloadButton);
        }
        public static Bitmap CombineBitmap(string pathToResource, Cell[,] files)
        {
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;
            int width = 0;
            int height = 0;
            //Image.FromFile(

            try
            {
                finalImage = new Bitmap(files.GetLength(0) * 100, files.GetLength(1) * 100);
                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.Clear(System.Drawing.Color.Black);
                    for (int r = 0; r < files.GetLength(1); r++)
                    {
                        for (int c = 0; c < files.GetLength(0); c++)
                        {
                            var yr = files[c, r];
                            Bitmap bitmap = new Bitmap(string.Format("{0}\\Image\\icon\\{1}", pathToResource, files[c,r].imageBackground));
                            g.DrawImage(bitmap, new Rectangle(c*100, r  * 100, 100, 100));
                        }
                    }
                }
                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
    }
    #endregion
}





