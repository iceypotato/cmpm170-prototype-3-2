using Godot;
using System;

public partial class ResetArea : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnInputEvent(Node viewport, InputEvent @event, long shape_idx)
	{
		var control = GetNode<Control>("../Texts");
		control.Visible = true;
		// foreach (Label child in control.GetChildren())
		// {
		// 	child.Visible = true;
		// }
		// GD.Print("ligma");
	}

	private void OnMouseEntered()
	{
		var control = GetNode<Control>("../Texts");
		if (!control.Visible)
		{
			GetNode<AudioStreamPlayer>("/root/Root/ActivateMaze").Play();
		}
	}
	
}
