using UnityEngine;

public class ConditionTest : MonoBehaviour
{
    int currentHP = 25;
    bool hasPotion = true;
    string weaponType = "Sword";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Battle Start!!!!!!");

        if(currentHP <= 0)
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î »ç¸Á. °ÔÀÓ ¿À¹ö!!!!");
        }
        else if(currentHP <= 30)
        {
            Debug.Log("HP°¡ ³·¾Æ~~~~ À§ÇèÇØ~~~~~");

            if(hasPotion == true)
            {
                Debug.Log("²Ü²©~ ²Ü²©~");
                currentHP = currentHP + 50;
                Debug.Log("HP°¡ 50¸¸Å­ È¸º¹µÆ´Ù~~~");
            }
            else
            {
                Debug.Log("¹°¾àÀÌ ¾øÀ¸´Ï±î µµ¸ÁÃÄ!!!!!");
            }
        }
        else
        {
            Debug.Log("ÇöÀç »óÅÂ°¡ ±¦ÂúÀ¸´Ï±î °ø°Ý ÁØºñ!!!!");
        }

        switch(weaponType)
        {
            case "Sword":
                {
                    Debug.Log("Ä®·Î ½ä¾ú´Ù!!!");
                }
                break;

            case "Bow":
                {
                    Debug.Log("È­»ìÀ» ½ú´Ù!!!");
                }
                break;

            case "Magic":
                {
                    Debug.Log("±¤¿ª ¸¶¹ý ½ÃÀü!!!");
                }
                break;

            default:
                {
                    Debug.Log("¸ÇÁÖ¸Ô °ø°Ý!!!");
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
