using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "StitchMe/PhysicsSettings")]
public class PhysicsSettings : ScriptableObject
{
    public float linearDrag = 3.0f;
    public float angularDrag = 5.0f;
    public float springFrequency = 1.0f;
    public float springDamping = 1.0f;
}
