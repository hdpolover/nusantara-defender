using Polover.NusantaraDefender.Variables;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ghost", menuName = "Entities/Ghost")]
public class GhostObject : EntityObject
{
    [Header("Battle info")]
    public FloatReference healthPoint;
    public FloatReference movementSpeed;

}
