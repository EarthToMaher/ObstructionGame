using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            gm.LoadNextScene();
        }
    }
}
