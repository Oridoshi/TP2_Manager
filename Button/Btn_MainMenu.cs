using Godot;
using System;

public partial class Btn_MainMenu : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += BtnPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void BtnPressed()
	{
		CustomGameLoop.GetInstanceGL().GetSaveManager().SaveGame("res://save/savegame.json");
		CustomGameLoop.GetInstanceGL().GetLevelManager().loadScene("res://levels/MainMenu.tscn");
	}
}
