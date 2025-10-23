using Godot;
using System;

public partial class Outro : State {
    public override void Enter() {
        PlayerInput.Instance.Disable();
        SoundManager.Instance.Play(AudioPath.OUTRO);
        core.label.Text = "Outro";
    }
}
