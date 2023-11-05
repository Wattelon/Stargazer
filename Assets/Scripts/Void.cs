using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] private float pullForce;

    private void OnTriggerStay(Collider other)
    {
        var forceVector = transform.position - other.transform.position;
        other.GetComponent<Rigidbody>().AddForce(forceVector * pullForce / forceVector.sqrMagnitude);
    }
}
