using Godot;
using System;

public partial class RadiateFeathers : State {
    public override void Do(double delta) {
        core.label.Text = "Radiate Feathers";

        double cutoff = SoundManager.Instance.GetStreamDuration();
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff || time < 1f) {
            complete = true;
        }
    }
}
