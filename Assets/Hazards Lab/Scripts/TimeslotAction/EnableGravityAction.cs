using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Enable Gravity Action")]
public class EnableGravityAction : TimeslotAction
{

    Rigidbody rb;
    MeshCollider mc;

    public override void Initialize(GameObject gameObject)
    {
        rb = gameObject.GetComponent<Rigidbody>();
        mc = gameObject.GetComponent<MeshCollider>();
    }

    public override void TakeAction(float time)
    {
        mc.isTrigger = false;
        rb.useGravity = true;
    }
}
