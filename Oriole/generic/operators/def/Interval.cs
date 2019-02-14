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
	public class Interval : Operator
	{
		public override void Execute(Pattern pattern)
		{
			if(pattern.Arguments.Length > 0 && pattern.Arguments[0] == Signature)
			{
				if(pattern.Arguments.Length != 2) CloseInvalid();
				else
				{
					this.Content = new object[] { this, new entity.types.Numeric(pattern.Arguments[1]) };
					
					if(Oriole.ExecutingScene != null)
						Oriole.ExecutingScene.Interval = 1000 / ((entity.types.Numeric) this.Content[1]).ToInt32();
				}
			}
		}
		
		public new static string Signature
		{
			get { return "int"; }
		}
		
		public override string Instance
		{
			get { return Interval.Signature; }
		}
	}
}
