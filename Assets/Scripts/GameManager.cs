using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Disappearer[] disappearers;
    [SerializeField] private float disappearingTime = 5f;
    void Start()
    {
        //Finds objects in the scene and starts the timer to make them disappear
        disappearers = FindObjectsByType<Disappearer>(FindObjectsSortMode.None);
        StartCoroutine(HideObjectsTimer());
    }
    void Update()
    {
        //Reloads the scene if r is pressed
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }

    //Iterates throughg each disappearing object to set their state
    public void SetObjectState(bool state)
    {
        foreach (Disappearer disappearer in disappearers) disappearer.ObjectActivation(state);
    }

    //Deactivates objects
    private void DeactivateObjects()
    {
        SetObjectState(false);
    }

    //Coroutine to hide bjects
    private IEnumerator HideObjectsTimer()
    {
        yield return new WaitForSeconds(disappearingTime);
        DeactivateObjects();
    }

    //Controls loading a new scene
    public void LoadNewScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        //Redundant code, was going to be used when GM was a singleton but due to how this project is structured GM as a singleton was unnecessary
        //disappearers = FindObjectsByType<Disappearer>(FindObjectsSortMode.None);
        //StartCoroutine(HideObjectsTimer());
    }

    //Loads Next Scene
    public void LoadNextScene()
    {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Reloads a current scene
    public void Reload()
    {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex);
    }


}
