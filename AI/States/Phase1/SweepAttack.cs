using Godot;
using System;

public partial class SweepAttack : State {
	[Export] float speed = 60;
    [Export] float acceleration = 0.5f;
    [Export] float friction = 0.5f;

    public override void Enter() {
        core.animator.Play("waltz");
        core.label.Text = "Sweep Attack";
    }
    
    int currentBeat = 0;

	public override void Do(double delta) {
		double cutoff = SoundManager.Instance.GetStreamDuration() / 4d;
		double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }

        int beat = (int)(SoundManager.Instance.GetStreamDuration() / time) % 3 + 1;
        if (beat != currentBeat) GD.Print(beat); 
        currentBeat = beat;

	}

    public override void PhysicsDo(double delta) {
		Vector2 direction = (core.player.Position - core.body.Position).Normalized();

		if(direction.X < 0f) {
			core.animator.FlipH = false;
        } else {
            core.animator.FlipH = true;
        }

        if (direction != Vector2.Zero) {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, direction.X * speed, acceleration), Mathf.Lerp(body.Velocity.Y, direction.Y * speed, acceleration));
        } else {
            body.Velocity = new Vector2(Mathf.Lerp(body.Velocity.X, 0f, friction), Mathf.Lerp(body.Velocity.Y, 0f, friction));
        }

        if (Mathf.Abs(body.Velocity.X) <= 0.1f && Mathf.Abs(body.Velocity.Y) <= 0.1f) {
            body.Velocity = Vector2.Zero;
        }

        core.body.MoveAndSlide();
    }
}
