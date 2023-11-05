using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private PlayerController _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        var curPos = transform.position;
        var forceVector = _player.transform.position - curPos;
        forceVector.y = curPos.y;
        _rigidbody.AddForce(forceVector * speed, ForceMode.Impulse);
    }
}
