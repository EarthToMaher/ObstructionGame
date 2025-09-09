using TMPro;
using UnityEngine;

public class HelpText : MonoBehaviour
{
    //Singleton set up, makes sure the object is persistent between scenes and destroys any duplicates
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
        //Toggle to enable/disable text
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponentInChildren<TextMeshProUGUI>().enabled = !GetComponentInChildren<TextMeshProUGUI>().enabled;
        }
    }
}