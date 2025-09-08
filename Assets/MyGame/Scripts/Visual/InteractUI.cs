using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        if (PlayerInteract.Instance.GetCanInteract())
        {
            Show();
        } else
        {
            Hide();
        }
    }

    private void Show()
    {
        container.SetActive(true);
    }
    private void Hide()
    {
        container.SetActive(false);
    }
}
