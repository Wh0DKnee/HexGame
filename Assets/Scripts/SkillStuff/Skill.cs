using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Skill : IStateHandler{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType TargetType { get; private set; }
    public ChampionStats userStats;

    protected Skill(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) {
        this.SkillCost = skillCost;
        this.TargetType = targetType;
        this.Range = range;
        this.userStats = userStats;
    }

    public void Use(Cell target) {
        SkillCost.ApplyCost(userStats);
        ApplyEffect(target);
    }

    public abstract void ApplyEffect(Cell target);

    public virtual GameState GetNextState(StateChangeParams parameters) {
        return new SelectionState(parameters.gameStateController);
    }

    public abstract List<Cell> GetAffectedArea(Cell target);

    delegate bool FulfillsCriteria(Champion champ);

    // TODO: should we store the affectedType as a member? currently, we are only storing the TargetType (i.e. which
    // type of cell the skill can be used one, but not which type of cell it affects. Only relevant for AOE spells
    public List<Champion> GetAffectedChampions(List<Cell> area, TargetType affectedType) {
        List<Champion> res = new List<Champion>();

        switch (affectedType) {
            case TargetType.enemy:
                if (HexGrid.Instance.GetChamp(userStats.ID).IsEnemyChamp) {
                    res = GetChampionsInArea(area, c => !c.IsEnemyChamp);
                } else {
                    res = GetChampionsInArea(area, c => c.IsEnemyChamp);
                }
                break;
            case TargetType.ally:
                if (HexGrid.Instance.GetChamp(userStats.ID).IsEnemyChamp) {
                    res = GetChampionsInArea(area, c => c.IsEnemyChamp);
                } else {
                    res = GetChampionsInArea(area, c => !c.IsEnemyChamp);
                }
                break;
            case TargetType.self:
                res = new List<Champion>() { HexGrid.Instance.GetChamp(userStats.ID) };
                break;
            case TargetType.all:
                res = GetChampionsInArea(area, x => true);
                break;
            case TargetType.empty:
                res.Clear();
                break;
            default:
                break;
        }

        return res;
    }

    private List<Champion> GetChampionsInArea(List<Cell> area, FulfillsCriteria fulfillsCriteria) {
        List<Champion> res = new List<Champion>();
        foreach (Cell cell in area) {
            Champion champ = cell.champion;
            if(champ != null && fulfillsCriteria(champ)) {
                res.Add(champ);
            }
        }
        return res;
    }
}
