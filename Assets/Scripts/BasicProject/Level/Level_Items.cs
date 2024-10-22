using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Items : Level {
    public bool completed;
    public GameObject CameraCutScene;
    public GameObject intermediateCutScene;
    public GameObject intermediateCutSceneObjects;
    public GameObject Enemy;
    public bool rain;
    public bool fire;
    public Transform cameraEndPos;
    public float timeCutScene;
    protected override bool m_Completed {
        set =>completed= value;
        get => completed;
 }
    protected override void _initialize() {

    }
}
