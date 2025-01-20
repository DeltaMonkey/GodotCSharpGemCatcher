using Godot;
using System;

public partial class Game : Node2D
{
    public override void _Ready()
    {
    }

    private void OnScored()
    {
        GD.Print("OnScored triggered!");
    }
}
