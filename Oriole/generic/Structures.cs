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

namespace Oriole.generic
{
	public static class Structures
	{	
		public static Dictionary<string, string> Variables = new Dictionary<string, string>();
		
		
		
		public static void SetVariable(string name, string value)
		{
			Variables[name] = value;
		}
		
		public static string GetVariable(string name, bool react = false)
		{
			if(react && !Variables.ContainsKey(name))
				throw new Exception("Undefined variable: " + name + "!");
			else if(!Variables.ContainsKey(name)) return null;
			
			return Variables[name];
		}
		
		public static operators.Operator[] GetOperators()
		{
			return operators.Operators.Instances.ToArray();
		}
		
		public static string[] GetDefaultTypesSignatures()
		{
			string[] types =
			{
				entity.types.Numeric.Signature,
				entity.types.Word.Signature
			};
			
			return types;
		}
	}
}
