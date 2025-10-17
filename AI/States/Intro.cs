using Godot;
using System;

public partial class Intro : State {
    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.INTRO);
        core.label.Text = "Intro";
    }

    public override void Do(double delta) {
        if (core.health.health <= 0f) {
            complete = true;
        }
    }
}
