using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlayerController : Core {
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
        float x = Input.GetAxis("Left", "Right");
        float y = Input.GetAxis("Up", "Down");

        Vector2 input = new Vector2(x, y);
        if (input != Vector2.Zero) direction = input.Normalized();

        if (Input.IsActionJustPressed("Attack")) {
            machine.Set(attackState, true);
        } else if (Input.IsActionJustPressed("Dash")) {
            machine.Set(dashState, true);
        } else if (x != 0f || y != 0f) {
            machine.Set(runState);
        }
    }


    public override void _PhysicsProcess(double delta) {
        SelectState();
        state.PhysicsDoBranch(delta);
    }
}
