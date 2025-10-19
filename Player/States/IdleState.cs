using Godot;
using System;

public partial class IdleState : State {
    public override void Enter() {
        //animator.Play("idle");
        body.Velocity = Vector2.Zero;
        complete = true;
    }

}
