using UnityEngine;

public class UIMove : MonoBehaviour
{
    public Transform uiTarget;
    public float positionSpeed = 2.0f;
    public float rotationSpeed = 5.0f;
    public float maxDistance = 5.0f;
    public float maxRotationAngle = 45.0f;

    void Update()
    {
        if (uiTarget != null)
        {
            // Move the UI element towards the UiTarget using Slerp for position
            Vector3 targetPosition = Vector3.Slerp(transform.position, uiTarget.position, Time.deltaTime * positionSpeed);
            transform.position = ClampPosition(targetPosition);

            // Slerp directly to the rotation of the UiTarget
            Quaternion targetRotation = uiTarget.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            transform.rotation = ClampRotation(transform.rotation);
        }
        else
        {
            Debug.LogError("UiTarget not assigned to DynamicUIMovement script!");
        }
    }

    Vector3 ClampPosition(Vector3 position)
    {
        // Clamp position within a max distance
        float distance = Vector3.Distance(position, uiTarget.position);
        if (distance > maxDistance)
        {
            position = uiTarget.position + (position - uiTarget.position).normalized * maxDistance;
        }
        return position;
    }

    Quaternion ClampRotation(Quaternion rotation)
    {
        // Clamp rotation within a max angle
        float angle = Quaternion.Angle(uiTarget.rotation, rotation);
        if (angle > maxRotationAngle)
        {
            rotation = Quaternion.Slerp(uiTarget.rotation, rotation, maxRotationAngle / angle);
        }
        return rotation;
    }
}
