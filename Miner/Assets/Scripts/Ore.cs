using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private float _amount;
    [SerializeField] private float _amountperSecond;
    private bool _empty = false;
    public bool Empty => _empty;

    private void OnValidate()
    {
        _amount = Mathf.Clamp(_amount, 0, float.MaxValue);
        _amountperSecond = Mathf.Clamp(_amountperSecond, 0, float.MaxValue);
    }

    public bool TryMine(float time, out float mined)
    {
        if (time < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        float mightMined = _amountperSecond * time;
        mined = Mathf.Clamp(mightMined, 0, _amount);
        _amount -= mined;

        if (_amount == 0)
        {
            _empty = true;
        }

        return mightMined == mined;
    }
}
