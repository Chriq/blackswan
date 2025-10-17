using Godot;
using System;

public partial class Phase2 : State {
    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.PHASE2);
        core.label.Text = "Phase 2";
    }

    public override void Do(double delta) {
        if (core.health.health <= 0f) {
            complete = true;
        }
    }
}
