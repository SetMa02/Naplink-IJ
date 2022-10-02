using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private Ore[] _ores;

    private void Awake()
    {
        _ores = transform.GetComponentsInChildren<Ore>();
    }

    public Ore TryGetClosest(Vector2 point)
    {
        Ore[] notEmptyOre = _ores.Where(ore => ore.Empty == false).ToArray();

        if (notEmptyOre.Length == 0)
        {
            return null;
        }

        return notEmptyOre[0];
    }
}
