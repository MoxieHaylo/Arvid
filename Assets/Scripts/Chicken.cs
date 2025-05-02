using System.Collections;
using UnityEngine;

public class Chicken : MonoBehaviour, IInteractable
{
    public bool inPen = false;
    public bool hasEscaped = false;
    private bool isMoving = false;
    [SerializeField] private float speed;
    private float startTime;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    private Vector3 targetPosition;


    void Start()
    {
        transform.position = startPos.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    public void Interact(Transform interactorTransform)
    {
        if (!inPen)
        {
            SendHome();
        }
    }

    void SendHome()
    {
        targetPosition = endPos.position;
        isMoving = true;
        inPen = true;
        hasEscaped = false; 
    }

    void RunAway()
    {
        targetPosition = startPos.position;
        isMoving = true;
        inPen = false;
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
    public IEnumerator PlotEscape()
    {
        yield return new WaitForSeconds(10);
        RunAway();
    }
}
