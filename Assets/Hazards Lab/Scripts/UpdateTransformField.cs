using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTransformField : MonoBehaviour
{
    public TransformField transformField;
    // Update is called once per frame
    void Update()
    {
        transformField.Value = transform;
    }
}
