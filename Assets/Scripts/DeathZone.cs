using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private float reloadDelay = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            StartCoroutine(PlayerDie(player));
        }
    }

    private IEnumerator PlayerDie(PlayerMovement player)
    {
        player.enabled = false;
        GameManager gm = FindFirstObjectByType<GameManager>();
        yield return new WaitForSeconds(reloadDelay);
        gm.Reload();
    }
}
