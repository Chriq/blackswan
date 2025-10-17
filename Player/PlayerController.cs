using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlayerController : Core {

    [Export] float speed = 120;
    [Export] float friction = 0.2f;
    [Export] float acceleration = 0.5f;

    /** State Machine **/
    [Export] RunState runState;
    [Export] IdleState idleState;
    [Export] DashState dashState;



    public override void _Ready() {
        SetupInstances();
        machine.Set(idleState);
    }

    public void SelectState(float axis) {
        if (axis != 0f) {
            machine.Set(runState);
        } else {

        }
    }


    public override void _PhysicsProcess(double delta) {
        Move((float)delta);
    }

    private void Move(float delta) {
        float input = Input.GetAxis("Left", "Right");
        animator.FlipH = input < 0f || (input == 0f && animator.FlipH);

        SelectState(input);
        machine.state.PhysicsDo(delta);

        body.MoveAndSlide();
    }
}
