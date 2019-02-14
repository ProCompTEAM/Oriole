/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;

namespace Oriole.generic.operators.def
{
	public class Var : Operator
	{
		public override void Execute(Pattern pattern)
		{
			if(pattern.Arguments.Length > 0 && pattern.Arguments[0] == Signature)
			{
				//var <name> <value>
				
				if(pattern.Arguments.Length != 3) CloseInvalid();
				else
				{
					this.Content = new object[] { this };
					
					Structures.SetVariable(pattern.Arguments[1], pattern.Arguments[2]);
				}
			}
		}
		
		public new static string Signature
		{
			get { return "var"; }
		}
		
		public override string Instance
		{
			get { return Var.Signature; }
		}
	}
}
