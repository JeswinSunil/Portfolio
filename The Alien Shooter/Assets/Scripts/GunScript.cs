
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public AudioClip gunshot;
    [SerializeField]
    AudioSource _FireSound;

    private void Start()
    {
        _FireSound = GameObject.Find("FireSound").GetComponent<AudioSource>();
        fpscam = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = fpscam.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        // debug Ray
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
        if (Input.GetMouseButtonDown(0))
        {

            shoot();
        }

    }

    void shoot()
    {
        RaycastHit hit;
        // actual Ray
        Ray ray = fpscam.ViewportPointToRay(new Vector3(.5f,.5f,0));

        // debug Ray
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
        _FireSound.clip = gunshot;
        _FireSound.Play();
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("hit Obj " + hit.collider.gameObject.name);
            EnemyControlller target = hit.transform.GetComponent<EnemyControlller>();
            if (target != null)
            {
                target.TakeDamage(damage);
                target.agent.SetDestination(this.gameObject.transform.parent.parent.transform.position);
                target.agent.speed = 6f;
            }
            // our Ray intersected a collider
        }
    }

}
