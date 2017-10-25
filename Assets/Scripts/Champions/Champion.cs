using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Champion : MonoBehaviour{

    private int hp;
    public int HP {
        get { return hp; }
        set {
            if (value <= 0) {
                hp = 0;
                if (died != null) died(this);
            } else {
                hp = value;
            }
            if (hpChanged != null) hpChanged(this);
        }
    }
    private int mana;
    public int Mana {
        get { return mana; }
        set {
            mana = value;
            if (manaChanged != null) manaChanged(this);
        }
    }
    public Skill Q { get; set; }
    public Skill W { get; set; }
    public Skill E { get; set; }
    public Skill R { get; set; }
    public Skill SelectedSkill { get; set; }

    public bool IsEnemyChamp { get; set; }
    public bool HasMoved { get; set; } = false;
    public bool HasAttacked { get; set; } = false;
    public bool FinishedTurn {
        get {
            return HasMoved && HasAttacked;
        }
    }

    public abstract HexCoordinates[] GetMoves();
    public abstract void InitializeSkills();

    private void Start() {
        InitializeSkills();
    }

    //TODO: maybe put events in their own class like ChampionEvents and make this class have a member of that type
    public event Action<Champion> selected;
    public event Action<Champion> unselected;
    public event Action<Champion> died;
    public event Action<Champion> hpChanged;
    public event Action<Champion> manaChanged;

    public void Selected() {
        print("selected!");
        if (selected != null) selected(this);
    }

    public void Unselected() {
        print("unselected!");
        if (unselected != null) unselected(this);
    }

    public Cell GetCell() {
        return HexGrid.Instance.ChampionToCell(this);
    }

    public virtual void Move(HexCoordinates coords) {
        HasMoved = true;
        this.gameObject.transform.position = coords.ToWorldPosition();
        HexGrid.Instance.MoveChamp(this, coords);
    }

    public bool TryUseSkill(Cell target) {
        if(SelectedSkill == null) { print("no skill selected"); return false; }

        return SelectedSkill.TryUse(target);
    }
}
