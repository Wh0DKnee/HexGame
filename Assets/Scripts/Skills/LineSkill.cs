﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class LineSkill : Skill {
    public LineSkill(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}
}