/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;
using Oriole.generic.operators;

namespace Oriole.generic
{
	public class Executer
	{
		public const char SIGN_COMMENT = '#';
		
		public Executer()
		{
			
		}
		
		public void Execute(string expression, bool clear = true)
		{
			if(clear) expression = Clear(expression);
			
			if(expression.Length < 1 || expression[0] == SIGN_COMMENT) return;
			
			//System.Windows.Forms.MessageBox.Show(expression);
			
			foreach(Operator op in Structures.GetOperators())
			{
				op.Execute(new Pattern(expression));
			}
		}
		
		public string Clear(string expression)
		{
			expression = expression.Trim().Replace('	', ' ');
			
			string result = "";
			int space = 0;
			
			for(int i = 0; i < expression.Length; i++)
			{
				if(expression[i] == ' ')
				{
					if(space > 0) continue;
					else result += expression[i];
					
					space++;
				}
				else
				{
					space = 0;
					result += expression[i];
				}
			}
			
			return result;
		}
	}
}
