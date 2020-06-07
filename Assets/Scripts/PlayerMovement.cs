using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    public void ChangeSpeed(float time, float value)
    {
        StartCoroutine(CoroutineChangeSpeed(time, value));
    }

    private void Move()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
            direction.y += 1;

        if (Input.GetKey(KeyCode.S))
            direction.y -= 1;

        if (Input.GetKey(KeyCode.A))
            direction.x -= 1;

        if (Input.GetKey(KeyCode.D))
            direction.x += 1;

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private IEnumerator CoroutineChangeSpeed(float time, float value)
    {
        if (value > 0 && time > 0)
        {
            _speed *= value;

            yield return new WaitForSeconds(time);
            
            _speed /= value;
        }

        yield return null;
    }
}
