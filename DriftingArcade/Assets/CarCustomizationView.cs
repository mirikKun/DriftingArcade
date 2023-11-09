using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Data;
using UnityEngine;

public class CarCustomizationView : MonoBehaviour
{

    [SerializeField] private ColorChooseButton[] _colorChooseButtons;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Transform _accessories;

    [SerializeField]private Color _currentColor ;
    private Color _temporaryColor;
    [SerializeField]private AccessoriesType _currentAccessoriesType ;
    private AccessoriesType _temporaryAccessoriesType;

    private void Start()
    {
        ColorButtonsInit();
    }

    private void ChangeColor(Color color)
    {
        _temporaryColor = color;
        foreach (Renderer renderer in _renderers)
        {
            renderer.material.SetColor("_Color", color);
        }
    }

    public void ChangeAccessories(AccessoriesType type)
    {
        _temporaryAccessoriesType = type;

    }

    private void ColorButtonsInit()
    {
        foreach (var colorChooseButton in _colorChooseButtons)
        {
            colorChooseButton.Button.onClick.AddListener(() => { ChangeColor(colorChooseButton.Color); });
        }
    }

    public void SaveChanges()
    {
        
    }
}
