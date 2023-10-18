using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private int collidedCount = 0;  //碰撞次数检测器
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine("DestroyObject");
    }
    public void Launch(Vector2 direction, float force)
    {
        body.AddForce(direction * force);
    }
    IEnumerator DestroyObject()
    {
        //5秒后销毁对象
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PenguinController penguinController = other.GetComponent<PenguinController>();
        if (penguinController != null)
        {
            collidedCount++;
            if (collidedCount == 2)  //第二次碰撞销毁
            {
                //TODO:企鹅受击动画

                Destroy(gameObject);//碰撞到后销毁
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

    }
}
