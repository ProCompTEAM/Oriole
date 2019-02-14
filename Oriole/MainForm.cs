/*
		╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
		║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
		║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
		║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
		║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
		╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Oriole
{
	public partial class MainForm : Form
	{
		public static string DIR = "";
		
		public MainForm()
		{
			InitializeComponent();
			
			sceneNameBox.Text = genSceneName();
		}
		
		public string genSceneName()
		{
			return "Scene" + (scene.Scene.Scenes.Count + 1);
		}
		
		void BtnCreateSceneClick(object sender, EventArgs e)
		{
			if(sceneNameBox.Text.Length > 0)
			{
				new scene.Scene(sceneNameBox.Text);
				
				sceneNameBox.Text = genSceneName();	
			}
			
			RefreshSList();
		}
		
		void SaveAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			FolderBrowserDialog f = new FolderBrowserDialog();
			f.RootFolder = Environment.SpecialFolder.MyComputer;
			
			if (f.ShowDialog() == DialogResult.OK)
            {
				DIR = f.SelectedPath + @"\";
				
				sourceLabel.Text = f.SelectedPath + @"\";
				
				generic.Oriole.Paths.Add(f.SelectedPath+ @"\");
				
				generic.Oriole.CurrentPath = f.SelectedPath + @"\";
				
				generic.Oriole.Log("New source: " + f.SelectedPath);
            }
		}
		
		void LinkRefreshLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshSList();
		}
		
		void RefreshSList()
		{
			scenesList.Clear();
			
			foreach(scene.Scene s in scene.Scene.Scenes)
			{
				scenesList.Items.Add(s.Name);
			}
		}
		
		void ScenesListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(scenesList.SelectedItems.Count == 0) return;
			
			scene.Scene s = scene.Scene.GetScene(scenesList.SelectedItems[0].Text);
			if(s != null && !s.UI.Opened) 
			{
				s.UI.Open();
				this.BringToFront();
				
				s.UI.Activate();
			}
		}
		
		void ImportAudioToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFileDialog f = new OpenFileDialog();
			f.Filter = "Audio (*.wav, *.mp3, *.ogg)|*.wav;*.mp3;*.ogg";
			
			if (f.ShowDialog() == DialogResult.OK)
            {
				File.Copy(f.FileName, DIR + f.SafeFileName);
				
				System.Diagnostics.Process.Start(DIR + f.SafeFileName);
			}
		}
	}
}
