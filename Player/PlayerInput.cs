using Godot;
using System;

public partial class PlayerInput : Node {
    public static PlayerInput Instance;

    private Vector2 axis;
    private bool enabled = true;
    public override void _Ready() {
        Instance = this;
    }


    public Vector2 GetInputAxis() {
        if (!enabled) return Vector2.Zero;

        float x = Input.GetAxis("Left", "Right");
        float y = Input.GetAxis("Up", "Down");

        return new Vector2(x, y).Normalized();
    }

    public void Disable() {
        enabled = false;
    }

    public void Enable() {
        enabled = true;
    }
}
