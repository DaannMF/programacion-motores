using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPool : MonoBehaviour {
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private Int16 poolSize = 2;

    private List<GameObject> powerUpPool;
    private static PowerUpPool instance;

    public static PowerUpPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<PowerUpPool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        this.powerUpPool = new List<GameObject>(this.poolSize);
        for (int i = 0; i < this.poolSize; i++) {
            GameObject obstacle = Instantiate(powerUpPrefab);
            obstacle.SetActive(false);
            this.powerUpPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < this.poolSize; i++) {
            if (!this.powerUpPool[i].activeInHierarchy) {
                return powerUpPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (this.powerUpPool is not null) {
            for (int i = 0; i < this.poolSize; i++) {
                this.powerUpPool[i].SetActive(false);
            }
        }
    }
}
