namespace Dam
{
    partial class Form1
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
            this.G = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1taget = new System.Windows.Forms.Label();
            this.label2taget = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // G
            // 
            this.G.BackColor = System.Drawing.Color.Gray;
            this.G.Location = new System.Drawing.Point(12, 105);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(1007, 931);
            this.G.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Spiller 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 1054);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spiller 2:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(253, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(253, 1051);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 7;
            // 
            // label1taget
            // 
            this.label1taget.AutoSize = true;
            this.label1taget.Location = new System.Drawing.Point(656, 64);
            this.label1taget.Name = "label1taget";
            this.label1taget.Size = new System.Drawing.Size(150, 25);
            this.label1taget.TabIndex = 8;
            this.label1taget.Text = "Taget brikker; ";
            // 
            // label2taget
            // 
            this.label2taget.AutoSize = true;
            this.label2taget.Location = new System.Drawing.Point(656, 1054);
            this.label2taget.Name = "label2taget";
            this.label2taget.Size = new System.Drawing.Size(150, 25);
            this.label2taget.TabIndex = 9;
            this.label2taget.Text = "Taget brikker; ";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1046, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 708);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 95);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start igen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(365, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 61);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1748, 48);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuQuit,
            this.MenuRestart});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(97, 44);
            this.Menu.Text = "Menu";
            // 
            // MenuQuit
            // 
            this.MenuQuit.Name = "MenuQuit";
            this.MenuQuit.Size = new System.Drawing.Size(219, 44);
            this.MenuQuit.Text = "Quit";
            this.MenuQuit.Click += new System.EventHandler(this.MenuQuit_Click);
            // 
            // MenuRestart
            // 
            this.MenuRestart.Name = "MenuRestart";
            this.MenuRestart.Size = new System.Drawing.Size(219, 44);
            this.MenuRestart.Text = "Restart";
            this.MenuRestart.Click += new System.EventHandler(this.MenuRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1748, 1106);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2taget);
            this.Controls.Add(this.label1taget);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.G);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel G;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1taget;
        private System.Windows.Forms.Label label2taget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuQuit;
        private System.Windows.Forms.ToolStripMenuItem MenuRestart;
    }
}

