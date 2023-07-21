using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour, IMovementModifier
{
    public float gravityModifier = 1f;
    public Vector3 ModifyMovement(Mover mover)
    {
        return new Vector3(0, -9.8f * gravityModifier * mover.movementStats.mass, 0);
    }
}
