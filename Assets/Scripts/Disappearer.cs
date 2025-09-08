using UnityEngine;

public class Disappearer : MonoBehaviour
{
    [SerializeField] private bool disableObject;
    public void ObjectActivation(bool state)
    {
        if (disableObject) gameObject.SetActive(state);
        GetComponent<SpriteRenderer>().enabled = state;
    }
}
