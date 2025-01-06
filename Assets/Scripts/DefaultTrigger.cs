using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DefaultTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public Transform targetTransform; 
    public Vector3 newPosition;
    public float transitionDuration = 1f; // Duration of the transition in seconds

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke();
        StartCoroutine(TransformObject());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit.Invoke();
    }

    IEnumerator TransformObject()
    {
        if (targetTransform != null)
        {
            Vector3 initialPosition = targetTransform.position;
            Vector3 targetPosition = targetTransform.parent.TransformPoint(newPosition);

            float elapsedTime = 0f;

            while (elapsedTime < transitionDuration)
            {
                targetTransform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the final position is set
            targetTransform.position = targetPosition;
        }
        else
        {
            Debug.LogError("Target Transform is not assigned.");
        }
    }
}