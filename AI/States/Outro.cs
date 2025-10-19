using Godot;
using System;

public partial class Outro : State {
    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.OUTRO);
        core.label.Text = "Outro";
    }
}
