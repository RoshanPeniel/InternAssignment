using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 300;
    public GameObject ball;
    private Rigidbody2D ballBody;
    private CircleCollider2D ballcircle;
    private float screenWidth;
    void Start()
    {
        screenWidth=Screen.width;
        ballBody=ball.GetComponent<Rigidbody2D>();
        ballcircle=ball.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        int i=0;

        while(i<Input.touchCount)
        {
            Touch touch =Input.GetTouch(i);
            Vector2 touchPos= Camera.main.ScreenToWorldPoint(touch.position);

            if(ballcircle == Physics2D.OverlapPoint(touchPos))
            {
                JumpBall();
            }
            else if (touch.position.x > screenWidth/2)
            {
                MoveBall(1.0f);
            }
            else if (touch.position.x < screenWidth/2)
            {
                MoveBall(-1.0f);
            } 
            ++i;
        }
    }
    private void MoveBall(float valueInput)
    {
        ballBody.AddForce(new Vector2(valueInput * moveSpeed * Time.deltaTime,0));
    }
    private void JumpBall()
    {
        ballBody.AddForce(new Vector2(0, 3000 * Time.deltaTime));
    }
}
