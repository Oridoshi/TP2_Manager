using Godot;
using System;

public class SaveManager

{
    private CustomGameLoop GameLoop;

	public SaveManager()
	{
		GameLoop = CustomGameLoop.GetInstanceGL();
		GD.PrintRich("[color=lime]OK[/color] : SaveManager created");

	}



    // Load the save file

    // Note: This can be called from anywhere inside the tree. This function is
    // path independent.
    // Go through everything in the persist category and ask them to return a
    // dict of relevant variables.
    
    public void SaveGame(string path)
    {
        
        using var saveFile = FileAccess.Open(path, FileAccess.ModeFlags.Write);

        GD.Print("Saving game...");


        var saveNodes = GameLoop.GetNodesInGroup("Persist");
        GD.Print("saveNodes: " + saveNodes);
        foreach (Node saveNode in saveNodes)
        {
            // Check the node is an instanced scene so it can be instanced again during load.
            if (string.IsNullOrEmpty(saveNode.SceneFilePath))
            {
                GD.Print($"persistent node '{saveNode.Name}' is not an instanced scene, skipped");
                continue;
            }

            // Check the node has a save function.
            if (!saveNode.HasMethod("Save"))
            {
                GD.Print($"persistent node '{saveNode.Name}' is missing a Save() function, skipped");
                continue;
            }

            // Call the node's save function.
            var nodeData = saveNode.Call("Save");

            // Json provides a static method to serialized JSON string.
            var jsonString = Json.Stringify(nodeData);

            // Store the save dictionary as a new line in the save file.
            saveFile.StoreLine(jsonString);

            GD.Print($"Saved node '{saveNode.Name}'");
        }
    }






    // Note: This can be called from anywhere inside the tree. This function is
    // path independent.
    
    public void LoadGame(string path)
    {
        if (!FileAccess.FileExists(path))
        {
            GD.Print("No save file found.");
            return; // Error! We don't have a save to load.
        }

        GD.Print("Loading game...");

        // We need to revert the game state so we're not cloning objects during loading.
        // This will vary wildly depending on the needs of a project, so take care with
        // this step.
        // For our example, we will accomplish this by deleting saveable objects.
        var saveNodes = GameLoop.GetNodesInGroup("Persist");
        foreach (Node saveNode in saveNodes)
        {
            saveNode.QueueFree();
        }

        // Load the file line by line and process that dictionary to restore the object
        // it represents.
        using var saveFile = FileAccess.Open(path, FileAccess.ModeFlags.Read);

        while (saveFile.GetPosition() < saveFile.GetLength())
        {
            var jsonString = saveFile.GetLine();
            GD.Print($"Loading: {jsonString}");

            // Creates the helper class to interact with JSON
            var json = new Json();
            var parseResult = json.Parse(jsonString);
            if (parseResult != Error.Ok)
            {
                GD.Print($"JSON Parse Error: {json.GetErrorMessage()} in {jsonString} at line {json.GetErrorLine()}");
                continue;
            }
            // Get the data from the JSON object
            var nodeData = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);
            GD.Print("Contenu du JSON Data : ", json.Data);
            
            
            // Firstly, we need to create the object and add it to the tree and set its position.
            var newObjectScene = GD.Load<PackedScene>(nodeData["Filename"].ToString());
            var newObject = newObjectScene.Instantiate<Node>();
            GameLoop.GetRoot().GetNode(nodeData["Parent"].ToString()).AddChild(newObject);
            newObject.Set(Node2D.PropertyName.Position, new Vector2((float)nodeData["posX"], (float)nodeData["posY"]));

            // Now we set the remaining variables.
            foreach (var (key, value) in nodeData)
            {
                GD.Print($"Setting {key} to {value}");
                if (key == "Filename" || key == "Parent" || key == "posX" || key == "posY")
                {
                    continue;
                }
                newObject.Set(key, value);
            }
        }
    }
    


}

