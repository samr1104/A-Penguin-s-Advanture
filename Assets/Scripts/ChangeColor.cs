using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material;
    private Color originColor = new Color(0.75f, 0.6f, 0.26f, 1f);
    private Color greenColor = new Color(0.55f, 0.9f, 0.46f, 1f);

    private bool green;
    public float timeToChangeColor = 0.5f;
    private float timer = 0f;

    public bool active = false;

    void Start()
    {
        green = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            // if(change)
            // {
            //     // Debug.Log("Change = true");
            //     timer += Time.deltaTime;
            //     if(timer >= timeToChangeColor)
            //     {
            //         change = false;
            //         ChangeColorToGreen();
            //         timer = 0f;
            //     }
            // } else {
            //     // Debug.Log("Change = false");
            //     timer += Time.deltaTime;
            //     if(timer >= timeToChangeColor)
            //     {
            //         change = true;
            //         ChangeColorToGreen();
            //         timer = 0f;
            //     }
            // }

            // ChangeColorToGreen();

            timer += Time.deltaTime;
            if(timer >= timeToChangeColor) {
                // change color
                if(green) {
                    ChangeColorBack();
                    green = false;
                } else {
                    ChangeColorToGreen();
                    green = true;
                }
                timer = 0f;
            }

        } else {
            ChangeColorBack();
        }
    }

    public void ChangeColorToGreen()
    {
        // material.SetColor("_EmissionColor", greenColor);
        // material.color = Color.green;
        material.color = greenColor;
    }

    public void ChangeColorBack()
    {
        // material.SetColor("_EmissionColor", originColor);
        // material.color = Color.white;
        material.color = originColor;
    }
}
