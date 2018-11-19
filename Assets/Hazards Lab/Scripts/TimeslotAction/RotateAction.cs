using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Rotate Action")]
public class RotateAction : TimeslotAction
{
    public Vector3 displacementVector;
    Transform transform;
    Quaternion rotationQuaternion;
    Quaternion initialRotation;

    bool firstUpdate;

    public override void Initialize(GameObject gameObject)
    {
        transform = gameObject.transform;
        rotationQuaternion = Quaternion.Euler(displacementVector.x, displacementVector.y, displacementVector.z);
    }

    public override void TakeAction(float time)
    {
        if (firstUpdate)
        {
            initialRotation = transform.localRotation;
            firstUpdate = false;
        }

        if (duration == 0)
            transform.localRotation = initialRotation * rotationQuaternion;
        else
            transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation * rotationQuaternion,
                (time - startTime) / duration);
    }
}
