using Godot;
using System;

public class LevelManager
{
	private CustomGameLoop GameLoop;

	public LevelManager()
	{
		GameLoop = CustomGameLoop.GetInstanceGL();
		GD.PrintRich("[color=lime]OK[/color] : LevelManager created");
	}
	public void loadScene(string path)
	{
		try
		{
			Node scene = ResourceLoader.Load<PackedScene>(path).Instantiate();

			//Remove the previous scene
			GameLoop.Root.GetChild(0).QueueFree();

			//Add the scene to the root of the scene tree
			GameLoop.Root.AddChild(scene);

			GD.PrintRich("[color=lime]OK[/color] : chargement du niveau " + path);
		}
		catch (Exception)
		{
			GD.PrintRich("[color=red]ERR[/color] : chargement du niveau " + path);
		}
	}
}
