using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidResistance : MonoBehaviour, IMovementModifier
{
    [SerializeField] float rho = 1f;
    [SerializeField] float drag = 1f;

    [SerializeField] float surfaceArea;
    public void Initialize(float rho, float drag)
    {
        this.rho = rho;
        this.drag = drag;
    }

    public void Deactivate()
    {
        rho = 0;
        drag = 0;
    }

    public Vector3 ModifyMovement(Mover mover)
    {
        var nrm = mover.velocity.normalized;
        var v_2 = mover.velocity.magnitude * mover.velocity.magnitude;

        return v_2 * surfaceArea * drag * -nrm;
    }
}
