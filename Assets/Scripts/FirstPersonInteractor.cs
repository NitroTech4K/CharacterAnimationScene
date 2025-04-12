using UnityEngine;

public class FirstPersonInteractor : MonoBehaviour
{
    public float interactionRange = 3f;
    public LayerMask interactableLayer;
    public KeyCode interactKey = KeyCode.Mouse0; // Left Click

    private Camera cam;
    private TimelineTrigger currentTarget;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        TimelineTrigger newTarget = null;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            newTarget = hit.collider.GetComponent<TimelineTrigger>();
        }

        if (newTarget != currentTarget)
        {
            if (currentTarget != null)
                currentTarget.Highlight(false);

            currentTarget = newTarget;

            if (currentTarget != null)
                currentTarget.Highlight(true);
        }

        if (Input.GetKeyDown(interactKey) && currentTarget != null)
        {
            currentTarget.PlayTimeline();
        }
    }
}
