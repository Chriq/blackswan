using Godot;
using System;

public partial class ShootFeathers : State {
    float currentBeat = 0;
    int BPM = 200;

    Node2D line = null;
    public override void Do(double delta) {
        double cutoff = SoundManager.Instance.GetStreamDuration() * 0.75d;
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }

        double bps = 200d / 60d;
        double beatsPassed = time * bps;

        int beat = (int)(beatsPassed % 3) + 1;

        if (beat != currentBeat) {
            if (line != null) {
                line.QueueFree();
                line = null;
            }

            if (beat != 1) {
                line = DrawDebugLine(body.Position, core.player.Position, new Color(1, 1, 1));
            }
            //GD.Print(beat);
        }
        currentBeat = beat;
        // if ((int)(beatsPassed * 2d) % 2 != 0) {
        //     currentBeat += 0.5f;
        // }




        core.label.Text = "Shoot Feathers";
    }

    private Node2D DrawDebugLine(Vector2 from, Vector2 to, Color color) {
        Line2D line = new();
        line.AddPoint(from);
        line.AddPoint(to);
        line.Width = 2;
        line.DefaultColor = color;

        GetTree().CurrentScene.AddChild(line);
        return line;
    }
}
