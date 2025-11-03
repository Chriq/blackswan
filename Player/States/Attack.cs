using Godot;
using System;

public partial class Attack : State {
    [Export] DamageComponent damage;
    [Export] AnimatedSprite2D attackEffect;

    private float knockback = 2f;

    public override void Enter() {
        damage.Enable();
        damage.Rotation = core.direction.Angle();

        attackEffect.Show();
        attackEffect.Play();
    }

    public override void PhysicsDo(double delta) {
        if (time > 0.2f) {
            complete = true;
        }
    }

    public override void Exit() {
        damage.Disable();

        attackEffect.Hide();
    }

    private void OnDamageDealt(float a) {
        core.body.Velocity += core.direction * knockback;
    }
}
