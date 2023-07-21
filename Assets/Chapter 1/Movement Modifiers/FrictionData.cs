using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionData : MonoBehaviour
{
    [SerializeField] private float friction = 1f;
    public float Friction
    {
        get { return friction; }
    }
}
