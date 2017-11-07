using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSkillHandler : ISkillHandler {

    public void HandleSkill(Champion champion, Skill skill, Cell target) {
        //NetworkSession.instance.TellServerUseSkill(champion.ID, skill, target);
    }

}
