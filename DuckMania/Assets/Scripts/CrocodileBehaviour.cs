using UnityEngine;

[RequireComponent(typeof(Crocodile))]
public abstract class CrocodileBehaviour : MonoBehaviour
{
    public float duration;
    public Crocodile crocodile { get; private set; }

    private void Awake()
    {
        this.crocodile = GetComponent<Crocodile>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(this.duration);
    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke(nameof(Disable));
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke(nameof(Disable));
    }
}
