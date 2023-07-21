using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour, IMovementModifier
{
    [SerializeField] private float power = 3f;
    private Vector3 velocity;
    public Vector3 ModifyMovement(Mover mover)
    {
        var noiseX = (Mathf.PerlinNoise(Time.time, 0) - 0.5f) * 2f;
        var noiseY = (Mathf.PerlinNoise(10 + Time.time, 0) - 0.5f) * 2f;
        var x = noiseX;//.Sin(noiseX * 2 * Mathf.PI);// (Mathf.PerlinNoise(Time.time, 0) - 0.5f) * 2f;
        var y = noiseY;//Mathf.Sin(noiseY * 2 * Mathf.PI);// (Mathf.PerlinNoise(10 + Time.time, 0) - 0.5f) * 2f;
        velocity = new Vector3(x, y) * power;
        return velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, velocity);
    }
}
