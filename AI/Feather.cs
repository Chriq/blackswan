using Godot;
using System;

public partial class Feather : Area2D {
    public Vector2 direction = Vector2.Right;
    public float speed = 60f;

    private float timer = 0f;

    public override void _Process(double delta) {
        Position += Transform.X * speed * (float)delta;
        speed -= (float)delta * 4f;

        timer += (float)delta;

        if (timer >= 4f) {
            QueueFree();
        }
    }
}
