using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour
{
    [SerializeField] float rho = 1;
    [SerializeField] float drag = 1;

    private Dictionary<GameObject, FluidResistance> objectsInFluid = new Dictionary<GameObject, FluidResistance>();

    private void OnTriggerEnter(Collider other)
    {
        var fluidR = other.gameObject.GetComponent<FluidResistance>();
        fluidR.Initialize(rho, drag);
        objectsInFluid.Add(other.gameObject, fluidR);
    }

    private void OnTriggerExit(Collider other)
    {
        objectsInFluid[other.gameObject].Deactivate();
        objectsInFluid.Remove(other.gameObject);
    }
}
