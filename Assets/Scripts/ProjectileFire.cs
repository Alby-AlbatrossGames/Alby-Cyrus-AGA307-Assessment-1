using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public GameObject projPrefab;
    public float projSpeed = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            FireProjectile();
    }

    private void FireProjectile()
    {
        //create instantiated object
        GameObject projInstance;
        projInstance = Instantiate(projPrefab, transform.position, transform.rotation);
        //add force to instantiated object
        projInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projSpeed);
    }
}
