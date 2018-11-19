using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeslotAction : ScriptableObject {
    public float startTime;
    public float duration;
    public abstract void Initialize(GameObject gameObject);
    public abstract void TakeAction(float time);
    public virtual void Exit() { }
}
