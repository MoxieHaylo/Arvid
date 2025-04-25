using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRadius = 1.5f;
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, interactRadius);
            foreach (Collider2D col in colliderArray)
            {
                if(col.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(transform);
                }
            }
        }
        
    }
}
