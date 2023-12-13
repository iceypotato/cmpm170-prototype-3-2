using Godot;
using System;

public partial class Path : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnMouseExited()
	{
		var texts = GetNode<Control>("../Texts");
		if (texts.Visible)
		{
			GetNode<AudioStreamPlayer>("/root/Root/DeviateFromMaze").Play();
			GD.Print("deviated");
		}
		texts.Visible = false;
	}
}
