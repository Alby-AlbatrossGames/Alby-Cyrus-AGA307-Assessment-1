using UnityEngine;

public class Target : MonoBehaviour
{
    public int targetHP = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Hit(int dmg)
    {
        targetHP -= dmg;

        Debug.Log("DMG Dealt: " + dmg);
        if (targetHP <= 0)
        {
            DestroyTarget();
            Debug.Log("Target Destroyed");
        }
    }

    void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
