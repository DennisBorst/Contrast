using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Vector2 forceDirection;
    [SerializeField]
    public int damage = 50;
    [SerializeField]
    private PlayerMovement character;

    /// <summary>
    /// This is hwere the hitbox comes from. 
    /// This also means that the character cant be hitted by this hitbox.
    /// </summary>
    /// 
    private void Start()
    {
        character = GetComponentInParent<PlayerMovement>();
    }

    public PlayerMovement Character
    {
        get { return character; }
        set { character = value; }
    }

    /// <summary>
    /// WHen the character is hit, the health will be reduced by this damage.
    /// </summary>
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
}
