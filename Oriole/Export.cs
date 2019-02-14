/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;
using System.IO;

namespace Oriole
{
	public static class Export
	{
		public static void Save(scene.Scene scene, bool open = false)
		{
			if(generic.Oriole.CurrentPath == Environment.CurrentDirectory)
				Error("Empty path!", "Export source is not defined!");
			else 
			{
				File.WriteAllLines(generic.Oriole.CurrentPath + scene.Name + ".scene", scene.EXData);
				
				if(open) System.Diagnostics.Process.Start(generic.Oriole.CurrentPath + scene.Name + ".scene");
			}
		}
		
		public static string[] Load(scene.Scene scene)
		{
			if(generic.Oriole.CurrentPath == Environment.CurrentDirectory)
			{
				Error("Empty path!", "Export source is not defined!");
				
				return new string[] { };
			}
			else 
			{
				if(File.Exists(generic.Oriole.CurrentPath + scene.Name + ".scene"))
					return File.ReadAllLines(generic.Oriole.CurrentPath + scene.Name + ".scene");
				else 
				{
					Error("File not saved later!");
					
					return new string[] { };
				}
			}
		}
		
		public static void Error(string message, string caption = "error")
		{
			System.Windows.Forms.MessageBox.Show(message, caption,
				      System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			
			generic.Oriole.Log("(export error) " + message);
		}
		
		public static string GetFile(string filename)
		{
			foreach(string path in generic.Oriole.Paths)
				if(File.Exists(path + filename)) return path + filename;
			return filename;
		}
	}
}
