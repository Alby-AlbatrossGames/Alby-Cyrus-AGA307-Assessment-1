using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize { Small, Medium, Large, }
public class TargetManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] targetTypes;
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            spawnRandomTarget();
        }
    }

    void spawnRandomTarget()
    {

        int rndSpwn = Random.Range(0, spawnPoints.Length);
        int rndTrgt = Random.Range(0, targetTypes.Length);
        spawnTarget(targetTypes[rndTrgt], spawnPoints[rndSpwn].transform);
    }

    void spawnTarget(GameObject _target, Transform _spawnPoint)
    {
        GameObject target = Instantiate(_target, _spawnPoint);
        target.GetComponent<Target>().Setup();
    }
}
