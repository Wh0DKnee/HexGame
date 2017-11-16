using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSkillHandler : ISkillHandler {

    public void HandleSkill(Champion champion, Skill skill, HexCoordinates coordinates) {
        NetworkSession.instance.Client.TellServerUseSkill(champion.ID, skill, coordinates);
    }

}
