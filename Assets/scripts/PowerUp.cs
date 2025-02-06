using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        FloatUpAndDown();
    }

    void FloatUpAndDown()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(GameObject player);
}
