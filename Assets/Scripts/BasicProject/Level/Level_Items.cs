using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Items : Level {
    public bool completed;
    protected override bool m_Completed {
        set =>completed= value;
        get => completed;
 }
    protected override void _initialize() {

    }
}
