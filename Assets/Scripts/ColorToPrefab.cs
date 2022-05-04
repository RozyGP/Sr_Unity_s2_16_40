using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // umo¿liwia edytowanie obiektu typu ColorToPrefab
                      // z poziomu Inspektora w Unity
public class ColorToPrefab
{
    public Color color;
    public GameObject prefab;
}
