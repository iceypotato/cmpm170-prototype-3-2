using Godot;
using System;

public partial class LoadMaze : Node2D
{
	public string SelectedWord;
	private Label[] _labels;
	private string[] _wordBank =
	{
		"GALAXY",
		"PLANET",
		"FOLLOW"
	};

	public override void _Ready()
	{
		var path1 = GetNode<Area2D>("./Path1");
		path1.InputPickable = false;
		path1.Visible = false;
		var path2 = GetNode<Area2D>("./Path2");
		path2.InputPickable = false;
		path2.Visible = false;
		var path3 = GetNode<Area2D>("./Path3");
		path3.InputPickable = false;
		path3.Visible = false;
		GD.Print("loading maze");
		SelectRandom();
	}
	
	public void SelectRandom(){
		// Randomly pick one path to enable
		int mazeNumber = new Random().Next(3); // Generates a random number between 0 and 2
		
		GD.Print("Maze selected: " + mazeNumber);
		
		var selectedPathNode = GetNode<Area2D>("/root/Root/Mazes/Path" + (mazeNumber + 1));
		selectedPathNode.Visible = true;
		selectedPathNode.InputPickable = true;
		
		var mazeLabel = GetNode<Label>("/root/Root/MazeLabel");

		var mazeMap = GetNode<Sprite2D>("../MazeMap");
		mazeMap.Texture = GD.Load<CompressedTexture2D>("res://assets/maze" + (mazeNumber + 1) + ".png");
		
		// Randomly pick one text
		int randomText = new Random().Next(3); // Generates a random number between 0 and 2
		SelectedWord = _wordBank[randomText];
		GD.Print("Text selected: " + SelectedWord);
		
		// Set the text for each label based on the selected letter, and move the texts in the right spot
		Vector2[,] spots =
		{
			{new Vector2(208, 88), new Vector2(216, 344), new Vector2(216, 472), new Vector2(464, 600), new Vector2(728, 600), new Vector2(1176, 464) },
			{new Vector2(208, 88), new Vector2(216, 344), new Vector2(600, 344), new Vector2(720, 216), new Vector2(856, 464), new Vector2(1176, 464)}, 
			{new Vector2(88, 216), new Vector2(384, 216), new Vector2(616, 216), new Vector2(760, 336), new Vector2(976, 344), new Vector2(1176, 464) },
		};
		for (int i = 0; i < 6; i++)
		{
			var label = GetNode<Label>("/root/Root/Mazes/Texts/Label" + (i + 1));
			label.Text = SelectedWord[i].ToString();
			label.Position = spots[mazeNumber, i];
		}
	}
	
	private void OnInputEvent(Node viewport, InputEvent @event, long shape_idx)
	{
		if (Input.IsActionJustPressed("Mouse1"))
		{
			SelectRandom();
		}
	}
}
