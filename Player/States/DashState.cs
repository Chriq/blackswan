using Godot;
using System;

public partial class DashState : State {
    [Export] float DASH_DISTANCE = 100f;
    [Export] float DASH_TIME = 0.12f;

    private double dashTimer = 0f;
    private Vector2 dashDirection = Vector2.Right;

    public override void Enter() {
        dashDirection = core.direction;
    }

    public override void PhysicsDo(double delta) {
        body.Velocity = ComputeDerivative((float)delta) * dashDirection;
        dashTimer += delta;

        if (dashTimer >= DASH_TIME) {
            complete = true;
            dashTimer = 0;
        }

        core.body.MoveAndSlide();
    }

    public override void Exit() {
        dashTimer = 0d;
        body.Velocity = Vector2.Zero;
    }

    // [f(x+h) - f(x-h)] / 2h
    private float ComputeDerivative(float h) {
        float t1 = (float)(dashTimer + h) / DASH_TIME;
        float t2 = (float)(dashTimer - h) / DASH_TIME;

        float ease1 = MathUtil.EaseInOut(t1);
        float ease2 = MathUtil.EaseInOut(t2);

        float real1 = MathUtil.Map(ease1, 0, 1, 0, DASH_DISTANCE);
        float real2 = MathUtil.Map(ease2, 0, 1, 0, DASH_DISTANCE);

        return (real1 - real2) / (2 * h);
    }
}
