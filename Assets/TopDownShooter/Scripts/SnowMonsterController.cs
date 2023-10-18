using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMonsterController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed;
    public int devourDamage;
    public float devourRadius;  //雪怪吞噬范围
    public float devourTime;  //吞噬cd
    private float devourTimer;  //吞噬cd计时器
    public float runTime;
    private float runTimer;
    private Vector2 lookDirection;
    private float x;
    private float y;
    private void Update()
    {
        Run();
        Snowstorm();
        Devour();
        Jump();
    }
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        devourTimer = devourTime;
        runTimer = runTime;
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 position = rigidbody2D.position;
        position.x += speed * Time.fixedDeltaTime * x;
        position.y += speed * Time.fixedDeltaTime * y;
        rigidbody2D.MovePosition(position);
    }
    public void Snowstorm()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //TODO:暴风雪
        }
    }
    public void Run()
    {
        runTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && runTimer <= 0)
        {
            speed = speed * 1.5f;
            StartCoroutine("RunStop");
            runTimer = runTime;
        }
    }
    public void Devour()
    {
        devourTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && devourTimer <= 0)
        {
            //TODO:雪怪吞噬,企鹅掉血,变成幽灵
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, devourRadius); // 获取技能范围内的碰撞体;
            foreach (Collider2D collider2D in collider2Ds)
            {
                PenguinController penguinController = collider2D.GetComponent<PenguinController>();
                if (penguinController != null)
                {
                    penguinController.ChangeDevourHealth(-devourDamage);
                }
            }
            devourTimer = devourTime;
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO:雪怪跳跃
        }
    }
    IEnumerator Runstop()
    {
        yield return new WaitForSeconds(5f);
        speed = speed / 1.5f;  //还原速度
    }
}



