﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class AOESkill : Skill {

    public AOESkill(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}

}