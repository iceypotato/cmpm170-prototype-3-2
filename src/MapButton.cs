using Godot;
using System;

public partial class MapButton : Area2D
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
		if (Input.IsActionJustPressed("Mouse1"))
		{
			var mapSprite = GetNode<Sprite2D>("/root/Root/MazeMap");
			mapSprite.Visible = true;
			var closeMapButton = GetNode<Area2D>("/root/Root/CloseMapButton");
			closeMapButton.Visible = true;
			closeMapButton.InputPickable = true;

			var bg = GetNode<ColorRect>("/root/Root/BG");
			bg.ZIndex = 2;
			InputPickable = false;
		}
	}

}
