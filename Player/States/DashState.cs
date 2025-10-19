using Godot;
using System;

public partial class DashState : State {
    const float MAX_SPEED = 64.5f;
    const float ACCELERATION = 18.5f;
    const float FRICTION = 22.5f;

    const float DASH_SPEED = 180f;
    const float DASH_TIME = 0.12f;

    bool canDash = true;
    float dashTimer = 0f;
    Vector2 dashDirection = Vector2.Zero;

    const float DASH_RELOAD_COST = 0.5f;

    float dashReloadTimer = 0f;



    public override void Do(double delta) {
        float x = Input.GetAxis("Left", "Right");
        float y = Input.GetAxis("Up", "Down");

        Vector2 input = new Vector2(x, y).Normalized();

        //float velocityWeightX = 1f - Mathf.Exp( -(ACCELERATION))
    }

}
