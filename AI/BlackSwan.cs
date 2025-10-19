using Godot;
using System;

public partial class BlackSwan : Core {
    [Export] Intro intro;
    [Export] Phase1 phase1;
    [Export] Transition transition;
    [Export] Phase2 phase2;
    [Export] Outro outro;

    public override void _Ready() {
        SetupInstances();
        Set(intro);
    }

    public override void _Process(double delta) {
        if (state.complete) {
            if (state == intro) {
                Set(phase1, true);
            } else if (state == phase1) {
                Set(transition, true);
            } else if (state == transition) {
                Set(phase2, true);
            } else {
                Set(outro, true);
            }
        }

        state.DoBranch(delta);
    }
}
