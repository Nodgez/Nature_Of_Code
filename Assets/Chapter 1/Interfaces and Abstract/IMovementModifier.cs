using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementModifier
{
    Vector3 ModifyMovement(Mover mover);
}

public interface IExternalModifier
{
    void CalculateForce(Mover mover);
}

public interface IRotationModifier
{
    float ModifyAngle(Mover mover);
}
