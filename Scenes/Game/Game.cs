using Godot;
using System;

public partial class Game : Node2D
{
    [Export] private Gem _gem;
    //[Export] private NodePath _gemPath; // Game/Gem
    //private Gem _gem;

    public override void _Ready()
    {
        //Gem gem = GetNode<Gem>("Gem");
        //_gem = GetNode<Gem>(_gemPath);
        _gem.OnScored += OnScored;
    }

    private void OnScored()
    {
        GD.Print("OnScored triggered!");
    }
}
