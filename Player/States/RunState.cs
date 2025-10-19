using Godot;
using System;

public partial class RunState : State {
    [Export] float speed = 120;
    [Export] float acceleration = 0.5f;
    [Export] float friction = 0.2f;

    public override void PhysicsDo(double delta) {
        float h = Input.GetAxis("Left", "Right");
        float v = Input.GetAxis("Up", "Down");

        if (h != 0 || v != 0) {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, h * speed, acceleration), Mathf.Lerp(body.Velocity.Y, v * speed, acceleration));
        } else {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, 0f, friction), Mathf.Lerp(body.Velocity.Y, 0f, friction));
        }

        if (Mathf.Abs(body.Velocity.X) <= 0.1f && Mathf.Abs(body.Velocity.Y) <= 0.1f) {
            body.Velocity = Vector2.Zero;
            complete = true;
        }

        core.body.MoveAndSlide();
    }

    public override void Enter() {
        //animator.Play("run");
    }

}
