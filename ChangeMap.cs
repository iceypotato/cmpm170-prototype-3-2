using Godot;
using System;

public partial class ChangeMap : Area2D
{
	Label label;
	Node2D node1;
	Node2D node2;
	Node2D node3;
	Label[] labels;
	string[] letters;

	public override void _Ready()
	{
		// Get references to the Label nodes
		labels = new Label[6];
		
		for (int i = 0; i < 6; i++)
		{
			labels[i] = GetNode<Label>("/root/Root/Texts/Label" + (i + 1));
		}

		
		
		// Get the Label node
		label = GetNode<Label>("/root/Root/MazeLabel"); // Replace "LabelNode" with the actual name or path of your Label node
			
		// Get all the nodes you want to control
		node1 = GetNode<Node2D>("/root/Root/Mazes/Maze");
		node2 = GetNode<Node2D>("/root/Root/Mazes/Maze2");
		node3 = GetNode<Node2D>("/root/Root/Mazes/Maze3");

		SelectRandom();
	}
	
	public void SelectRandom(){
		// Disable all nodes initially
		node1.SetProcess(false);
		node2.SetProcess(false);
		node3.SetProcess(false);

		// Randomly pick one node to enable
		int randomNode = new Random().Next(3); // Generates a random number between 0 and 2
		GD.Print("Maze selected");
		
		switch (randomNode)
		{
			case 0:
				node1.SetProcess(true);
				label.Text = "Selected: 1";
				break;
			case 1:
				node2.SetProcess(true);
				label.Text = "Selected: 2";
				break;
			case 2:
				node3.SetProcess(true);
				label.Text = "Selected: 3";
				break;
		}
		
		// Randomly pick one text
		int randomText = new Random().Next(3); // Generates a random number between 0 and 2
		GD.Print("Text selected");
		
		switch (randomText)
		{
			case 0:
				letters = new string[] { "G", "A", "L", "A", "X", "Y"};
				break;
			case 1:
				letters = new string[] { "P", "L", "A", "N", "E", "T"};
				break;
			case 2:
				letters = new string[] { "F", "O", "L", "L", "O", "W"};
				break;
		}
		
		// Set the text for each label based on the selected letter
		for (int i = 0; i < 6; i++)
		{
			labels[i].Text = letters[i];
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
