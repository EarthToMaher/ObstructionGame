using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("I triggered");
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("Player Hit Me");
            GameManager gm = FindFirstObjectByType<GameManager>();
            gm.LoadNextScene();
        }
    }
}
