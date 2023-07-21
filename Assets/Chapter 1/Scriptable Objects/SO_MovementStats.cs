using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement Stats", menuName = "Movement/Stats", order = 1)]
public class SO_MovementStats : ScriptableObject
{
    public float velocityLimit;
    [Range(0.1f, 100)]
    public float mass;

}
