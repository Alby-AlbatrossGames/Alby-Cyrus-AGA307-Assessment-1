using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] targetTypes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            spawnRandomTarget();
            Debug.Log("Input: 'I'");
        }
    }

    void spawnRandomTarget()
    {
        int rndSpwn = Random.Range(0, spawnPoints.Length);
        int rndTrgt = Random.Range(0, targetTypes.Length);
        spawnTarget(targetTypes[rndTrgt], spawnPoints[rndSpwn].transform);
        Debug.Log("RandomTarget initiated");
    }

    void spawnTarget(GameObject _target, Transform _spawnPoint)
    {
        GameObject target = Instantiate(_target, _spawnPoint);
        Debug.Log("Target:"+ _target);
        Debug.Log("Spawn:"+_spawnPoint);
    }
}
