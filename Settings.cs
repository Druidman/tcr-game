using Godot;
using System;

public partial class Settings : Control
{
	[Export]
	Control mainMenu;
	public void OnReturn()
	{
		this.Visible = false;
		mainMenu.Visible = true;
	}
}
