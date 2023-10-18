using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2D;
    public int health;  //承受雪球次数
    public int devourHealth;  //承受吞噬次数
    private int currentDevourHealth;
    public int currentHealth;
    public GameObject monster;
    public GameObject ghost;
    public GameObject bulletPrefab;
    private Vector2 lookDirection;
    private float x;
    private float y;
    public float shootTime;
    private float shootTimer;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = health;
        shootTimer = shootTime;
    }
    private void Update()
    {
        LookDirection();
        Launch();
    }
    private void FixedUpdate()
    {
        //移动方法
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 position = rigidbody2D.position;
        position.x += speed * Time.fixedDeltaTime * x;
        position.y += speed * Time.fixedDeltaTime * y;
        rigidbody2D.MovePosition(position);
    }
    public void ChangeHealth(int num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= 0)
        {
            Vector2 position = rigidbody2D.position;
            Destroy(gameObject);
            Instantiate(monster, position, Quaternion.identity);
        }
    }
    public void ChangeDevourHealth(int num)
    {
        currentDevourHealth = Mathf.Clamp(currentDevourHealth + num, 0, health);
        if (currentDevourHealth <= 0)
        {
            Vector2 position = rigidbody2D.position;
            Destroy(gameObject);
            Instantiate(ghost, position, Quaternion.identity);
        }
    }
    public void Launch()
    {
        shootTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shootTimer <= 0)
        {
            //创建子弹
            GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //Bullet bullet = bulletObject.GetComponent<Bullet>();
            //bullet.Launch(lookDirection, 300);
            shootTimer = shootTime;
        }
    }
    public void LookDirection()
    {
        Vector2 move = new Vector2(x, y);
        //校准面朝方向
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();  //单位化长度,规定方向
        }
    }
}
