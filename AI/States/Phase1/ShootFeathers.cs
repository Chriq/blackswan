using Godot;
using System;

public partial class ShootFeathers : State {
    public override void Do(double delta) {
        core.label.Text = "Shoot Feathers";

        double cutoff = SoundManager.Instance.GetStreamDuration() * 0.75d;
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }
    }
}
