using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color noPackageColor = new Color (0.2235294f, 0.4745098f, 0.7333333f, 1f);
    [SerializeField] Color hasPackageColorRed = new Color (1f, 0.0372549f, 0.0294118f, 1f);
    [SerializeField] Color hasPackageColorBlue = new Color (0.0294118f, 1f, 0.0398039f, 1f);
    [SerializeField] Color hasPackageColorBrown = new Color (0.4313726f, 0.3372549f, 0.2784314f, 1f);
    int score = 0;
    string package;
    
    [SerializeField] float destroyDelay = 0.1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void Update() {
        if(score == 10){
            win();
        }
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColorRed;
            Destroy(other.gameObject, destroyDelay);
            package = "red";
        }

        if (other.tag == "Customer" && hasPackage && package == "red")
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            score++;
        }

        if (other.tag == "PackageBlue" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColorBlue;
            Destroy(other.gameObject, destroyDelay);
            package = "blue";
        }

        if (other.tag == "CustomerBlue" && hasPackage && package == "blue")
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            score++;
        }

        if (other.tag == "PackageBrown" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColorBrown;
            Destroy(other.gameObject, destroyDelay);
            package = "brown";
        }

        if (other.tag == "CustomerBrown" && hasPackage && package == "brown")
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            score++;
        }
    }

    void win(){
        //win condition here
        //not applied because I still dont know much about unity
    }
}
