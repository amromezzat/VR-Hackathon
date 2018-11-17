using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExt<T> : UnityEvent<T> { }

public abstract class AbstractField<T> : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    protected T InitialValue;
    public UnityEvent<T> onValueChanged = new UnityEventExt<T>();

    T runtimeValue;
    public virtual T Value
    {
        get
        {
            return runtimeValue;
        }
        set
        {
            if (HasValueChanged(value))
            {
                runtimeValue = value;
                ValueHasChanged();
            }
        }
    }

    protected void ValueHasChanged()
    {
        onValueChanged.Invoke(Value);
    }

    public static implicit operator T(AbstractField<T> abstractField)
    {
        return abstractField.Value;
    }

    /// <summary>
    /// Reference types implementing IEquatable doesn't use boxing/unboxing in equality comparison
    /// https://stackoverflow.com/a/488301
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    protected virtual bool HasValueChanged(T value)
    {
        return !EqualityComparer<T>.Default.Equals(Value, value);
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    { }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        Value = InitialValue;
    }
}
