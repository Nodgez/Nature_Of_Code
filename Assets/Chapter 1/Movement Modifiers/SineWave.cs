using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : MonoBehaviour, IMovementModifier
{
    public float weight = 10f;
    public float rate = 1.0f;
    public Vector3 ModifyMovement(Mover mover)
    {
        if (mover.velocity.magnitude >= mover.movementStats.velocityLimit)
        {
            mover.velocity *= -1f;
        }

        return mover.velocity;
    }
}
