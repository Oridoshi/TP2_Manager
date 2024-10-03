
using Godot;
using System;

[GlobalClass]
public partial class CustomGameLoop : SceneTree
{
	private static CustomGameLoop instance;

    private CustomGameLoop()
    {
        instance = this;
    }

    public static CustomGameLoop GetInstanceGL()
    {
        if (instance == null)
        {
            instance = new CustomGameLoop();
        }

        return instance;
    }

}
