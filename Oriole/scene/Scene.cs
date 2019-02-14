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
using System.Windows.Forms;
using Oriole.generic;

namespace Oriole.scene
{
	public class Scene
	{
		public static List<Scene> Scenes = new List<Scene>();
		
		public static Scene GetScene(string name)
		{
			foreach(Scene s in Scenes)
				if(s.Name == name) return s;
			return null;
		}
		
		public readonly string Name;
		public readonly SceneUI UI;
		
		public const string END_SIGNATURE = "end";
		public const char NOSLEEP_SIGNATURE = '@';
		
		public Scene(string name, bool openUI = true)
		{
			foreach(Scene s in Scene.Scenes)
				if(s.Name == name) throw new Exception("Name already in use!");
			
			Scene.Scenes.Add(this);
			
			this.Name = name;
			
			UI = new SceneUI(this);
			
			if(openUI) UI.Open();
		}
		
		public string[] EXData = { };
		
		public int EXLine = 0;
		
		bool Running = false;
		
		public bool IsRunning
		{
			get { return Running; }
		}
		
		public int Interval = 0;
		
		public void Run(int startFrom = 0)
		{
			try
			{
				if(Running) Interrupt();
				
				Running = true;
				
				Interval = 0;
				
				Executer executer = new Executer();
				
				generic.Oriole.ExecutingScene = this;
				
				for(int i = startFrom; i < EXData.Length; EXLine = i, i++)
				{
					if(!Running) break; 
					else
					{
						UI.SelectLine(i);
						
						if(EXData[i].Length < 1) continue;
						
						if(EXData[i][0] != NOSLEEP_SIGNATURE)
							System.Threading.Thread.Sleep(Interval);
						
						if(EXData[i].ToLower() == END_SIGNATURE) Interrupt();
						else executer.Execute(EXData[i]);
					}
				}
				
				generic.Oriole.ExecutingScene = null;
			}
			catch(Exception e)
			{
				Interrupt();
				
				MessageBox.Show(e.Message + " Line: " + (EXLine + 1),
				                "Interpretation error! Interrupted.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		public void Interrupt()
		{
			Running = false;
		}
	}
}
