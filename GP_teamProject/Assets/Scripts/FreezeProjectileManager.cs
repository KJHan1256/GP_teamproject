using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeProjectileManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)     //충돌 발생 시
    {
        if (collision.CompareTag("Enemy")){

            Movement2D m = collision.gameObject.GetComponent<Movement2D>();
            m.moveDiredtion.x = Mathf.Min(m.moveDiredtion.x + 0.1f, 0.5f);
            EnemyManager e = collision.gameObject.GetComponent<EnemyManager>();
            e.originalColor = Color.blue;

        }
    }
}
