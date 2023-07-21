using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Mover could use a pass for calculating external forces
//and a 2nd pass for calculating internal forces
public class Mover : MonoBehaviour
{
    public bool bypass = false;
    public SO_MovementStats movementStats;
    public Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 externalForces;

    public float angle;
    public float angularVelocity;
    public float angularAcceleration;

    private List<IMovementModifier> movementModifiers;
    private List<IRotationModifier> rotationModifiers;

    void Start()
    {
        velocity = new Vector3(0, 0);
        movementModifiers = GetComponents<IMovementModifier>().ToList();
        transform.localScale *= movementStats.mass;
    }

    void LateUpdate()
    {
        foreach (var movementModifier in movementModifiers)
            acceleration += movementModifier.ModifyMovement(this) / movementStats.mass;

        // foreach (var rotationModifier in rotationModifiers)
        //     angularAcceleration += rotationModifier.ModifyAngle(this) / movementStats.mass;

        velocity += acceleration * Time.deltaTime;
        velocity = LimitVelocity();

        angularAcceleration = acceleration.x;
        angularVelocity += angularAcceleration * Time.deltaTime * 0.1f;
        if (!bypass)
        {
            transform.position += velocity * Time.deltaTime;

            angle += angularVelocity;
            transform.rotation *= Quaternion.Euler(0, 0, angle);
        }

        angularAcceleration = 0;
        acceleration = Vector3.zero;
    }

    private Vector3 LimitVelocity()
    {
        if (velocity.magnitude < movementStats.velocityLimit)
            return velocity;

        return velocity.normalized * movementStats.velocityLimit;
    }

    public void ApplyExernalForce(Vector3 force)
    {
        acceleration += force;
    }

    public void AddMoidifer(IMovementModifier modifier)
    {
        movementModifiers.Add(modifier);
    }

    public void RemoveModifier(IMovementModifier modifier)
    {
        movementModifiers.Remove(modifier);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity);
    }
}
