using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Effect : MonoBehaviour
{
    [SerializeField] private Type _type;
    [SerializeField] private float _time;
    [SerializeField] private float _value;

    public enum Type
    {
        None = 0,
        Speed = 1
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeEffect(_type, _time, _value);
            gameObject.SetActive(false);
        }
    }
}
