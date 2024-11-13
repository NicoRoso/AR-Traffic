using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMenu : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemsConfig;

    [SerializeField] private GameObject _buttonPrefabe;

    [SerializeField] private Transform _root;

    [SerializeField] private GridObjectCollection _gridObjects;

    [SerializeField] private PlayerMoney _playerMoney;

    [SerializeField] private ScrollingObjectCollection _scroll;

    private void Start()
    {
        UpdateButtons();
    }

    private void UpdateButtons()
    {

        for (int i = 0; i < _root.childCount; i++)
        {
            Destroy(_root.GetChild(i).gameObject);
        }

        foreach (var itemConfigItems in _itemsConfig._objects)
        {
            if (!_playerMoney.CanBuy(itemConfigItems.Price))
            {
                continue;
            }

            var button = Instantiate(_buttonPrefabe, _root);

            if (button.TryGetComponent(out ArButton arbutton)) 
            {
                arbutton.Initialize(itemConfigItems);
            }

            arbutton.OnButtonClicked += () => ProcessBuy(itemConfigItems.Price);
        }

        StartCoroutine(UpdateCollection());
    }

    private void ProcessBuy(int price)
    {
        _playerMoney.ProcessBuy(price);

        UpdateButtons();
    }

    private IEnumerator UpdateCollection()
    {
        yield return new WaitForEndOfFrame();

        _gridObjects.UpdateCollection();
        _scroll.UpdateContent();
    }
}
