using Godot;
using System;

public partial class Transition : State {
    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.TRANSITION);
        core.label.Text = "Transition";
    }

    public override void Do(double delta) {
        if (core.health.health <= 0f) {
            complete = true;
        }
    }
}
