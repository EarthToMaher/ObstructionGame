using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Disappearer[] disappearers;
    [SerializeField] private float disappearingTime = 5f;
    void Start()
    {
        disappearers = FindObjectsByType<Disappearer>(FindObjectsSortMode.None);
        StartCoroutine(HideObjectsTimer());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }
    public void SetObjectState(bool state)
    {
        foreach (Disappearer disappearer in disappearers) disappearer.ObjectActivation(state);
    }

    private void DeactivateObjects()
    {
        SetObjectState(false);
    }

    private IEnumerator HideObjectsTimer()
    {
        yield return new WaitForSeconds(disappearingTime);
        DeactivateObjects();
    }


    public void LoadNewScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        //disappearers = FindObjectsByType<Disappearer>(FindObjectsSortMode.None);
        //StartCoroutine(HideObjectsTimer());
    }
    public void LoadNextScene()
    {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Reload()
    {
        LoadNewScene(SceneManager.GetActiveScene().buildIndex);
    }


}
