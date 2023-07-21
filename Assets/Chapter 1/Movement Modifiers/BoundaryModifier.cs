using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryModifier : MonoBehaviour, IMovementModifier
{
    private Vector3 screenMax;
    private Vector3 screenMin;

    [SerializeField] float effectDistance = 3f;

    [SerializeField] private float boundaryForce = 20;

    private void Start()
    {
        screenMax = Camera.main.ViewportToWorldPoint(Vector3.one);
        screenMin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        print(string.Format("screen max: {0}, screen min: {1}", screenMax, screenMin));
    }
    public Vector3 ModifyMovement(Mover mover)
    {
        var direction = Vector3.zero;

        if (transform.position.x > screenMax.x - effectDistance)
        {
            var d = screenMax.x - transform.position.x;                 //5 - 3 = 2
            var t = effectDistance - d;                                 //3 - 2 = 1
            var effModifier = Mathf.Clamp01((1f / effectDistance) * t); //1/3 * 1 = 0.3333
            direction += Vector3.left * boundaryForce * effModifier;
            //transform.position = new Vector3(screenMin.x, transform.position.y);
        }
        else if (transform.position.x < screenMin.x + effectDistance)
        {
            var d = screenMin.x - transform.position.x;                 //-5 -(-4) = -1
            var t = effectDistance + d;                                 //3 + (-1) = 2
            var effModifier = Mathf.Clamp01((1f / effectDistance) * t);
            direction += Vector3.right * boundaryForce * effModifier;
            //transform.position = new Vector3(screenMax.x, transform.position.y);
        }
        if (transform.position.y > screenMax.y - effectDistance)
        {
            var d = screenMax.y - transform.position.y;                 //5 - 3 = 2
            var t = effectDistance - d;                                 //3 - 2 = 1
            var effModifier = Mathf.Clamp01((1f / effectDistance) * t);
            direction += Vector3.down * boundaryForce * effModifier;
            //transform.position = new Vector3(transform.position.x, screenMin.y);
        }
        else if (transform.position.y < screenMin.y + effectDistance)
        {
            var d = screenMin.y - transform.position.y;                 //-5 -(-4) = -1
            var t = effectDistance + d;                                 //3 + (-1) = 2
            var effModifier = Mathf.Clamp01((1f / effectDistance) * t);
            direction += Vector3.up * boundaryForce * effModifier;
            //transform.position = new Vector3(transform.position.x, screenMax.y);
        }

        return direction;
    }
}
