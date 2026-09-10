namespace Minesweeper
{
    partial class Scene
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
            this.mineGrid = new System.Windows.Forms.Panel();
            this.numsGrid = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.minesCount = new System.Windows.Forms.Label();
            this.restartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mineGrid
            // 
            this.mineGrid.Location = new System.Drawing.Point(582, 149);
            this.mineGrid.Name = "mineGrid";
            this.mineGrid.Size = new System.Drawing.Size(170, 182);
            this.mineGrid.TabIndex = 1;
            // 
            // numsGrid
            // 
            this.numsGrid.Location = new System.Drawing.Point(261, 333);
            this.numsGrid.Name = "numsGrid";
            this.numsGrid.Size = new System.Drawing.Size(195, 170);
            this.numsGrid.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI Symbol", 30.25F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(200, 31);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(274, 55);
            this.title.TabIndex = 3;
            this.title.Text = "Minesweeper";
            // 
            // minesCount
            // 
            this.minesCount.AutoSize = true;
            this.minesCount.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minesCount.Location = new System.Drawing.Point(41, 73);
            this.minesCount.Name = "minesCount";
            this.minesCount.Size = new System.Drawing.Size(0, 25);
            this.minesCount.TabIndex = 4;
            // 
            // restartBtn
            // 
            this.restartBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartBtn.Location = new System.Drawing.Point(632, 714);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(120, 44);
            this.restartBtn.TabIndex = 5;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.minesCount);
            this.Controls.Add(this.title);
            this.Controls.Add(this.numsGrid);
            this.Controls.Add(this.mineGrid);
            this.Name = "Scene";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Scene_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mineGrid;
        private System.Windows.Forms.Panel numsGrid;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label minesCount;
        private System.Windows.Forms.Button restartBtn;
    }
}

