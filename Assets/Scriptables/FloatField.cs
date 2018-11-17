using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Fields/Float Field")]
public class FloatField : AbstractField<float>
{
    protected override bool HasValueChanged(float value)
    {
        return !this.Value.IsEqual(value);
    }
}
