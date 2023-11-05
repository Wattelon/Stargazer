using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flyForce;
    [SerializeField] private float flapForce;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float flapCooldown;
    
    private Rigidbody _rigidbody;
    private float _flapTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        TorqueCalculation();
        SpeedChange();
        WingFlapping();
    }

    private void TorqueCalculation()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        _rigidbody.AddTorque(transform.up * (horizontalInput * turnSpeed * -1));
        _rigidbody.AddTorque(transform.right * (verticalInput * turnSpeed));
    }
    
    private void SpeedChange()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            flyForce++;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            flyForce--;
        }
        flyForce = Mathf.Clamp(flyForce, 0, 1000);
        _rigidbody.AddForce(transform.up * flyForce);
    }

    private void WingFlapping()
    {
        _flapTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _flapTime > flapCooldown && flyForce > 100f)
        {
            _rigidbody.AddForce(transform.up * flapForce, ForceMode.Impulse);
            _flapTime = 0;
        }
    }
}
