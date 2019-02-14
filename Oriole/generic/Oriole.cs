/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝
	
	-= W I K I =- https://en.wikipedia.org/wiki/New_World_oriole
 */
 
using System;
using System.Collections.Generic;
using System.IO;

namespace Oriole.generic
{
	public static class Oriole
	{
		public const string CODENAME = "Orange";
		public const double API_VERSION = 0.1;
		
		public static List<string> Paths = new List<string>();
		public static List<string> Logger = new List<string>();
		
		public static string CurrentPath = Environment.CurrentDirectory;
		
		public static void LoadAll()
		{
			Paths.Add(Environment.CurrentDirectory);
			
			if(Directory.Exists(Environment.CurrentDirectory + "sounds"))
				Paths.Add(Environment.CurrentDirectory + "sounds");
			
			if(Directory.Exists(Environment.CurrentDirectory + "export"))
				Directory.CreateDirectory(Environment.CurrentDirectory + "export");
			
			operators.Operators.RegisterDefaultOperators();
		}
		
		public static void Log(string message)
		{
			Logger.Add(string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), message));
		}
		
		public static scene.Scene ExecutingScene = null;
	}
}
