﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillHandler {

    void HandleSkill(Champion champion, Cell target);
}
