using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour, IExternalModifier
{
    [SerializeField] float G = 2f;

    private float mass;

    private void Start()
    {
        mass = transform.localScale.magnitude / 3f;
    }

    public void CalculateForce(Mover mover)
    {
        var force = this.transform.position - mover.transform.position;
        var distance = Mathf.Max(force.magnitude, 1f);
        force.Normalize();

        float m = (G * mover.movementStats.mass * this.mass) / (distance * distance);
        mover.ApplyExernalForce(force * m);
    }

    private void OnTriggerStay(Collider other)
    {
        var mover = other.GetComponent<Mover>();
        CalculateForce(mover);
    }
}
