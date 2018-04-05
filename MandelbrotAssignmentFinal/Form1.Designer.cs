namespace MandelbrotAssignmentFinal
{
    partial class Fractal
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorPelatteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.propertiesToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.restartToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.reloadToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem1});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(47, 21);
            this.editToolStripMenuItem1.Text = "View";
            // 
            // infoToolStripMenuItem1
            // 
            this.infoToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
            this.infoToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.infoToolStripMenuItem1.Text = "Info";
            this.infoToolStripMenuItem1.Click += new System.EventHandler(this.infoToolStripMenuItem1_Click);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.propertiesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.colorPelatteToolStripMenuItem,
            this.colorCycleToolStripMenuItem});
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(80, 21);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.propertiesToolStripMenuItem1_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // colorPelatteToolStripMenuItem
            // 
            this.colorPelatteToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.colorPelatteToolStripMenuItem.Name = "colorPelatteToolStripMenuItem";
            this.colorPelatteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colorPelatteToolStripMenuItem.Text = "Color Palette";
            this.colorPelatteToolStripMenuItem.Click += new System.EventHandler(this.colorPelatteToolStripMenuItem_Click);
            // 
            // colorCycleToolStripMenuItem
            // 
            this.colorCycleToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.colorCycleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1});
            this.colorCycleToolStripMenuItem.Name = "colorCycleToolStripMenuItem";
            this.colorCycleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colorCycleToolStripMenuItem.Text = "Color Cycle";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem1_Click);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.BackColor = System.Drawing.Color.SkyBlue;
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.stopToolStripMenuItem1.Text = "Stop";
            this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolStripMenuItem1_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(928, 416);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(44, 450);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(464, 20);
            this.textBox1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 509);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Fractal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mandelbrot";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem colorPelatteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorCycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
    }
}

