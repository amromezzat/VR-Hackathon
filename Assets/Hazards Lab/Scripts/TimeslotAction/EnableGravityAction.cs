using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Enable Gravity Action")]
public class EnableGravityAction : TimeslotAction
{

    Rigidbody rb;

    public override void Initialize(GameObject gameObject)
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override void TakeAction(float time)
    {
        rb.useGravity = true;
    }
}
