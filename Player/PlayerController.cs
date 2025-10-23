using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlayerController : Core {
    [Export] PlayerInput playerInput;

    /** State Machine **/
    [Export] RunState runState;
    [Export] IdleState idleState;
    [Export] DashState dashState;
    [Export] Attack attackState;


    public override void _Ready() {
        SetupInstances();
        machine.Set(idleState);
    }

    public void SelectState() {
        Vector2 input = playerInput.GetInputAxis();

        runState.direction = input;

        if (input != Vector2.Zero) direction = input;

        if (IsAttacking()) {
            machine.Set(attackState);
        } else if (IsDashing()) {
            machine.Set(dashState);
        } else if (input != Vector2.Zero) {
            machine.Set(runState);
        } else {
            machine.Set(idleState);
        }
    }


    public override void _PhysicsProcess(double delta) {
        SelectState();
        state.PhysicsDoBranch(delta);
    }

    private bool IsAttacking() {
        return Input.IsActionJustPressed("Attack") || (state == attackState && !state.complete);
    }

    private bool IsDashing() {
        return Input.IsActionJustPressed("Dash") || (state == dashState && !state.complete);
    }
}
