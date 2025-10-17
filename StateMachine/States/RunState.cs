using Godot;
using System;

public partial class RunState : State {
    [Export] float speed = 120;
    [Export] float acceleration = 0.5f;
    [Export] float friction = 0.2f;

    public override void PhysicsDo(double delta) {
        float dir = Input.GetAxis("Left", "Right");

        if (dir != 0) {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, dir * speed, acceleration), body.Velocity.Y);
        } else {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, 0f, friction), body.Velocity.Y);
        }

        if (Mathf.Abs(body.Velocity.X) < 25f) {
            body.Velocity = new Vector2(0f, body.Velocity.Y);
            complete = true;
        }
    }

    public override void Enter() {
        //animator.Play("run");
    }

}
