using Godot;
using System;

public partial class SummonDancers : State {
    public override void Do(double delta) {
        core.label.Text = "Summon Dancers";

        double cutoff = SoundManager.Instance.GetStreamDuration() / 2d;
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }
    }
}
