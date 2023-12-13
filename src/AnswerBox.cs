using Godot;
using System;
using System.Net.Mime;

public partial class AnswerBox : TextEdit
{
	private LoadMaze _loadMaze;
	private Label _correct;

	private double _displayText = 500.0;
	private double _timeLeft;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_loadMaze = (LoadMaze) GetNode<Node2D>("/root/Root/Mazes");
		_correct = GetNode<Label>("/root/Root/Correct");
			
		GD.Print(_loadMaze.SelectedWord);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// If the user gets the word right, reset and randomize.
		if (_loadMaze.SelectedWord.Equals(Text, StringComparison.OrdinalIgnoreCase) )
		{
			_loadMaze._Ready();
			_correct.Visible = true;
			_timeLeft = 3.0;
			Text = "";
		}
		if (_timeLeft > 0)
		{
			GD.Print(_timeLeft);
			_timeLeft -= delta;
		}
		if (_timeLeft <= 0)
		{
			_correct.Visible = false;
		}
	}
}
