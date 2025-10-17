using Godot;
using System;

public abstract partial class State : Node {
    public bool complete { get; protected set; }

    private double startTime;
    protected double time => Time.GetUnixTimeFromSystem() - startTime;

    // Blackboard Components
    protected Core core;
    protected CharacterBody2D body => core.body;
    protected AnimatedSprite2D animator => core.animator;

    // Hierarchical Components
    public StateMachine machine;
    public State parent;
    public State state => machine?.state;

    public virtual void Enter() { }
    public virtual void Do(double delta) { }
    public virtual void PhysicsDo(double delta) { }
    public virtual void Exit() { }

    public void DoBranch(double delta) {
        Do(delta);
        state?.DoBranch(delta);
    }

    public void PhysicsDoBranch(double delta) {
        PhysicsDo(delta);
        state?.PhysicsDoBranch(delta);
    }

    public void Set(State newState, bool forceReset = false) {
        machine.Set(newState, forceReset);
    }

    public void SetCore(Core c) {
        core = c;
    }

    public void Initialize() {
        complete = false;
        startTime = Time.GetUnixTimeFromSystem();
    }
}
