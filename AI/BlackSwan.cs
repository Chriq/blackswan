using Godot;
using System;

public partial class BlackSwan : Core {
    [Export] Phase1 phase1;

    public override void _Ready() {
        SetupInstances();
        Set(phase1);
    }

    public override void _Process(double delta) {
        state.DoBranch(delta);
    }
}
