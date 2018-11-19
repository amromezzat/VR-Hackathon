using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Follow Transform Action")]
public class FollowTransformAction : TimeslotAction
{
    public TransformField followedTransform;
    Transform bodyTransform;

    public override void Initialize(GameObject gameObject)
    {
        bodyTransform = gameObject.GetComponent<Transform>();
    }

    public override void TakeAction(float time)
    {
        bodyTransform.localPosition = followedTransform.Value.localPosition;
        bodyTransform.up = followedTransform.Value.up;
    }

}
