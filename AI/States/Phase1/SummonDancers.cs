using Godot;
using System;
using System.Collections.Generic;

public partial class SummonDancers : State {
    [Export] PackedScene dancerPrefab;
    [Export] private float radius = 20f;
    [Export] private int count = 4;

    private List<CharacterBody2D> dancers = new();

    public override void Enter() {
        float interval = 2f * Mathf.Pi / count;
        for (int i = 0; i < count; i++) {
            Vector2 dir = Vector2.FromAngle(i * interval);
            CharacterBody2D dancer = dancerPrefab.Instantiate<CharacterBody2D>();
            dancer.Position = body.Position + dir * radius;
            dancers.Add(dancer);
            GetTree().CurrentScene.AddChild(dancer);
        }
    }

    public override void Do(double delta) {
        core.label.Text = "Summon Dancers";

        double cutoff = SoundManager.Instance.GetStreamDuration() / 2d;
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff) {
            complete = true;
        }
    }

    public override void Exit() {
        ClearDancers();
    }

    private void ClearDancers() {
        foreach (CharacterBody2D dancer in dancers) {
            dancer.QueueFree();
        }

        dancers.Clear();
    }

}
