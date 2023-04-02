
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health  = 50f;
    public float _walkSpeed;
    [SerializeField]
    private NavMeshAgent _myAgent;

    private Transform _currentPatrolPoint;
    System.Random rand = new System.Random();
    private void Start()
    {
        //_currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild((int)Random.Range(0, SpawnManager.instance.
        //    _enemyPatrolPoints.childCount));
        //Debug.Log("enem name " + this.name + " enem destn pos " + _currentPatrolPoint);
    }

    private void Update()
    {
        /*
        if (Vector3.Distance(transform.position, _currentPatrolPoint.position) < 10f)
        {
            _currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild((int)Random.Range(0, SpawnManager.instance.
            _enemyPatrolPoints.childCount));
            _myAgent.SetDestination(_currentPatrolPoint.position);
            Debug.Log("enem name " + this.name + " enem destn pos " + _currentPatrolPoint);
        }*/
    }
    private void OnEnable()
    {
        //if(_myAgent == null)
        //    _myAgent = gameObject.GetComponent<NavMeshAgent>();
        //_myAgent.acceleration = _walkSpeed;
        //if(_currentPatrolPoint != null)
        //    _myAgent.SetDestination(_currentPatrolPoint.position);
        //else
        //{
        //    _currentPatrolPoint = SpawnManager.instance._enemyPatrolPoints.GetChild(rand.Next(0, SpawnManager.instance.
        //        _enemyPatrolPoints.childCount));
        //    _myAgent.SetDestination(_currentPatrolPoint.position);
        //}
    }
    private void OnDisable()
    {
        
    }

    void MakeEnemyToPatrol()
    {

    }
}
