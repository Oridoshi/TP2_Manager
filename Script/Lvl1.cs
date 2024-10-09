using Godot;
using System;

public partial class Lvl1 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CustomGameLoop.GetInstanceGL().GetSaveManager().LoadGame("res://save/savegame.json");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
