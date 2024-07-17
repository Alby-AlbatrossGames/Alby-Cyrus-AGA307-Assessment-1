using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int myHP = 1;
    private int mySpeed = 10;
    private int myValue = 50;
    private Vector3 direction = Vector3.zero;
    private GameManager _GM;
    private TargetManager _TM;
    public TargetSize targetSize;

    private void Update()
    {
        transform.Translate(direction * mySpeed * Time.deltaTime);
    }

    public void Setup()
    {
        _GM = FindFirstObjectByType<GameManager>();
        _TM = FindFirstObjectByType<TargetManager>();
        StartCoroutine(Move(true));
        switch (targetSize)
        {
            case TargetSize.Small:
                _TM.Resize(0.5f, this.gameObject);
                myHP = 10;
                mySpeed = 1;
                myValue = 50;
                GetComponent<Renderer>().material.color = Color.green;
                return;
            case TargetSize.Medium:
                _TM.Resize(1f, this.gameObject);
                myHP = 20;
                mySpeed = 2;
                myValue = 100;
                GetComponent<Renderer>().material.color = Color.yellow;
                return;
            case TargetSize.Large:
                _TM.Resize(1.5f, this.gameObject);
                myHP = 30;
                mySpeed = 3;
                myValue = 150;
                GetComponent<Renderer>().material.color = Color.red;
                return;
        }

    }
    public void Hit(int dmg)
    {
        myHP -= dmg;
        if (myHP <= 0)
        {
            _GM.addScore(myValue);
            _GM.addTime(5);
            _TM.DestroyTarget(this.gameObject);
        }
    }

    private IEnumerator Move(bool _moveLeft)
    {
        direction = _moveLeft ? Vector3.left : Vector3.right;
        yield return new WaitForSeconds(3);
        StartCoroutine(Move(!_moveLeft));
    }
}
