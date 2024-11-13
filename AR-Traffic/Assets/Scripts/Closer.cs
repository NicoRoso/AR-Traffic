using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Closer : MonoBehaviour
{
    private void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<MixedRealityLineRenderer>()) transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}