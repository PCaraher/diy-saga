using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossScript : MonoBehaviour {

    //Values used in changing the transform of the gameObject
    private float useSpeed;
    public float directionSpeed = 1.0f;
    public bool useXaxis = true;
    float origX;
    float origY;
    Vector3 orig;
    public float distance = 2.0f;

    public static bool fail = false;
    public Sprite[] mySprite = new Sprite[7];
 

    

    // Use this for initialization
    void Start()
    {
        origX = transform.position.x;
        origY = transform.position.y;
        useSpeed = -directionSpeed;

        //If the player has bought and equipped a skin then get the index of the skin and load it
        //from the sprite array
        if (PlayerPrefs.GetInt("Skin Index") > 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = mySprite[PlayerPrefs.GetInt("Skin Index")];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (useXaxis)
        {
            if (origX - transform.position.x > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origX - transform.position.x < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(useSpeed * Time.deltaTime, 0, 0);


            //Detect if the cross is within a certain x range and if the cross is tapped
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == gameObject.GetComponent<Collider>() && transform.position.x > (origX - 0.4f) && transform.position.x < (origX + 0.4f))
                    {
                        ScoreScript.scoreValue += 1;
                        Destroy(transform.parent.gameObject);
                    }
                }
            }
        }
        else
        {
            if (origY - transform.position.y > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origY - transform.position.y < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(0, useSpeed * Time.deltaTime, 0);

            //Detect if the cross is within a certain y range and if the cross is tapped
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == gameObject.GetComponent<Collider>() && transform.position.y > (origY - 0.4f) && transform.position.y < (origY + 0.4f))
                    {
                        ScoreScript.scoreValue += 1;
                        Destroy(transform.parent.gameObject);
                    }
                }
            }
        }
    }  
}
