/*
  ╔══╗╔═══╗╔══╗╔══╗╔╗──╔═══╗────╔═══╗╔═══╗╔══╗─╔══╗╔═══╗╔══╗╔════╗
  ║╔╗║║╔═╗║╚╗╔╝║╔╗║║║──║╔══╝─╔╗─║╔═╗║║╔═╗║║╔╗║─╚╗╔╝║╔══╝║╔═╝╚═╗╔═╝
  ║║║║║╚═╝║─║║─║║║║║║──║╚══╗╔╝╚╗║╚═╝║║╚═╝║║║║║──║║─║╚══╗║║────║║
  ║║║║║╔╗╔╝─║║─║║║║║║──║╔══╝╚╗╔╝║╔══╝║╔╗╔╝║║║║╔╗║║─║╔══╝║║────║║
  ║╚╝║║║║║─╔╝╚╗║╚╝║║╚═╗║╚══╗─╚╝─║║───║║║║─║╚╝║║╚╝╚╗║╚══╗║╚═╗──║║
  ╚══╝╚╝╚╝─╚══╝╚══╝╚══╝╚═══╝────╚╝───╚╝╚╝─╚══╝╚═══╝╚═══╝╚══╝──╚╝

 */
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Oriole.scene.ui
{
	public class DefaultWhiteLighter : ILighter
	{
		public void Load(SceneUI sceneUI)
		{
			sceneUI.LineBG = Color.WhiteSmoke;
			sceneUI.LineBGActive = Color.AntiqueWhite;
			sceneUI.LineColor = Color.Black;
		}
		
		public void Update(RichTextBox line)
		{
			if(line.Text.Length > 1 && line.Text[0] == '#') 
			{
				line.BackColor = Color.LightGreen;
				
				return;
			}
			
			if(line.Text.Length > 1 && line.Text[0] == '@') line.BackColor = Color.Wheat;
			
			if(line.Text.ToLower() == Scene.END_SIGNATURE) line.BackColor = Color.Gold;
			
			foreach(generic.operators.Operator op in generic.Structures.GetOperators())
			{
				Light(line, op.Instance, Color.DarkOrchid, " ");
			}
			
			foreach(string sign in generic.Structures.GetDefaultTypesSignatures())
			{
				Light(line, sign, Color.Tomato, " ");
			}
			
			foreach(string digit in new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" })
			{
				Light(line, digit, Color.DeepPink);
			}
			
			Light(line, "'", Color.MediumBlue);
			Light(line, ",", Color.Firebrick);
			Light(line, "-", Color.DarkGray);
		}
		
		public void Light(RichTextBox line, string word, Color cl, string postfix = "")
		{
			int i = 0;
			while (i <= line.Text.Length - word.Length)
			{
			    i = line.Text.IndexOf(word + postfix, i);
			    if (i < 0) break;
			    
			    line.SelectionStart = i;
			    line.SelectionLength = word.Length;
			    line.SelectionColor = cl;
			    i += word.Length;
			    
			    line.SelectionStart = i;
			    line.SelectionLength = line.Text.Length;
			    line.SelectionColor = line.ForeColor;
			}
		}
	}
}
