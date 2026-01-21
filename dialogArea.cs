using Godot;
using System;

public partial class dialogArea : Area3D
{
	[Export]
	Label3D dialog;
	public void EnteredDialogArea(Node3D body)
	{
		if (body is Player)
		{
			dialog.Visible = true;	
			dialog.Rotation = body.Rotation;
		}
		
	}
	public void ExitedDialogArea(Node3D body)
	{
		if (body is Player)
		{
			dialog.Visible = false;	
		}
	}

}
