using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Spawn, // Empty state
    Idle, // Wander around
    Patrol, // Patrol area
    Chase, // Chase the player
    Track, // Follow player no matter what
    Die //Stop doing anything after the task is completed
}
