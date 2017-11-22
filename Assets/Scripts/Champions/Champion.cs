using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Champion : MonoBehaviour{

    public int ID { get; set; } //ID, consistent and unique across clients

    //refactor to ChampionStats class
    private int hp;
    public int HP {
        get { return hp; }
        set {
            if (value <= 0) {
                hp = 0;
                if (died != null) died(this);
                Destroy(this.gameObject);
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
    private int maxMovementRange;
    public int MaxMovementRange {
        get { return maxMovementRange; }
        set {
            maxMovementRange = value;
            RemainingMovementRange = value;
        }
    }
    public int RemainingMovementRange { get; set; }

    public Skill Q { get; set; }
    public Skill W { get; set; }
    public Skill E { get; set; }
    public Skill R { get; set; }
    private Skill selectedSkill;
    public Skill SelectedSkill {
        get { return selectedSkill; }
        set {
            if(value != selectedSkill && selectedSkillChanged != null) {
                selectedSkillChanged();
            }
            selectedSkill = value;
        }
    }

    public bool IsEnemyChamp { get; set; }
    public bool HasUsedSkill { get; set; } = false;
    public bool FinishedTurn {
        get {
            return RemainingMovementRange == 0 && HasUsedSkill;
        }
    }

    public abstract void InitializeSkills();
    public abstract void InitializeStats();

    private void Start() {
        InitializeSkills();
        InitializeStats();
    }

    #region events
    //TODO: maybe put events in their own class like ChampionEvents and make this class have a member of that type
    public event Action<Champion> selected;
    public event Action<Champion> unselected;
    public event Action<Champion> died;
    public event Action<Champion> hpChanged;
    public event Action<Champion> manaChanged;
    public event Action selectedSkillChanged;
    public event Action moved;
    public event Action skillUsed;

    public void Selected() {
        if (selected != null) selected(this);
    }

    public void Unselected() {
        if (unselected != null) unselected(this);
    }
    #endregion

    public Cell GetCell() {
        return HexGrid.Instance.ChampionToCell(this);
    }

    public virtual void Move(HexCoordinates coords) {
        HexCoordinates movementVector = coords - GetCell().coordinates;
        RemainingMovementRange -= HexMath.HexLength(movementVector);
        //instead of next line: moveAnimator.move(this, coords);
        this.gameObject.transform.position = coords.ToWorldPosition();
        HexGrid.Instance.MoveChamp(this, coords);

        if(moved != null) { moved(); }
    }

    public void UseSkill(Skill skill, Cell target) {
        skill.Use(this, target);
        HasUsedSkill = true;
        if(skillUsed != null) { skillUsed(); }
    }

    public bool CanUseSkill(Cell target) {
        return SkillValidation.CanChampUseSkill(this, SelectedSkill, target);
    }

    public void SkipMove() {
        RemainingMovementRange = 0;
    }

    public void SkipUseSkill() {
        HasUsedSkill = true;
    }

    public void NewTurnReset() {
        RemainingMovementRange = MaxMovementRange;
        HasUsedSkill = false;
        SelectedSkill = null;
    }
}
