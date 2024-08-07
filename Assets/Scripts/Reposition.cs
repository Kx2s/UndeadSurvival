using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    int size = 20;
    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        if (!collider.CompareTag("Area"))
            return;
        Vector2 playerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;


        switch (transform.tag) {
            case "Ground" :
                float diffX = playerPos.x - myPos.x;
                float diffY = playerPos.y - myPos.y;
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;

                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                if (diffX > diffY){
                    transform.Translate(Vector2.right * dirX * size*2);
                }
                else if (diffX < diffY) {
                    transform.Translate(Vector2.up * dirY * size*2);
                }
                break;

            case "Enemy" :
                if (!col.enabled)
                    break;
                
                Vector3 dist = playerPos - myPos;
                Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                transform.Translate(ran + dist * 2);
                break;
        }
    }
}
