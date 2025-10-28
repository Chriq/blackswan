using Godot;
using System;

public partial class HealthComponent : Area2D {
    [Signal]
    public delegate void DiedEventHandler();

    [Export] Label healthbar;
    [Export] public float health { get; private set; } = 10f;

    public override void _Ready() {
        healthbar.Text = health.ToString();
    }


    public void TakeDamage(float damage) {
        health -= damage;

        healthbar.Text = health.ToString();

        if (health <= 0f) EmitSignal(SignalName.Died);
    }

    public void SetHealth(float amt) {
        health = amt;
        healthbar.Text = health.ToString();
    }

}
