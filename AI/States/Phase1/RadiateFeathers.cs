using Godot;
using System;

public partial class RadiateFeathers : State {
    [Export] Node2D rotator;
    [Export] PackedScene featherPrefab;

    [Export] private float radius = 20f;
    [Export] private int count = 6;
    [Export] private float rotateSpeed = 80f;
    [Export] private float spawnRate = 0.5f;

    private float spawnTimer = 0f;


    public override void Enter() {
        float interval = 2f * Mathf.Pi / count;
        for (int i = 0; i < count; i++) {
            Vector2 dir = Vector2.FromAngle(i * interval);
            Node2D spawnPoint = new();

            spawnPoint.Position = rotator.Position + dir * radius;
            spawnPoint.Rotation = dir.Angle();
            rotator.AddChild(spawnPoint);
        }
    }


    public override void Do(double delta) {
        float newRotation = rotator.RotationDegrees + rotateSpeed * (float)delta;
        rotator.RotationDegrees = newRotation % 360f;

        if (spawnTimer >= spawnRate) {
            SpawnFeathers();
            spawnTimer = 0f;
        }

        spawnTimer += (float)delta;

        core.label.Text = "Radiate Feathers";

        double cutoff = SoundManager.Instance.GetStreamDuration();
        double time = SoundManager.Instance.GetPlaybackTime();

        if (time > cutoff || time < 1f) {
            complete = true;
        }
    }

    private void SpawnFeathers() {
        foreach (Node2D n in rotator.GetChildren()) {
            Feather feather = featherPrefab.Instantiate<Feather>();
            GetTree().CurrentScene.AddChild(feather);
            feather.Position = n.GlobalPosition;
            feather.Rotation = n.GlobalRotation;
        }
    }
}
