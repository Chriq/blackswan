using Godot;
using System;

public partial class Transition : State {
    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.TRANSITION);
        core.label.Text = "Transition";
    }

    // TODO: Refactor for seamless audio transitions
    public override void Do(double delta) {
        double cutoff = SoundManager.Instance.GetStreamDuration();
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time >= cutoff - 0.1f) {
            complete = true;
        }
    }
}
