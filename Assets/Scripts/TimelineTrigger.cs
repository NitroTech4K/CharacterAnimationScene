using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Renderer))]
public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public Color highlightColor = Color.yellow;

    private Color originalColor;
    private Renderer rend;
    private bool isHighlighted = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void Highlight(bool highlight)
    {
        if (highlight && !isHighlighted)
        {
            rend.material.color = highlightColor;
            isHighlighted = true;
        }
        else if (!highlight && isHighlighted)
        {
            rend.material.color = originalColor;
            isHighlighted = false;
        }
    }

    public void PlayTimeline()
    {
        if (timeline != null)
        {
            timeline.Play();
        }
        else
        {
            Debug.LogWarning("No timeline assigned to " + gameObject.name);
        }
    }
}
