using Godot;
using System;

public partial class Button : Godot.Button
{

	private CustomGameLoop GameLoop;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()

	{
		this.Pressed += () => _on_Button_pressed();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_Button_pressed()
	{
		// Called when Button is pressed
		CustomGameLoop.GetInstanceGL().GetSaveManager().SaveGame();
	}
}
