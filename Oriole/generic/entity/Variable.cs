/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;

using Oriole.generic.entity.types;

namespace Oriole.generic.entity
{
	public class Variable
	{
		public static string Clear(string value)
		{
			string r = Structures.GetVariable(value);
			
			if(r != null) return r;
			return value;
		}
		
		public string Identifier;
		
		BaseType Type;
		
		public Variable(string identifier)
		{
			Identifier = identifier;
			
			Type = new BaseType();
		}
		
		public Variable(string identifier, BaseType type)
		{
			Identifier = identifier;
			
			Type = type;
		}
		
		public BaseType Read()
		{
			return Type;
		}
		
		public void Write(BaseType type)
		{
			Type = type;
		}
		
		public bool Equal(BaseType type)
		{
			return (Type.Body == type.Body);
		}
		
		public bool InstanceOf(BaseType type)
		{
			return Type.InstanceOf(type);
		}
	}
}
