using Godot;
using System;

public partial class BlackSwan : Core {
    [Export] public SweepAttack sweepAttack;
    [Export] public SummonDancers summonDancers;
    [Export] public ShootFeathers shootFeathers;
    [Export] public RadiateFeathers radiateFeathers;

    public override void _Ready() {
        base._Ready();
        SetupInstances();
        Set(sweepAttack);
    }

    public override void _Process(double delta) {
        base._Process(delta);

        if (state.complete) {
            if (state == sweepAttack) {
                Set(summonDancers);
            } else if (state == summonDancers) {
                Set(shootFeathers);
            } else if (state == shootFeathers) {
                Set(radiateFeathers);
            } else {
                Set(sweepAttack);
            }
        }

        state.DoBranch(delta);
    }
}
