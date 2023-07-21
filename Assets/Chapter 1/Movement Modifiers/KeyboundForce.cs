using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboundForce : MonoBehaviour, IMovementModifier
{
    [SerializeField] private float power;
    public Vector3 ModifyMovement(Mover mover)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return Vector3.up * power;
        }

        return Vector3.zero;
    }
}
