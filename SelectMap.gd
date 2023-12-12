extends Node



# Called when the node enters the scene tree for the first time.
func _ready():
	# Get all the nodes you want to control
	var label = get_node("MazeLabel") 
	var node1 = get_node("Maze")
	var node2 = get_node("Maze2")
	var node3 = get_node("Maze3")

	# Disable all nodes initially
	node1.set_process(false)
	node2.set_process(false)
	node3.set_process(false)

	# Randomly pick one node to enable
	var random_node = randi() % 3  # Generates a random number between 0 and 2
	
	
	match random_node:
		0:
			node1.set_process(true)
			label.text = "Selected: 1"
		1:
			node2.set_process(true)
			label.text = "Selected: 2"
		2:
			node3.set_process(true)
			label.text = "Selected: 3"


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
