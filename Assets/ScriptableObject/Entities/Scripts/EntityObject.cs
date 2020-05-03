using UnityEngine;

public abstract class EntityObject : ScriptableObject
{
    public int id;
    public new string name;
    [TextArea(10, 10)]
    public string description;

    [Header("Display")]
    public Sprite sprite;
    public GameObject model;

    [Header("Misc info")]
    public int rarity;

}
