using TMPro;
using UnityEngine;

public class HelpText : MonoBehaviour
{
    public static HelpText Instance { get; private set; }

    private void Awake()
    {
        // Check if there's already an instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist between scenes
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponentInChildren<TextMeshProUGUI>().enabled = !GetComponentInChildren<TextMeshProUGUI>().enabled;
        }
    }
}