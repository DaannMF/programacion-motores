using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Int16 poolSize = 3;

    private List<GameObject> obstaclePool;
    private static ObstaclePool instance;

    public static ObstaclePool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<ObstaclePool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        this.obstaclePool = new List<GameObject>(this.poolSize);
        for (int i = 0; i < this.poolSize; i++) {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            this.obstaclePool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < this.poolSize; i++) {
            if (!this.obstaclePool[i].activeInHierarchy) {
                return this.obstaclePool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (this.obstaclePool is not null) {
            for (int i = 0; i < this.poolSize; i++) {
                this.obstaclePool[i].SetActive(false);
            }
        }
    }
}
