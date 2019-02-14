/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;
using System.Media;

namespace Oriole.generic.operators.def
{
	public class Wav : Operator
	{
		public override void Execute(Pattern pattern)
		{
			if(pattern.Arguments.Length > 0 && pattern.Arguments[0] == Instance)
			{
				if(pattern.Arguments.Length != 2) CloseInvalid();
				else
				{
					this.Content = new object[] { this, new entity.types.Word(pattern.Arguments[1]) };
					
					new SoundPlayer(Export.GetFile(((entity.types.Word) this.Content[1]).ToString())).Play();
				}
			}
		}
		
		public new static string Signature
		{
			get { return "wav"; }
		}
		
		public override string Instance
		{
			get { return Wav.Signature; }
		}
	}
}
