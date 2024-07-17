using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 10;
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            //If the hit object has the Target script, damage the target using that script
            if (collision.gameObject.GetComponent<Target>() != null)
                collision.gameObject.GetComponent<Target>().Hit(damage);
        }
        DestroyProjectile();
    }
}
