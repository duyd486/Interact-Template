using UnityEngine;

public class CatUIA : MonoBehaviour, IInteractable
{
    private float speed = 2f;
    private int direction = 1;
    private Vector3 myPos;
    private bool isInteract = false;

    private void Start()
    {
        myPos = transform.position;
    }

    private void Update()
    {
        if (isInteract)
        {
            CatAnimation();
        }
    }

    private void CatAnimation()
    {
        transform.Rotate(0, 600 * Time.deltaTime, 0);
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
        if (transform.position.y > myPos.y + 0.5f)
            direction = -1;
        else if (transform.position.y < myPos.y)
            direction = 1;
    }

    public void Interact()
    {
        isInteract = !isInteract;
    }
}
