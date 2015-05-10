namespace SudokuGJ
{
    partial class Board
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
            this.Podatoci = new System.Windows.Forms.GroupBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pushesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.moves = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.Label();
            this.Podatoci.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Podatoci
            // 
            this.Podatoci.BackColor = System.Drawing.SystemColors.Window;
            this.Podatoci.Controls.Add(this.levelLabel);
            this.Podatoci.Controls.Add(this.groupBox1);
            this.Podatoci.Controls.Add(this.level);
            this.Podatoci.Controls.Add(this.player);
            this.Podatoci.Location = new System.Drawing.Point(121, 49);
            this.Podatoci.Name = "Podatoci";
            this.Podatoci.Size = new System.Drawing.Size(285, 238);
            this.Podatoci.TabIndex = 1;
            this.Podatoci.TabStop = false;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(150, 58);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(35, 13);
            this.levelLabel.TabIndex = 4;
            this.levelLabel.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pushesLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.moves);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(44, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pushesLabel
            // 
            this.pushesLabel.AutoSize = true;
            this.pushesLabel.Location = new System.Drawing.Point(81, 60);
            this.pushesLabel.Name = "pushesLabel";
            this.pushesLabel.Size = new System.Drawing.Size(35, 13);
            this.pushesLabel.TabIndex = 5;
            this.pushesLabel.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pushes:";
            // 
            // moves
            // 
            this.moves.AutoSize = true;
            this.moves.Location = new System.Drawing.Point(81, 26);
            this.moves.Name = "moves";
            this.moves.Size = new System.Drawing.Size(35, 13);
            this.moves.TabIndex = 3;
            this.moves.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Moves:";
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level.ForeColor = System.Drawing.Color.White;
            this.level.Location = new System.Drawing.Point(109, 58);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(45, 15);
            this.level.TabIndex = 1;
            this.level.Text = "Level:";
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player.ForeColor = System.Drawing.Color.White;
            this.player.Location = new System.Drawing.Point(125, 16);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(57, 20);
            this.player.TabIndex = 0;
            this.player.Text = "label1";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 397);
            this.Controls.Add(this.Podatoci);
            this.Name = "Board";
            this.Text = "Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Board_FormClosing);
            this.Load += new System.EventHandler(this.Board_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Board_KeyDown);
            this.Podatoci.ResumeLayout(false);
            this.Podatoci.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Podatoci;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label pushesLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label moves;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label level;
        private System.Windows.Forms.Label player;
    }
}