using Godot;
using System;

public partial class Wall : Area2D
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
		var control = GetNode<Control>("/root/Root/Texts");
		foreach (Label child in control.GetChildren())
		{
			child.Visible = false;
		}
	}
}
