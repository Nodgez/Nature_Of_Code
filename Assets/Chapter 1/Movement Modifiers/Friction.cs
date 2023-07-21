using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour, IMovementModifier
{
    const float AMBIENT_FRICTION = 0.2f;
    [SerializeField] private float mu = 0.5f;
    [SerializeField] private float normal = 1;

    public Vector3 ModifyMovement(Mover mover)
    {
        var friction = -mover.velocity;
        friction.Normalize();
        friction *= (mu * normal);

        return friction;
    }

    private void OnTriggerEnter(Collider other)
    {
        var data = other.GetComponent<FrictionData>();
        mu = AMBIENT_FRICTION + data.Friction;
    }

    private void OnTriggerExit(Collider other)
    {
        mu = AMBIENT_FRICTION;
    }
}
