using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControlller : MonoBehaviour
{
    public float health = 50f;
    public float _walkSpeed;

    public float lookRadius = 10f;
    public float _attackRadius = 2f;
    public Transform target;
    public NavMeshAgent agent;
    Transform _currentPatrolPoint;
    [SerializeField]
    Animator _myanimator;
    bool readytoattack;
    public AudioClip alien;
    AudioSource _alienSound;

    float _enemyToTargetDist;
    // Start is called before the first frame update
    void Start()
    {
        _alienSound = GameObject.Find("alienSound").GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        _myanimator = GetComponentInChildren<Animator>();
        _currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild((int)Random.Range(0, SpawnManager.instance.
            _enemyPatrolPoints.childCount));
       // Debug.Log("enem name " + this.name + " enem destn pos " + _currentPatrolPoint);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Checking on distance for enemy " +this.name + "Dist as " + Vector3.Distance(target.position, transform.position));
        if (target != null)
        {
            _enemyToTargetDist = Vector3.Distance(target.position, transform.position);
            if (_enemyToTargetDist <= lookRadius)
            {
                FaceTarget();
                agent.speed = 1f;
                agent.SetDestination(target.position);
                _alienSound.clip = alien;
                _alienSound.Play();
            }
            else
            {

                if (Vector3.Distance(transform.position, _currentPatrolPoint.position) < 20f)
                {
                    _currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild((int)Random.Range(0, SpawnManager.instance.
                    _enemyPatrolPoints.childCount));
                    agent.SetDestination(_currentPatrolPoint.position);
                    // Debug.Log("enem name " + this.name + " enem destn pos " + _currentPatrolPoint);
                    readytoattack = false;
                    _myanimator.SetFloat("Blend", 0f);
                }
            }
            if (_enemyToTargetDist <= _attackRadius && !readytoattack)
            {
                readytoattack = true;
                Debug.Log("atacking");
                _myanimator.SetFloat("Blend", 1f);

            }
        }
    }
    private void OnEnable()
    {
        if (agent == null)
            agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = 3f;
        if (_currentPatrolPoint != null)
            agent.SetDestination(_currentPatrolPoint.position);
        else
        {
            _currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild((int)Random.Range(0, SpawnManager.instance.
                _enemyPatrolPoints.childCount));
            agent.SetDestination(_currentPatrolPoint.position);
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            ScoreSystem.instance.Currentscore += 1;
            ScoreSystem.instance.HandleScore();
        }
    }
    void Die()
    {
        SpawnManager.instance._pool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>())
        {
            target = other.GetComponent<FirstPersonController>().transform;
        }
        else
        {
            target = null;
        }
    }
}
