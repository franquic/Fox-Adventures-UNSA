using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed = 2.0f;
    private bool facingRight = true;

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        // Cambiar la dirección del NPC
        facingRight = !facingRight;

        // Girar el sprite del NPC en el eje X para cambiar la dirección
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
