using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Int16 poolSize = 2;

    private List<GameObject> obstaclePool;
    private static ObstaclePool instance;

    public static ObstaclePool SharedInstance {
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
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!obstaclePool[i].activeInHierarchy) {
                return obstaclePool[i];
            }
        }
        return null;
    }
}
