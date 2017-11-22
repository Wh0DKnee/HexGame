using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillHandler : IStateHandler{

    void HandleSkill(Champion champion, Skill skill, HexCoordinates coordinates);
}
