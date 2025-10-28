using Godot;
using System;

public partial class DeadState : State {
    public override void Enter() {
        CallDeferred(MethodName.ChangeScene);
    }

    private void ChangeScene() {
        GetTree().ChangeSceneToFile("res://Scenes/Lose.tscn");
    }

}
