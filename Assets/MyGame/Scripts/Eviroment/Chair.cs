using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hi im a chair");
    }
}
