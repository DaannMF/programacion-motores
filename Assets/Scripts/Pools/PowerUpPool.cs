using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPool : MonoBehaviour {
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private Int16 poolSize = 3;

    private List<GameObject> powerUpPool;
    private static PowerUpPool instance;

    public static PowerUpPool SharedInstance {
        get { return instance; }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(powerUpPrefab);
            obstacle.SetActive(false);
            powerUpPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!powerUpPool[i].activeInHierarchy) {
                return powerUpPool[i];
            }
        }
        return null;
    }
}
