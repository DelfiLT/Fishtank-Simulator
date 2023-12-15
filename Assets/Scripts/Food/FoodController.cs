using UnityEngine;

public class FoodController : MonoBehaviour
{
    bool inWater;
    Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void OnEnable() => inWater = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) { inWater = true; }
    }

    private void FixedUpdate()
    {
        if (inWater) { rb.velocity = rb.velocity / 1.05f; }
        else { rb.AddForce(transform.up * -9.8f, ForceMode.Force); }
    }
}
