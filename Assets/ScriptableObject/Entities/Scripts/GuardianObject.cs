using Polover.NusantaraDefender.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Guardian", menuName = "Entities/Guardian")]
public class GuardianObject : EntityObject
{
    [Header("Battle info")]
    public FloatReference attackSpeed;
    public FloatReference damage;
    public FloatReference range;

}
