using Godot;
using System;

public partial class DamageComponent : Area2D {
    [Export] public float damage = 2f;

    [Signal] public delegate void DamageDealtEventHandler(float amount);

    public override void _Ready() {
        Disable();
        AreaEntered += DealDamageTo;
    }

    public void DealDamageTo(Area2D a) {
        HealthComponent healthComponent = a as HealthComponent;
        if (healthComponent != null) {
            healthComponent.TakeDamage(damage);
            EmitSignal(SignalName.DamageDealt, damage);
        }
    }

    public void Enable() {
        Monitoring = true;
        Monitorable = true;
        // GetChild<CollisionShape2D>(0).Disabled = false;
        Show();
    }

    public void Disable() {
        Monitoring = false;
        Monitorable = false;
        // GetChild<CollisionShape2D>(0).Disabled = true;
        Hide();
    }

}
