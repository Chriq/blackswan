using Godot;
using System;

public partial class CameraFollow : Camera2D {
    [Export] Node2D player;

    public override void _Process(double delta) {
        float y = Mathf.Lerp(Position.Y, player.Position.Y, 0.1f);
        Position = new Vector2(Position.X, y);
    }
}
