using UnityEngine;

public class Crocodile : MonoBehaviour
{
    public Movement movement { get; private set; }
    public CrocodileHome home { get; private set; }
    public CrocodileChase chase { get; private set; }

    public CrocodileFrightened frightened { get; private set; }

    public CrocodileScatter scatter { get; private set; }

    public CrocodileBehaviour initialBehaviour;

    public Transform target; // Duck here

    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.chase = GetComponent<CrocodileChase>();
        this.home = GetComponent<CrocodileHome>();
        this.frightened = GetComponent<CrocodileFrightened>();
        this.scatter = GetComponent<CrocodileScatter>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if (home != this.initialBehaviour)
        {
            home.Disable();
        }

        if (this.initialBehaviour != null)
        {
            this.initialBehaviour.Enable();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Duck"))
        {
            if (this.frightened.enabled)
            {
                FindObjectOfType<GameManager>().CrocodileEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().DuckEaten();
            }
        }
    }
}
