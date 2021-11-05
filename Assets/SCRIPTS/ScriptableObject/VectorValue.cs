using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value when game is on")]
    public Vector2 initialValue;
    [Header("default values when game starts")]
    public Vector2 defaultValue;

    public void OnAfterDeserialize() { initialValue = defaultValue; }

    public void OnBeforeSerialize() { }
}
