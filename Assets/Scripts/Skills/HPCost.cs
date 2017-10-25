using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCost : Cost {

    public HPCost(int amount, Champion champion) : base(amount, champion) {
    }

    public override void ApplyCost() {
        champion.HP -= amount;
    }
}
