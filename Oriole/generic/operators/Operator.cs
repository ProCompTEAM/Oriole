/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;

namespace Oriole.generic.operators
{
	public class Operator
	{
		protected object[] Content = {};
		
		public static string Signature
		{
			get { return "operator"; }
		}
		
		public object[] GetContent()
		{
			return Content;
		}
		
		public virtual string Instance
		{
			get { return Operator.Signature; }
		}
		
		public bool InstanceOf(Operator t)
		{
			return (this.Instance == t.Instance);
		}
		
		public virtual void Execute(Pattern pattern)
		{
			throw new Exception("Empty operator!");
		}
		
		protected void CloseInvalid()
		{
			throw new Exception("Invalid syntax in expression!");
		}
	}
}
