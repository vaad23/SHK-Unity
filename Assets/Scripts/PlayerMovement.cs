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
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalMove, verticalMove, 0);

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
