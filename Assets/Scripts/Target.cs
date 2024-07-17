using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int myHP = 1;
    private int mySpeed = 10;
    private Vector3 direction = Vector3.zero;
    public TargetSize targetSize;

    private void Update()
    {
        transform.Translate(direction * mySpeed * Time.deltaTime);
    }

    public void Setup()
    {
        StartCoroutine(Move(true));
        
        switch (targetSize)
        {
            case TargetSize.Small:
                Resize(0.5f);
                myHP = 10;
                mySpeed = 1;
                GetComponent<Renderer>().material.color = Color.green;
                return;
            case TargetSize.Medium:
                Resize(1f);
                myHP = 2;
                mySpeed = 2;
                GetComponent<Renderer>().material.color = Color.yellow;
                return;
            case TargetSize.Large:
                Resize(1.5f);
                myHP = 3;
                mySpeed = 3;
                GetComponent<Renderer>().material.color = Color.red;
                return;
        }

    }
    public void Hit(int dmg)
    {
        myHP -= dmg;
        if (myHP <= 0)
            DestroyTarget();
    }
    void DestroyTarget() => Destroy(gameObject);
    void Resize(float _scale) => transform.localScale = new Vector3(_scale, (_scale * 0.01f), _scale);

    private IEnumerator Move(bool _moveLeft)
    {
        Debug.Log("Coroutine Started Successfully");
        direction = _moveLeft ? Vector3.left : Vector3.right;
        Debug.Log("isMoving");
        yield return new WaitForSeconds(3);
        Debug.Log("ChangeDirection");
        StartCoroutine(Move(!_moveLeft));
    }
}
