using UnityEngine;

public class CrocodileChase : CrocodileBehaviour
{
    private void OnDisable()
    {
        if (this.crocodile.chase != null)
        {
            this.crocodile.scatter.Enable();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.crocodile.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.crocodile.target.position - newPosition).sqrMagnitude; // sqrMagnitude for performance better than magnitude

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            this.crocodile.movement.SetDirection(direction);
        }
    }
}
