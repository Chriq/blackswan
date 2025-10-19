using Godot;
using System;

public partial class Attack : State {
    [Export] DamageComponent damage;

    public override void Enter() {
        damage.Enable();
        damage.Rotation = core.direction.Angle();
    }

    public override void Do(double delta) {
        if (time > 0.5f) {
            complete = true;
        }
    }

    public override void Exit() {
        damage.Disable();
    }

    // private void DealDamage(Area2D area) {
    //     HealthComponent healthComponent = area as HealthComponent;
    //     damage.DealDamageTo(healthComponent);
    // }
}
