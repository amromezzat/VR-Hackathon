using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Actions/Play Animation Action")]
public class PlayAnimationAction : TimeslotAction
{
    public string variableName;
    Animator animator;

    public override void Initialize(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public override void TakeAction(float time)
    {
        animator.SetBool(variableName, true);
    }

    public override void Exit()
    {
        animator.ResetTrigger(variableName);
    }
}
