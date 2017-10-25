using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCost : Cost {

    public ManaCost(int amount, Champion champion) : base(amount, champion) {
    }

    public override void ApplyCost() {
        champion.Mana -= amount;
    }
}
