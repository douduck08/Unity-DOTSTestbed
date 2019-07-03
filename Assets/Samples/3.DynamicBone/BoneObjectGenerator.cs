﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneObjectGenerator : MonoBehaviour {

    [System.Serializable]
    public struct IntVector2 { public int x, y; }

    public GameObject boneObjectPrefab;
    public IntVector2 objectNumber;
    public Vector2 gridSize;

    Transform[] objects;

    void Awake () {
        QualitySettings.vSyncCount = 0;
        Generate ();
    }

    void Generate () {
        if (boneObjectPrefab == null) {
            return;
        }

        objects = new Transform[objectNumber.x * objectNumber.y];
        var posOrigin = new Vector2 (gridSize.x * objectNumber.x, gridSize.y * objectNumber.y) * -0.5f;
        for (int x = 0; x < objectNumber.x; x++) {
            for (int y = 0; y < objectNumber.y; y++) {
                var go = Instantiate<GameObject> (boneObjectPrefab, this.transform);
                var localPos = posOrigin + new Vector2 (gridSize.x * x, gridSize.y * y);
                go.transform.localPosition = localPos;
                objects[GetIndex (x, y)] = go.transform;
            }
        }
    }

    int GetIndex (int x, int y) {
        return x * objectNumber.y + y;
    }
}