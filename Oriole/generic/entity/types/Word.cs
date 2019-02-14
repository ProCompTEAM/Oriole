/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;

namespace Oriole.generic.entity.types
{
	public class Word : BaseType
	{
		public static new string Signature
		{
			get { return "word"; }
		}
		
		public override string Instance
		{
			get { return Word.Signature; }
		}
		
		public Word(string value) : base(value)
		{
			value = Variable.Clear(value);
			
			if(value.Length > 1 && value[0] == '\'' && value[value.Length - 1] == '\'')
				Body = value.Substring(1, value.Length - 2);
			else IntBadValue();
		}
		
		public new string ToString()
		{
			return (string) Body;
		}
		
		public new Type GetType()
		{
			return ToString().GetType();
		}
	}
}
