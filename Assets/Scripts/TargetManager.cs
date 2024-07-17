using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize { Small, Medium, Large, }
public class TargetManager : Singleton<TargetManager>
{
    public Transform[] spawnPoints;
    public GameObject[] targetTypes;
    public List<GameObject> targets;
    private ScoreManager _SM;

    private void Start()
    {
        _SM = GetComponent<ScoreManager>();
    }

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
        targets.Add(target);
        _SM.updateTargetUI();
        target.GetComponent<Target>().Setup();
    }

    public int GetTargetCount()
    {
        return targets.Count;
    }

    public void DestroyTarget(GameObject _target)
    {
        if (GetTargetCount() == 0)
            return;
        Destroy(_target);
        targets.Remove(_target);
        _SM.updateTargetUI();
    }

    public void Resize(float _scale, GameObject _target) => transform.localScale = new Vector3(_scale, (_scale * 0.01f), _scale);

    public void ResizeAll(float _scale)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            Resize(_scale, targets[i]);
        }
    }
}
