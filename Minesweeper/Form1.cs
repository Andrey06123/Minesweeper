using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Scene : Form
    {
        private MapGenerator mapGenerator = new MapGenerator();
        private char[,] map = new char[20, 20];
        Button[,] buttons = new Button[20, 20];
        Button[,] labels = new Button[20, 20];
        int mineCount = 0;
        int minesFlagged = 0;

        private bool isFirstClick = true;

        public Scene()
        {
            this.Size = new Size(800, 800);

            InitializeComponent();
        }

        private void Scene_Load_1(object sender, EventArgs e)
        {


            this.ClientSize = new Size(800, 800);

            this.mineGrid.Size = new Size(600, 600);
            this.mineGrid.Location = new Point((this.ClientSize.Width - this.mineGrid.Width) / 2, 100);
            this.mineGrid.BackColor = Color.Transparent;

            //this.numsGrid.Size = new Size(600, 600);
            //this.numsGrid.Location = new Point((this.ClientSize.Width - this.numsGrid.Width) / 2, 100);
            //this.numsGrid.BackColor = Color.LightPink;

            int gridWidth = this.mineGrid.Width;
            int gridHeight = this.mineGrid.Height;



            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Button button = new Button();
                    button.Margin = new Padding(0);
                    button.Padding = new Padding(0);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.BackColor = Color.LightGray;
                    button.Size = new Size(gridWidth / 20, gridHeight / 20);
                    button.Location = new Point(j * gridWidth / 20, i * gridHeight / 20);
                    button.Tag = new Point(i, j);
                    buttons[i, j] = button;

                    button.MouseDown += btn_MouseDown;

                    Label cellName = new Label();
                    cellName.ForeColor = Color.Black;
                    //cellName.Text = map[i, j].ToString();
                    cellName.TextAlign = ContentAlignment.MiddleCenter;
                    cellName.Size = new Size(gridWidth / 20, gridHeight / 20);
                    cellName.Location = new Point(j * gridWidth / 20, i * gridHeight / 20);
                    cellName.Tag = new Point(i, j);

                    cellName.MouseDown += Label_MouseDown;

                    this.mineGrid.Controls.Add(button);
                    this.mineGrid.Controls.Add(cellName);

                    //this.numsGrid.Controls.Add(cellName);
                }
            }


            this.mineGrid.BringToFront();
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {


            Button button = sender as Button;
            if (button == null) return;

            Point location = (Point)button.Tag;
            int row = location.X;
            int col = location.Y;

            if (isFirstClick)
            {
                mapGenerator.StartOcupation(row, col);
                map = mapGenerator.GenerateMap();
                mineCount = mapGenerator.GetMineCount();
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Label label = this.mineGrid.Controls.OfType<Label>().FirstOrDefault(l => (Point)l.Tag == new Point(i, j));
                        if (label != null)
                        {
                            label.Text = map[i, j].ToString();
                        }
                    }
                }

                isFirstClick = false;
            }

            if (e.Button == MouseButtons.Left)
            {


                this.mineGrid.Controls.Remove(button);
                button.Dispose();
                if (map[row, col] == 'X')
                {
                    GameOver();
                }
                else if (map[row, col] == '0')
                {
                    RevealAdjacentCells(row, col);


                }
                else
                {
                    this.mineGrid.Controls.Remove(button);
                    button.Dispose();
                }


            }
            else if (e.Button == MouseButtons.Right)
            {
                button.BackColor = button.BackColor == Color.LightGray ? Color.Red : Color.LightGray;
                if (button.BackColor == Color.Red)
                {
                    minesFlagged++;
                }
                else
                {
                    if (map[row, col] == 'X')
                        minesFlagged--;
                }
            }
            minesCount.Text = $"Mines: {mineCount - minesFlagged}";
            if (0 == mineCount - minesFlagged)
            {
                GameWin();
            }
        }
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            if (label == null) return;
            Point location = (Point)label.Tag;
            int row = location.X;
            int col = location.Y;
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left &&
                (Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                neighborCellsClear(row, col);
            }
        }
        private void RevealAdjacentCells(int row, int col)
        {
            if (row < 0 || row >= 20 || col < 0 || col >= 20) return;

            Button button = buttons[row, col];

            if (button == null) return;

            this.mineGrid.Controls.Remove(button);
            button.Dispose();
            buttons[row, col] = null;

            if (map[row, col] == '0')
            {
                this.mineGrid.Controls.Remove(button);
                button.Dispose();
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        //if (i == 0 && j == 0) return;

                        RevealAdjacentCells(row + i, col + j);
                    }
                }
            }
        }
        private void neighborCellsClear(int row, int col)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int neighborRow = row + i;
                    int neighborCol = col + j;

                    if (neighborRow >= 0 && neighborRow < 20 &&
                        neighborCol >= 0 && neighborCol < 20)
                    {
                        if (buttons[neighborRow, neighborCol] == null) continue;

                        if (buttons[neighborRow, neighborCol].BackColor == Color.Red) continue;

                        if (map[neighborRow, neighborCol] == '0')
                        {
                            RevealAdjacentCells(neighborRow, neighborCol);
                        }
                        else if (map[neighborRow, neighborCol] == 'X')
                        {
                            GameOver();
                        }
                        else
                        {
                            this.mineGrid.Controls.Remove(buttons[neighborRow, neighborCol]);
                            buttons[neighborRow, neighborCol].Dispose();
                            buttons[neighborRow, neighborCol] = null;
                        }
                    }
                }
            }
        }
        private void GameOver()
        {
            MessageBox.Show("Game Over!");
        }
        private void GameWin()
        {
            MessageBox.Show("You Win!");
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
