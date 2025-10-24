using Godot;

public partial class Core : Node {
    [Export] public CharacterBody2D body;
    [Export] public AnimatedSprite2D animator;
    [Export] public Label label;
    [Export] public HealthComponent healthComponent;


    [Export] public Node2D player;

    public Vector2 direction { get; protected set; }

    public StateMachine machine;
    public State state => machine.state;

    public void SetupInstances() {
        machine = new();

        State[] allChildStates = NodeUtil.GetChildrenOfType<State>(this);
        foreach (State s in allChildStates) {
            s.SetCore(this);
        }
    }

    public void Set(State s, bool forceReset = false) {
        machine.Set(s, forceReset);
    }
}
