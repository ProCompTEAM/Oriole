namespace Oriole
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnCreateScene;
		private System.Windows.Forms.TextBox sceneNameBox;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scenesToolStripMenuItem;
		private System.Windows.Forms.ListView scenesList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label sourceLabel;
		private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
		private System.Windows.Forms.LinkLabel linkRefresh;
		private System.Windows.Forms.ToolStripMenuItem importAudioToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCreateScene = new System.Windows.Forms.Button();
			this.sceneNameBox = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scenesList = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.sourceLabel = new System.Windows.Forms.Label();
			this.linkRefresh = new System.Windows.Forms.LinkLabel();
			this.importAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCreateScene
			// 
			this.btnCreateScene.Location = new System.Drawing.Point(286, 201);
			this.btnCreateScene.Name = "btnCreateScene";
			this.btnCreateScene.Size = new System.Drawing.Size(162, 34);
			this.btnCreateScene.TabIndex = 0;
			this.btnCreateScene.Text = "new scene";
			this.btnCreateScene.UseVisualStyleBackColor = true;
			this.btnCreateScene.Click += new System.EventHandler(this.BtnCreateSceneClick);
			// 
			// sceneNameBox
			// 
			this.sceneNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sceneNameBox.Location = new System.Drawing.Point(12, 203);
			this.sceneNameBox.Name = "sceneNameBox";
			this.sceneNameBox.Size = new System.Drawing.Size(268, 30);
			this.sceneNameBox.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.exportToolStripMenuItem,
			this.scenesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(460, 28);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.saveAllToolStripMenuItem,
			this.importAudioToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
			this.exportToolStripMenuItem.Text = "Space";
			// 
			// saveAllToolStripMenuItem
			// 
			this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
			this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
			this.saveAllToolStripMenuItem.Text = "Source";
			this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItemClick);
			// 
			// scenesToolStripMenuItem
			// 
			this.scenesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.clearAllToolStripMenuItem});
			this.scenesToolStripMenuItem.Name = "scenesToolStripMenuItem";
			this.scenesToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
			this.scenesToolStripMenuItem.Text = "Scenes";
			// 
			// clearAllToolStripMenuItem
			// 
			this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
			this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
			this.clearAllToolStripMenuItem.Text = "Clear All";
			// 
			// scenesList
			// 
			this.scenesList.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.scenesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.scenesList.Location = new System.Drawing.Point(286, 64);
			this.scenesList.Name = "scenesList";
			this.scenesList.Size = new System.Drawing.Size(162, 131);
			this.scenesList.TabIndex = 3;
			this.scenesList.UseCompatibleStateImageBehavior = false;
			this.scenesList.View = System.Windows.Forms.View.List;
			this.scenesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ScenesListItemSelectionChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(286, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Scenes:";
			// 
			// sourceLabel
			// 
			this.sourceLabel.Location = new System.Drawing.Point(13, 42);
			this.sourceLabel.Name = "sourceLabel";
			this.sourceLabel.Size = new System.Drawing.Size(267, 51);
			this.sourceLabel.TabIndex = 5;
			this.sourceLabel.Text = "Source is not defined!";
			// 
			// linkRefresh
			// 
			this.linkRefresh.Location = new System.Drawing.Point(387, 42);
			this.linkRefresh.Name = "linkRefresh";
			this.linkRefresh.Size = new System.Drawing.Size(70, 19);
			this.linkRefresh.TabIndex = 6;
			this.linkRefresh.TabStop = true;
			this.linkRefresh.Text = "Refresh";
			this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRefreshLinkClicked);
			// 
			// importAudioToolStripMenuItem
			// 
			this.importAudioToolStripMenuItem.Name = "importAudioToolStripMenuItem";
			this.importAudioToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
			this.importAudioToolStripMenuItem.Text = "Import Audio";
			this.importAudioToolStripMenuItem.Click += new System.EventHandler(this.ImportAudioToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 245);
			this.Controls.Add(this.linkRefresh);
			this.Controls.Add(this.sourceLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.scenesList);
			this.Controls.Add(this.sceneNameBox);
			this.Controls.Add(this.btnCreateScene);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Oriole Studio";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
