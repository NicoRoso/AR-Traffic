using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class ArButton : MonoBehaviour
{
    public event Action OnButtonClicked;

    [SerializeField] private TextMeshPro _title;

    [SerializeField] private Interactable _interactable;

    private GameObject _prefab;

    [SerializeField]
    private Transform _spawnPosition;


    public void Initialize(Item config)
    {
        _title.text = config.Name;
        _prefab = config.gameObject;

        _interactable.OnClick.AddListener(ProcessClick);
    }

    private void ProcessClick()
    {
        OnButtonClicked?.Invoke();

        Instantiate(_prefab, _spawnPosition.position, Quaternion.identity);
    }
}
