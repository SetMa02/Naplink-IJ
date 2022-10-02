using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private float _speed;
    [SerializeField] private float _heandsLenght;

    private Ore _current;
    private float _ore;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
        _heandsLenght = Mathf.Clamp(_heandsLenght, 0, float.MaxValue);
    }

    private void OnEnable()
    {
        if (_mine == null)
        {
            enabled = false;
            throw new ArgumentNullException();
        }
    }

    private void Update()
    {
        
    }

    private bool Valid(Ore ore)
    {
        return _current != null && _current.Empty == false;
    }

    private void Update(Ore ore)
    {
        transform.position = Vector3.MoveTowards(transform.position, _current.transform.position, _speed);
        if (Vector3.Distance(transform.position, _current.transform.position) <= _heandsLenght)
        {
            _current.TryMine(Time.deltaTime, out float mined);
            _ore += mined;
        }
    }
}
