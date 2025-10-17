using Godot;
using System;

public partial class SweepAttack : State {
    public override void Do(double delta) {
        core.label.Text = "Sweep Attack";

        double cutoff = SoundManager.Instance.GetStreamDuration() / 4d;
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }
    }
}
