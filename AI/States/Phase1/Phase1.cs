using Godot;
using System;

public partial class Phase1 : State {
    [Export] public SweepAttack sweepAttack;
    [Export] public SummonDancers summonDancers;
    [Export] public ShootFeathers shootFeathers;
    [Export] public RadiateFeathers radiateFeathers;

    public override void Enter() {
        SoundManager.Instance.Play(AudioPath.PHASE1);
        Set(sweepAttack, true);
    }

    public override void Do(double delta) {
        if (core.healthComponent.health <= 0f) {
            complete = true;
        }

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
    }
}
