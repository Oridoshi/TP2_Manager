
using Godot;
using System;

[GlobalClass]
public partial class CustomGameLoop : SceneTree
{
	private static CustomGameLoop instance;

    private static LevelManager levelManager;

    private CustomGameLoop()
    {
        instance = this;
        levelManager = new LevelManager();
        GD.PrintRich("[color=lime]OK[/color] : CustomGameLoop created");
    }

    public static CustomGameLoop GetInstanceGL()
    {
        if (instance == null)
        {
            instance = new CustomGameLoop();
        }

        return instance;
    }

    public LevelManager GetLevelManager()
    {
        return levelManager;
    }

}
