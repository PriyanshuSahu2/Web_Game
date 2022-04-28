using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScollToDraw : MonoBehaviour
{

    [SerializeField] GameObject[] images;

    [SerializeField] GameObject space;
    [SerializeField] GameObject middle;
    [SerializeField] GameObject secono;
    [SerializeField] float speed = 2f;
    public bool canStart = false;
    public bool stopNow = false;
    public int numbers;
    private void FixedUpdate()
    {
    if (canStart)
        {

            foreach (GameObject gameObject in images)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
   
                if (Vector2.Distance(gameObject.transform.position, space.transform.position) < 3.6f)
                {

                    gameObject.transform.position = new Vector2(secono.transform.position.x, secono.transform.position.y);

                }
            }
        }
        if (stopNow)
        {
           
            switch (numbers)
            {
                case 0:
                    if(Vector2.Distance(images[0].transform.position, middle.transform.position) <= 0.1)
                    {
                        
                        canStart = false;
                    }
                    break;
                case 1:
                    if (Vector2.Distance(images[1].transform.position, middle.transform.position) <= 0.1)
                    {
                        
                        canStart = false;
                    }
                    break;
                case 2:
                    if (Vector2.Distance(images[2].transform.position, middle.transform.position) <= 0.1)
                    {
                       
                        canStart = false;
                    }
                    break;

            }
        }
    }


}