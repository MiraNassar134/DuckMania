using UnityEngine;

public class CrocodileFrightened : CrocodileBehaviour
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer green;
    public SpriteRenderer white;

    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        this.body.enabled = false;
        this.eyes.enabled = false;
        this.green.enabled = true;
        this.white.enabled = false;

        Invoke(nameof(Flash), duration / 2.0f);
    }

    private void Flash()
    {
        if (!this.eaten)
        {
            this.green.enabled = false;
            this.white.enabled = true;
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    private void Eaten()
    {
        this.eaten = true;

        Vector3 position = this.crocodile.home.inside.position;
        position.z = this.crocodile.transform.position.z;
        this.crocodile.transform.position = position;
        this.crocodile.home.Enable(this.duration);

        this.body.enabled = false;
        this.eyes.enabled = true;
        this.green.enabled = false;
        this.white.enabled = false;
    }
    public override void Disable()
    {
        base.Disable();

        this.body.enabled = true;
        this.eyes.enabled = true;
        this.green.enabled = false;
        this.white.enabled = false;
    }

    private void OnEnable()
    {
        green.GetComponent<AnimatedSprite>().Restart();
        this.crocodile.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        if (this.crocodile.frightened != null)
        {
            this.crocodile.movement.speedMultiplier = 1.0f;
            this.eaten = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Duck"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.crocodile.target.position - newPosition).sqrMagnitude; // sqrMagnitude for performance better than magnitude

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            this.crocodile.movement.SetDirection(direction);
        }
    }
}
