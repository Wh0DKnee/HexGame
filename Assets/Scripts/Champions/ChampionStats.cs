using System;
using UnityEngine;

[Serializable]
public class ChampionStats {

    public int ID { get; set; } //ID, consistent and uniqeu across clients
    public HexCoordinates Coordinates { get; set; }

    private int hp;
    public int HP {
        get { return hp; }
        set {
            if (value <= 0) {
                hp = 0;
                if (died != null) { died(); }
            } else {
                hp = value;
            }
            if(hpChanged != null) { hpChanged(hp); }
        }
    }
    private int mana;
    public int Mana {
        get { return mana; }
        set {
            mana = value;
            Debug.Log("setting mana");
            Debug.Log("is manaChanged null? " + (manaChanged == null));
            if(manaChanged != null) { manaChanged(mana); }
        }
    }
    private int maxMovementRange;
    public int MaxMovementRange {
        get { return maxMovementRange; }
        set {
            maxMovementRange = value;
            RemainingMovementRange = value; //TODO: this shouldnt be done here.
                                            //currently its done like this to initialize remaining
                                            //movement range to the proper value. This should
                                            //instead be done by NewTurnReset. This is currently
                                            //not called in the first turn though, so we have
                                            //to adjust that.
        }
    }
    public int RemainingMovementRange { get; set; }

    [field: NonSerialized]
    public event Action died;

    [field: NonSerialized]
    public event Action<int> hpChanged;

    [field: NonSerialized]
    public event Action<int> manaChanged;

}
