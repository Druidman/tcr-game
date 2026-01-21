using Godot;
using System;

public partial class dialogArea : Area3D
{
	[Export]
	Label3D dialog;

	[Export]
	Player player;

	bool isPlayerIn = false;
	public void EnteredDialogArea(Node3D body)
	{
		if (body is Player)
		{
			dialog.Visible = true;	
			dialog.Rotation = body.Rotation;
			isPlayerIn = true;
		}
		
	}
	public void ExitedDialogArea(Node3D body)
	{
		if (body is Player)
		{
			dialog.Visible = false;	
			isPlayerIn = false;
		}
	}


}
