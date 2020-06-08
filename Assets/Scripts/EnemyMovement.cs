using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;

    private Vector3 _target;

    private void Awake()
    {
        CreateNewTarget();        
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            CreateNewTarget();
    }

    private void CreateNewTarget()
    {
        _target = Random.insideUnitCircle * _maxDistance;
    }
}
