using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Move Action")]
public class MoveAction : TimeslotAction
{
    public Vector3 displacementVector;
    Transform transform;
    Vector3 initialPos;

    bool firstUpdate;

    public override void Initialize(GameObject gameObject)
    {
        transform = gameObject.transform;
    }

    public override void TakeAction(float time)
    {
        if (firstUpdate)
        {
            initialPos = transform.position;
            firstUpdate = false;
        }

        if (duration == 0)
            transform.localPosition = initialPos + displacementVector;
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos + displacementVector,
                (time - startTime) / duration);
    }
}
