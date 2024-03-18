using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventory
{
    public int Collectable { get => _collectable; set => _collectable = value; }

    public int _collectable = 0;

}
