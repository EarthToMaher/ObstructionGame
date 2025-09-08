using UnityEngine;

public class ForceDisappear : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            FindFirstObjectByType<GameManager>().SetObjectState(false);
            Destroy(this.gameObject);
        }
    }
}
