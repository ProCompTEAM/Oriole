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
using System.Drawing;
using System.Windows.Forms;

namespace Oriole.scene
{
	public class SceneUI
	{
		public readonly Scene Parent;
		
		Form Window = new Form();
		
		public const int WIDTH = 400;
		public const int HEIGHT = 600;
		
		bool IsOpened = false;
		
		public bool Opened
		{
			get { return IsOpened; }
		}
		
		public SceneUI(Scene scene)
		{
			Parent = scene;
			
			Window.Size = new System.Drawing.Size(WIDTH, HEIGHT);
			Window.Text = Parent.Name;
			Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			
			Window.FormClosing += Window_FormClosing;
			
			ClearLines();
			
			SetLine(0, "#METASTART : scene " + Parent.Name);
			SetLine(1, "END");
		}
		
		public void Open()
		{
			IsOpened = true;
			
			Window.Show();
		}
		
		public void Activate()
		{
			Window.Activate();
			Window.Focus();
			Window.Select();
		}
		
		public void Close()
		{
			IsOpened = false;
			
			Window.Hide();
		}

		void Window_FormClosing(object sender, FormClosingEventArgs e)
		{
			Close();
			
			e.Cancel = true;
		}
		
		//draw place for coding
		
		public ui.ILighter Lighter = new ui.DefaultWhiteLighter();
		
		int CursorPointer = 0;
		
		public int LinePosition
		{
			get { return CursorPointer; }
		}
		
		void ClearLines()
		{
			ui.LoadingScreen ls = new ui.LoadingScreen();
			ls.Show();
			
			Window.AutoScroll = true;
			Window.SetAutoScrollMargin(0, 0);
			Window.AutoScrollMinSize = new Size(0, 0);
			
			Window.Controls.Clear();
			
			for(int i = 0; i < 500; i++) AddLine();
			
			Lighter.Load(this);
			
			ls.Close();
		}
		
		public Font LineFont = new Font(FontFamily.GenericMonospace, 18);
		public Color LineColor = Color.Black;
		public Color LineBG = Color.WhiteSmoke;
		public Color LineBGActive = Color.AntiqueWhite;
		public Color LineBGPlayed = Color.LightSkyBlue;
		
		RichTextBox AddLine()
		{
			RichTextBox line = new RichTextBox();
			
			line.Width = WIDTH * 2;
			line.Height = 28;
			line.Font = LineFont;
			line.BackColor = LineBG;
			line.ForeColor = LineColor;
			line.BorderStyle = BorderStyle.None;
			line.ScrollBars = RichTextBoxScrollBars.None;
			line.AcceptsTab = true;
			line.Multiline = false;
			
			line.GotFocus += line_GotFocus;
			line.LostFocus += line_LostFocus;
			line.KeyDown += line_KeyDown;
			
			line.Top = line.Font.Height * Window.Controls.Count;
			line.Tag = Window.Controls.Count;
			
			Window.Controls.Add(line);
			
			return line;
		}

		void line_GotFocus(object sender, EventArgs e)
		{
			if(generic.Oriole.ExecutingScene == null)
			{
				((RichTextBox) sender).BackColor = LineBGActive;
				
				SetTitle("Watch");
			}
			else
			{	
				((RichTextBox) sender).BackColor = LineBGPlayed;
				
				SetTitle("Play");
			}
			
			int pos = ((RichTextBox) sender).SelectionStart;
				
			((RichTextBox) sender).Select(0, ((RichTextBox) sender).Text.Length);
				
			((RichTextBox) sender).SelectionColor = ((RichTextBox) sender).ForeColor;
				
			((RichTextBox) sender).SelectionStart = pos;
			
			CursorPointer = (int) ((RichTextBox) sender).Tag;
		}

		void line_LostFocus(object sender, EventArgs e)
		{
			((RichTextBox) sender).BackColor = LineBG;
			
			Lighter.Update((RichTextBox) sender);
		}

		void line_KeyDown(object sender, KeyEventArgs e)
		{
			RichTextBox line = ((RichTextBox) sender);
			
			SetTitle("Edit");
			
			if(e.KeyCode == Keys.Enter)
			{
				if(CursorPointer == Window.Controls.Count - 1) AddLine();
			}
			
			if(e.KeyCode == Keys.Up || (line.Text == "" && e.KeyCode == Keys.Back))
			{
				int lnum = ((int) line.Tag);
				
				if(lnum > 0) 
				{
					Window.Controls[lnum - 1].Focus();
					
					((RichTextBox) Window.Controls[lnum - 1]).SelectionStart = line.Text.Length;
					((RichTextBox) Window.Controls[lnum - 1]).SelectionLength = 0;
				}
			}
			
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
			{
				int lnum = ((int) line.Tag);
				
				if(lnum < Window.Controls.Count - 1) 
				{
					Window.Controls[lnum + 1].Focus();
					
					((RichTextBox) Window.Controls[lnum + 1]).SelectionStart = line.Text.Length;
					((RichTextBox) Window.Controls[lnum + 1]).SelectionLength = 0;
				}
			}
			
			if(e.KeyCode == Keys.Right && line.Text == "") line.Text += '	';
			
			if(e.KeyCode == Keys.F1) 
			{
				Parent.EXData = GetLines();
				Export.Save(Parent, true);
				SetTitle("Saved");
			}
			
			if(e.KeyCode == Keys.F2)
			{
				Parent.EXData = Export.Load(Parent);
				
				DialogResult d = MessageBox.Show("Do you want to load data by deleting the current one?",
				        "Load", MessageBoxButtons.YesNo);
				if(d == DialogResult.Yes)
				{
					ClearLines();
				
					for(int i = 0; i < Parent.EXData.Length; i++)
						SetLine(i, Parent.EXData[i]);
					
					UpdateLightning();
					
					SelectLine(0);
				}
			}
			
			if(e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4)
			{	
				if(Parent.IsRunning) 
				{
					Parent.Interrupt();
					
					//ChangeMode(Mode.Editor);
				}
				else 
				{
					Parent.EXData = GetLines();
					
					if(e.KeyCode == Keys.F4) Parent.Run();
					else Parent.Run(CursorPointer - 1);
					
					//ChangeMode(Mode.Player);
				}
				
				SetTitle("Play");
			}
			
			if(e.Control)
			{
				if(e.KeyCode == Keys.D) 
				{
					if(CursorPointer < Window.Controls.Count - 1) 
						SetLine(CursorPointer + 1, GetLine(CursorPointer));
				}
				if(e.KeyCode == Keys.R) SetLine(CursorPointer, "");
				if(e.KeyCode == Keys.S) 
				{
					Parent.EXData = GetLines();
					Export.Save(Parent);
					SetTitle("Saved");
				}
			}
			
			if(e.KeyCode == Keys.Escape) Close();
		}
		
		public void SetTitle(string status)
		{
			Window.Text = Parent.Name + " | L" + (CursorPointer + 1) + " | " + status + 
				" | F1 (Save) F2 (Load) F3 (Play) F4 (Play All)";
		}
		
		public string[] GetLines(bool beforeEnd = false)
		{
			List<string> list = new List<string>();
			
			foreach(Control c in Window.Controls)
			{
				list.Add(c.Text);
				
				if(beforeEnd && c.Text == Scene.END_SIGNATURE) break;
			}
			
			return list.ToArray();
		}
		
		public string GetLine(int number)
		{
			if(number >= 0 && number < Window.Controls.Count)
				return Window.Controls[number].Text;
			else return "";
		}
		
		public void SetLine(int number, string data = "")
		{
			if(number >= 0 && number < Window.Controls.Count)
				Window.Controls[number].Text = data;
		}
		
		public enum Mode
		{
			Editor,
			Player
		}
		
		Mode ModeNow = Mode.Editor;
		
		public Mode CurrentMode
		{
			get { return ModeNow; }
		}
		
		public void ChangeMode(Mode mode)
		{
			if(mode == Mode.Player)
			{
				foreach(Control c in Window.Controls)
				{
					((RichTextBox) c).ReadOnly = true;
				}
			}
			else if(mode == Mode.Editor)
			{
				foreach(Control c in Window.Controls)
				{
					((RichTextBox) c).ReadOnly = false;
				}
			}
			
			ModeNow = mode;
		}
		
		public RichTextBox SelectLine(int number)
		{
			if(number >= 0 && number < Window.Controls.Count)
			{
				((RichTextBox) Window.Controls[number]).Focus();
				((RichTextBox) Window.Controls[number]).SelectionStart = 0;
				return (RichTextBox) Window.Controls[number];
			}
			else return null;
		}
		
		public void UpdateLightning()
		{
			string[] lines = GetLines(true);
			
			for(int i = 0; i < lines.Length; i++)
				Lighter.Update((RichTextBox) Window.Controls[i]);
		}
	}
}
