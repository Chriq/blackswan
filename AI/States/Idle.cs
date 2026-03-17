using Godot;
using System;

public partial class Idle : State {
    [Export] float idleTime = 1f;
    [Export] SpriteFrames phase1IdleAnim;
    [Export] SpriteFrames phase2IdleAnim;

    private float timer;

    public override void Enter() {
        timer = 0f;
    }

    public override void Do(double delta) {
        timer += (float)delta;
        if (timer > idleTime) {
            complete = true;
        }
    }
}
