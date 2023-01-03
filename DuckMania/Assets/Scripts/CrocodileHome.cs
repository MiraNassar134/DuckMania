using System.Collections;
using UnityEngine;

public class CrocodileHome : CrocodileBehaviour
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if (this.crocodile.home != null)
        {
            if (this.gameObject.activeSelf)
            {
                StartCoroutine(ExitTransition());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.crocodile.movement.SetDirection(-this.crocodile.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        this.crocodile.movement.SetDirection(Vector2.up, true);
        this.crocodile.movement.rigidbody.isKinematic = true;
        this.crocodile.movement.enabled = false;

        Vector3 position = this.transform.position;
        float duration = 0.5f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.inside.position, elapsed / duration);
            newPosition.z = position.z;
            this.crocodile.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.inside.position, this.outside.position, elapsed / duration);
            newPosition.z = position.z;
            this.crocodile.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.crocodile.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.crocodile.movement.rigidbody.isKinematic = false;
        this.crocodile.movement.enabled = true;
    }
}
