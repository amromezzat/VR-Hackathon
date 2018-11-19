using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Explode Action")]
public class ExplodeAction : TimeslotAction
{
    public float radius = 10;
    public float force = 10;
    Vector3 explosionPosition;

    public override void Initialize(GameObject gameObject)
    {
        explosionPosition = gameObject.transform.position +
            new Vector3(Random.Range(0, 2), Random.Range(0, 1), Random.Range(0, 1));
    }

    public override void TakeAction(float time)
    {
        Collider[] hitColliders = Physics.OverlapSphere(explosionPosition, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Rigidbody collidededRB = hitColliders[i].GetComponent<Rigidbody>();

            if(collidededRB)
                collidededRB.AddExplosionForce(force, explosionPosition, radius, 5, ForceMode.Impulse);

            i++;
        }
    }
}
