using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Champion : MonoBehaviour{

    public ChampionStats Stats { get; set; }
    public ChampionUI championUI;

    private void Awake() {
        Stats = new ChampionStats();
        Stats.died += OnDied;
    }

    private void OnDestroy() {
        Stats.died -= OnDied;
    }

    private Skill q;
    public Skill Q { get { return q; } set { q = value; q.SkillEnum = SkillEnum.Q; } }
    private Skill w;
    public Skill W { get { return w; } set { w = value; w.SkillEnum = SkillEnum.W; } }
    private Skill e;
    public Skill E { get { return e; } set { e = value; e.SkillEnum = SkillEnum.E; } }
    private Skill r;
    public Skill R { get { return r; } set { r = value; r.SkillEnum = SkillEnum.R; } }
    private Skill selectedSkill;
    public Skill SelectedSkill {
        get { return selectedSkill; }
        set {
            selectedSkill = value;
        }
    }

    public bool IsEnemyChamp { get; set; }
    public bool HasUsedSkill { get; set; } = false;
    public bool FinishedTurn {
        get {
            return Stats.RemainingMovementRange == 0 && HasUsedSkill;
        }
    }

    public abstract void InitializeSkills();
    public abstract void InitializeStats();

    private void Start() {
        championUI.Subscribe();
        InitializeSkills();
        InitializeStats();
    }

    //TODO: do we need this and the enum? is there a better solution?
    public Skill GetSkill(SkillEnum skillEnum) {
        switch (skillEnum) {
            case SkillEnum.Q:
                return Q;
            case SkillEnum.W:
                return W;
            case SkillEnum.E:
                return E;
            case SkillEnum.R:
                return R;
            default:
                Debug.LogError("you tried to use skill: " + skillEnum.ToString() + "which does not exist");
                return null;
        }
    }

    #region events
    //TODO: maybe put events in their own class like ChampionEvents and make this class have a member of that type
    public event Action<Champion> selected;
    public event Action<Champion> unselected;
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
        return HexGrid.Instance.GetCell(Stats.Coordinates);
    }

    public virtual void Move(HexCoordinates coords) {
        HexCoordinates movementVector = coords - GetCell().coordinates;
        Stats.RemainingMovementRange -= HexMath.HexLength(movementVector);
        MoveAnimator.instance.Move(this, coords);
        HexGrid.Instance.MoveChamp(this, coords);

        if(moved != null) { moved(); }
    }

    public void UseSkill(SkillEnum skillEnum, Cell target) {
        GetSkill(skillEnum).Use(target);
        HasUsedSkill = true;
        if(skillUsed != null) { skillUsed(); }
    }

    public bool CanUseSkill(Cell target) {
        return SkillValidation.CanChampUseSkill(this, SelectedSkill, target);
    }

    public void SkipMove() {
        Stats.RemainingMovementRange = 0;
    }

    public void SkipUseSkill() {
        HasUsedSkill = true;
    }

    public void NewTurnReset() {
        Stats.RemainingMovementRange = Stats.MaxMovementRange;
        HasUsedSkill = false;
        SelectedSkill = null;
    }

    void OnDied() {
        Destroy(this.gameObject);
    }
}

public enum SkillEnum {
    Q,
    W,
    E,
    R
}
