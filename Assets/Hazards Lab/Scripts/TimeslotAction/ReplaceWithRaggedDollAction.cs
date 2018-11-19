using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Replace With Ragged Doll Action")]
public class ReplaceWithRaggedDollAction : TimeslotAction
{
    public GameObject raggedDoll;
    Transform transform;

    public override void Initialize(GameObject gameObject)
    {
        transform = gameObject.transform;
    }

    public override void TakeAction(float time)
    {
        raggedDoll = Instantiate(raggedDoll, transform.parent);
        raggedDoll.transform.localPosition = transform.localPosition;
        raggedDoll.transform.localRotation = transform.localRotation;
        transform.gameObject.SetActive(false);
    }
}
