using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider
{
    public partial class Game_Form : Form
    {
        bool _goLeft;
        bool _goRight;

        int _score;
        int _ammoXSpeed;
        int _ammoYSpeed;
        int _userPaddleSpeed;

        Random _random = new Random();
        public Game_Form()
        {
            InitializeComponent();
            setUpGame();
        }

        private void setUpGame()
        {
            _score = 0;
            _ammoXSpeed = 10;
            _ammoYSpeed = 10;
            _userPaddleSpeed = 12;

            gameTimer.Start();

            //Check user options
            switch(Menu.ColorPaddle)
            {
                case 0:
                    Paddle.BackColor = Color.White;
                    break;
                case 1:
                    Paddle.BackColor = Color.DarkGreen;
                    break;
                case 2:
                    Paddle.BackColor = Color.DarkBlue;
                    break;
                case 3:
                    Paddle.BackColor = Color.DarkRed;
                    break;
            }
            
            switch(Menu.ColorBall)
            {
                case 0:
                    Ball.BackColor = Color.White;
                    break;
                case 1:
                    Ball.BackColor = Color.DarkGreen;
                    break;
                case 2:
                    Ball.BackColor = Color.DarkBlue;
                    break;
                case 3:
                    Ball.BackColor = Color.DarkRed;
                    break;
            }

            switch (Menu.Difficulty)
            {
                case 0:
                    _ammoXSpeed = 10;
                    _ammoYSpeed = 10;
                    _userPaddleSpeed = 15;
                    setUpBlocks(0, 4);
                    break;
                case 1:
                    _ammoXSpeed = 12;
                    _ammoYSpeed = 12;
                    _userPaddleSpeed = 17;
                    setUpBlocks(1,8);
                    break;
                case 2:
                    _ammoXSpeed = 15;
                    _ammoYSpeed = 15;
                    _userPaddleSpeed = 20;
                    setUpBlocks(2,10);
                    break;
            }

            gameOverScoreLabel.Hide();
            scoreLabel.Hide();
            gameOverLabel.Hide();
            returnButton.Hide();
            PlayerNameTextBox.Hide();
            userNameLabel.Hide();
        }

        private void setUpBlocks(int firstIdx,int lastIdx)
        {
            
                foreach (Control x in this.Controls)
                {
                int rnd = _random.Next(firstIdx, lastIdx);
                    if (x is PictureBox && (string)x.Tag == "blocks")
                    {
                        if (rnd > 6)
                        {
                            x.BackColor = Color.DarkRed;
                            continue;
                        }
                        if (rnd > 4)
                        {
                            x.BackColor = Color.DarkBlue;
                            continue;
                        }
                        if (rnd > 2)
                            x.BackColor = Color.DarkGreen;
                }

                }
          
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if (_goLeft == true && Paddle.Left > 0)
            {
                Paddle.Left -= _userPaddleSpeed;
            }
            if (_goRight == true && Paddle.Left < this.Width - Paddle.Width)
            {
                Paddle.Left += _userPaddleSpeed;
            }

            Ball.Left += _ammoXSpeed;
            Ball.Top += _ammoYSpeed;

            //Side walls ball bouncing
            if (Ball.Left < 0 || Ball.Left > this.Width - Ball.Width)
            {
                Menu.HitSound.Play();
                _ammoXSpeed = -_ammoXSpeed;
            }
            
            //Top wall ball bouncing
            if (Ball.Top-10 < 0)
            {
                Menu.HitSound.Play();
                _ammoYSpeed = -_ammoYSpeed;
            }

            //Paddle bouncing
            if (Ball.Bounds.IntersectsWith(Paddle.Bounds))
            {
                Menu.HitSound.Play();
                _ammoYSpeed = -_ammoYSpeed;
            }

            //Enemy bouncing
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Menu.HitSound.Play();
                        _ammoYSpeed = -_ammoYSpeed;
                        if (x.BackColor == Color.White)
                        {
                            this.Controls.Remove(x);
                            _score += 10;
                            ScoreLabel.Text = "Score: " + _score;
                        }
                        else if (x.BackColor == Color.DarkGreen)
                            x.BackColor = Color.White;
                        else if (x.BackColor == Color.DarkBlue)
                            x.BackColor = Color.DarkGreen;
                        else if (x.BackColor == Color.DarkRed)
                            x.BackColor = Color.DarkBlue;
                        break;
                    }
                }
            }
            //GameOver
            if (_score > 660 || Ball.Top>this.Height-Ball.Height) 
            {
                gameOver();
            }
            
        }

        private void gameOver()
        {
            gameTimer.Stop();
            Menu.GameOverSound.Play();
            //Hide paddle, ball etc.
            foreach (Control x in this.Controls)
            {
                x.Hide();
            }

            //Setup Score on Game Over screen
            gameOverScoreLabel.Text = ""+_score;

            //Show Game Over screen
            gameOverScoreLabel.Show();
            scoreLabel.Show();
            gameOverLabel.Show();
            returnButton.Show();
            userNameLabel.Show();
            PlayerNameTextBox.Show();
        }

        private void MoveDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    _goLeft = true;
                    break;
                case Keys.Right:
                case Keys.D:
                    _goRight = true;
                    break;
            }
        }

        private void MoveUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    _goLeft = false;
                    break;
                case Keys.Right:
                case Keys.D:
                    _goRight = false;
                    break;
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlayerNameTextBox.Text))
            {
                Menu.StopSound.Play();
                return;
            }
            Menu.ClickObjectSound.Play();
            Menu.PlayerInfo playerInfo = new Menu.PlayerInfo();
            playerInfo.Name = PlayerNameTextBox.Text;
            playerInfo.Score = gameOverScoreLabel.Text;
            Menu.PlayerList.Add(playerInfo); 
            this.Close();
        }

        private void PlayerNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GameOverLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
