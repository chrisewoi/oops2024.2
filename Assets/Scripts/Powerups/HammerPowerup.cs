using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/hammer")]
public class HammerPowerup : Powerup
{
    public LayerMask mask;
    public float radius = 8f;
    
    public override void UsePowerup(Rigidbody rb)
    {

    
        // Bitshift to the left x times
        //int mask = 1 << LayerMask.NameToLayer("Marble");

        Collider[] neighbours = Physics.OverlapSphere(rb.position, 8f, mask);

        foreach (Collider col in neighbours)
        {
            if(col.transform == rb.transform) continue;
            col.attachedRigidbody.AddExplosionForce(power, rb.position, radius);
        }
        Debug.Log("HAMMER TIME");
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rbtest.position, 8f);
    }*/
}
