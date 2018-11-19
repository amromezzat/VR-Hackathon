using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Enable Action")]
public class EnableAction : TimeslotAction
{
    public bool active;
    GameObject gameObject;

    public override void Initialize(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void TakeAction(float time)
    {
        gameObject.SetActive(active);
    }
}
