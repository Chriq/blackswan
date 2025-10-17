using Godot;
using System;

public partial class HealthComponent : Label {
    [Export] public float health { get; private set; } = 10f;
    public override void _Process(double delta) {
        health -= (float)delta;
        Text = health.ToString();
    }

    public void ResetHealth() {
        health = 10f;
    }
}
