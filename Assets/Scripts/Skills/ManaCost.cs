using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCost : Cost {

    public ManaCost(int amount) : base(amount) {
    }

    public override void ApplyCost(Champion user) {
        user.Mana -= amount;
    }

    public override bool HasUserEnoughResources(Champion user) {
        return user.Mana >= amount;
    }
}
