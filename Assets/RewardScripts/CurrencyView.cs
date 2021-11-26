using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    private const string WoodKey = nameof(WoodKey); 
    private const string DiamondKey = nameof(DiamondKey);
    public static CurrencyView Instance { get; private set; }
    
    [SerializeField] private TMP_Text _currentCountWood; 
    [SerializeField] private TMP_Text _currentCountDiamond;

    private int Wood
    {
        get => PlayerPrefs.GetInt(WoodKey, 0);
        set => PlayerPrefs.SetInt(WoodKey, value);
    }
    
    private int Diamond
    {
        get => PlayerPrefs.GetInt(DiamondKey, 0);
        set => PlayerPrefs.SetInt(DiamondKey, value);
    }

    private void Start()
    {
        RefreshText();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void AddWood(int value)
    {
        Wood += value;
    }
    public void AddDiamonds(int value)
    {
        Diamond += value;
    }

    private void RefreshText()
    {
        _currentCountWood.text = Wood.ToString();
        _currentCountDiamond.text = Diamond.ToString();
    }
}
