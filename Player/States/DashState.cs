using Godot;
using System;

public partial class DashState : State {
    const float ACCELERATION = 0.9f;
    const float FRICTION = 1f;
    const float DASH_SPEED = 1000f;
    const float DASH_TIME = 0.12f;

    private double dashTimer = 0f;
    private Vector2 dashDirection = Vector2.Right;

    public override void Enter() {
        dashDirection = core.direction;
    }

    public override void PhysicsDo(double delta) {
        if (dashDirection != Vector2.Zero) {
            body.Velocity = new Vector2(
                Mathf.Lerp(body.Velocity.X, dashDirection.X * DASH_SPEED, ACCELERATION),
                Mathf.Lerp(body.Velocity.Y, dashDirection.Y * DASH_SPEED, ACCELERATION)
            );
        }

        dashTimer += delta;

        if (dashTimer >= DASH_TIME) {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, 0f, FRICTION), Mathf.Lerp(body.Velocity.Y, 0f, FRICTION));
        }

        if (body.Velocity.Length() <= 0.1f) {
            complete = true;
        }

        core.body.MoveAndSlide();
    }

    public override void Exit() {
        dashTimer = 0d;
        body.Velocity = Vector2.Zero;
    }
}
