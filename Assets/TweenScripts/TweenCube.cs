using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenCube : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _endValue;

    [SerializeField] private Color _endColor;
    [SerializeField] private Transform[] _points;

    private List<Vector3> _pointsPosition = new List<Vector3>();

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().sharedMaterial;
    }

    private void Start()
    {

        // var tween = transform.DOMove(_endValue, _duration);
        // tween.From();
        //
        // _material.DOColor(_endColor, _duration);
      
       // transform.DOPath();
    }
}
