using UnityEngine;

public class CrocodileScatter : CrocodileBehaviour
{
    private void OnDisable()
    {
        if (this.crocodile.scatter != null)
        {
            this.crocodile.chase.Enable();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.crocodile.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.crocodile.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.crocodile.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
