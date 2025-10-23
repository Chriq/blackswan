using Godot;
using System;

public partial class BlackSwan : Core {
    [Export] Intro intro;
    [Export] Phase1 phase1;
    [Export] Transition transition;
    [Export] Phase2 phase2;
    [Export] Outro outro;

    private bool devMode = false;

    public override void _Ready() {
        SetupInstances();
        Set(intro);
        if (devMode) Set(phase1);
    }

    public override void _Process(double delta) {
        if (state.complete) {
            if (state == intro) {
                Set(phase1, true);
                animator.Play("p1");
            } else if (state == phase1) {
                Set(transition, true);
            } else if (state == transition) {
                Set(phase2, true);
                animator.Play("p2");
            } else {
                Set(outro, true);
            }
        }

        state.DoBranch(delta);
    }

    public override void _PhysicsProcess(double delta) {
        state.PhysicsDoBranch(delta);
    }
}
