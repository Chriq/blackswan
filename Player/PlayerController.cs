using Godot;

public partial class PlayerController : Core {
    [Export] PlayerInput playerInput;

    /** State Machine **/
    [Export] RunState runState;
    [Export] IdleState idleState;
    [Export] DashState dashState;
    [Export] Attack attackState;
    [Export] DeadState deadState;

    private bool dead = false;


    public override void _Ready() {
        SetupInstances();
        machine.Set(idleState);

        healthComponent.Died += OnDied;
    }

    public void SelectState() {
        Vector2 input = playerInput.GetInputAxis();

        runState.direction = input;

        if (input != Vector2.Zero) direction = input;

        if (IsDead()) {
        } else if (IsAttacking()) {
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

    private bool IsDead() {
        return state == deadState && !state.complete;
    }

    private void OnDied() {
        //machine.Set(deadState);
    }
}
