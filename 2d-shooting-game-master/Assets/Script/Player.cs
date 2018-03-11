using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
        spaceship = GetComponent<Spaceship>();

        while (true)
        {
            spaceship.Shot(transform);
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
	}


	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        spaceship.Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if(layerName == "Bullet(Enemy)")
        {
            Destroy(collision.gameObject);
        }
        if(layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            spaceship.Explosion();
            Destroy(gameObject);
        }
    }
}
