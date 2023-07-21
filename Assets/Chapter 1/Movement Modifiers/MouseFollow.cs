using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour, IMovementModifier
{
    public Vector3 ModifyMovement(Mover mover)
    {
        var mouse_p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = mouse_p - transform.position;

        Debug.DrawRay(transform.position, direction, Color.cyan);
        return new Vector3(direction.x, direction.y);
    }
}
