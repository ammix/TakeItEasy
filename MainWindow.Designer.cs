namespace TakeItEasy
{
	partial class MainWindow
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
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.turquoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.selectColorsToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newGameToolStripMenuItem.Text = "New game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
			// 
			// selectColorsToolStripMenuItem
			// 
			this.selectColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueToolStripMenuItem,
            this.pinkToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.turquoiseToolStripMenuItem});
			this.selectColorsToolStripMenuItem.Name = "selectColorsToolStripMenuItem";
			this.selectColorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.selectColorsToolStripMenuItem.Text = "Select colors";
			// 
			// blueToolStripMenuItem
			// 
			this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
			this.blueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.blueToolStripMenuItem.Text = "Blue";
			this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
			// 
			// pinkToolStripMenuItem
			// 
			this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
			this.pinkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pinkToolStripMenuItem.Text = "Pink";
			this.pinkToolStripMenuItem.Click += new System.EventHandler(this.pinkToolStripMenuItem_Click);
			// 
			// yellowToolStripMenuItem
			// 
			this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
			this.yellowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.yellowToolStripMenuItem.Text = "Yellow";
			this.yellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
			// 
			// turquoiseToolStripMenuItem
			// 
			this.turquoiseToolStripMenuItem.Name = "turquoiseToolStripMenuItem";
			this.turquoiseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.turquoiseToolStripMenuItem.Text = "Turquoise";
			this.turquoiseToolStripMenuItem.Click += new System.EventHandler(this.turquoiseToolStripMenuItem_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 562);
			this.ContextMenuStrip = this.contextMenuStrip;
			this.DoubleBuffered = true;
			this.Name = "MainWindow";
			this.Text = "FormController";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormController_MouseDoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormController_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectColorsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem turquoiseToolStripMenuItem;
	}
}

