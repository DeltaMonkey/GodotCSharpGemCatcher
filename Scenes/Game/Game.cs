using Godot;
using System;

public partial class Game : Node2D
{
    private const double GEM_MARGIN = 50.0; 

    [Export] private Gem _gem;
    [Export] private PackedScene _gemScene;
    [Export] private Timer _spawnTimer;
    [Export] private Label _scoreLabel;
    //[Export] private NodePath _gemPath; // Game/Gem
    //private Gem _gem;

    private int _score = 0;

    public override void _Ready()
    {
        //Gem gem = GetNode<Gem>("Gem");
        //_gem = GetNode<Gem>(_gemPath);
        //_gem.OnScored += OnScored;
        _spawnTimer.Timeout += SpawnGem;
    }

    public override void _Process(double delta)
    {
    }

    private void SpawnGem() 
    {
        Rect2 vpr = GetViewportRect();
        Gem gem = (Gem)_gemScene.Instantiate();
        AddChild(gem); 

        float rX = (float)GD.RandRange(
            vpr.Position.X + GEM_MARGIN, vpr.End.X - GEM_MARGIN
        );

        gem.Position = new Vector2(rX, -100);
        gem.OnScored += OnScored;
        gem.OnGemOffScreen += GameOver;
    }

    private void OnScored()
    {
        GD.Print("OnScored triggered!");
        _score++;
        _scoreLabel.Text = $"{_score:0000}";
    }

    private void GameOver()
    {
        GD.Print("GameOver");
        foreach (Node node in GetChildren())
        {
            node.SetProcess(false);
        }
        _spawnTimer.Stop();
    }
}
