using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    /*
    By using [SerializeField] as such:
        [SerializeField] private float speed = 1f
    Allows for the value (speed) to appear in Unity without other classes being able to access it.
    */

    /*[SerializeField] private float speedX = 1f;
    [SerializeField] private float speedY = 1f;
    */
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject[] goal;
    private int goalIndex = 0;
    private GameObject currentGoal;
   

    // Start is called before the first frame update
    void Start()
    {
        currentGoal = goal[0];
    }

    // Update is called once per frame
    void Update()
    {
        #region Directional Controls
        /*To add AWSD direction controls:
        speedX = 0f;
        speedY = 0f;
        if(Input.GetKey(KeyCode.W))
        {
            speedY = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -1f;
        }
        */
        #endregion

        #region Old Code
        /*Vector2 direction = goal.transform.position - transform.position;

        direction.Normalize();

        Vector2 position = transform.position;
        position += (direction * speed * Time.deltaTime);
        transform.position = position;
        */
        #endregion

        /*
         //Use of Vector2 is better for 2D while Vector3 is more useful in 3D.
         Vector2 position = transform.position; //Transform.position causes the position to be updated by coping the new value over it.
         position.x = position.x + (speedX * Time.deltaTime); //Time.deltaTime makes it so that if your framerate is slower it will cause your frames to move more at once.
         //Shortcut: position.x += speed;
         position.y = position.y + (speedY * Time.deltaTime);
         transform.position = position;
        */

        //this gets the distance to the goal
        float distance = Vector2.Distance(transform.position, currentGoal.transform.position);

        if (distance > 0.01f) //are we there yet?
        {
            //finds the direction to the goal (to the circle)
            Vector2 direction = (Vector2)(currentGoal.transform.position - transform.position).normalized;

            Vector2 position = (Vector2)transform.position;
            //moves ai towards the direction set (which was the goal)
            position += (direction * speed * Time.deltaTime);
            transform.position = (Vector3)position;
        }
            else if (goalIndex <= goal.Length)
            {
            //increase goalIndex by 1 (goalIndex + 1)
            goalIndex++;
            currentGoal = goal[goalIndex];
            }
                else //Reset goalIndex back to the baseline once other conditions are no longer fulfilled
                {
                goalIndex = 0;
                }
    }
}
