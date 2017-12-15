using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillHandler : IStateHandler{

    void HandleSkill(Skill skill, HexCoordinates coordinates);
}
