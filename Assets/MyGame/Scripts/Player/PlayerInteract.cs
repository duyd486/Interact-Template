using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance { get; private set; }

    [SerializeField] private float maxDistance = 5f;
    private bool canInteract = false;

    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        HandleInteract();
    }

    private void HandleInteract()
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.transform.GetComponentInParent<IInteractable>() != null)
            {
                canInteract = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponentInParent<IInteractable>().Interact();
                }
            }
        } else
        {
            canInteract = false;
        }
    }

    public bool GetCanInteract()
    {
        return canInteract;
    }
}
