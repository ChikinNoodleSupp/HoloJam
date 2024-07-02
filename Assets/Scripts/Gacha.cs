using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class Gacha : MonoBehaviour
{

    [Tooltip("Put OSSSHI prefabs here")]
    public GameObject[] tableOSSSHI;
    [Tooltip("Put OSHI prefabs here")]
    public GameObject[] tableOSHI;
    [Tooltip("Put Oshit prefabs here")]
    public GameObject[] tableOshit;
    [Tooltip("Cant be smaller than 1 or bigger than 100")]
    public int dropChanceOSSSHI;
    [Tooltip("Cant be smaller than 1 or bigger than 100")]
    public int dropChanceOSHI;
    [Tooltip("this HAS to be 100, otherwise you have a chance to pull nothing")]
    public int dropChanceOshit;
    public bool itemDropped;
    public Transform spawnPoint;
    public Money money;
    public int gachaCost;
    [Tooltip("Your gacha pulls will be stored here")]
    public List<GameObject> gachaPulls = new List<GameObject>();
    public string gachaItemTag = "GachaItem";
    public Animator animator;
    public GameObject boxAnim;
    public Transform animPosition;
    private bool tenRoll;
    public float xOffset = 100f;
    public float yOffset = 150f;
    public float currentXOffset = 0.0f;
    public List<List<GameObject>> spriteRows = new List<List<GameObject>>(); // List of rows containing sprite copies
    public List<GameObject> currentRow = new List<GameObject>(); // Current row being populated
    public Canvas canvas;
    public float spritesize;
    

    private void Start()
    {
        tenRoll = false;
        
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DeleteSpriteCopies();
        }


    }

    

    public void DeleteSpriteCopies()
    {
        // Destroy all sprite copies in all rows
        foreach (List<GameObject> row in spriteRows)
        {
            foreach (GameObject spriteCopy in row)
            {
               
                Destroy(spriteCopy);
            }
        }
        foreach (GameObject spriteCopy in currentRow)
        {

            Destroy(spriteCopy);
        }

        // Clear the lists
        spriteRows.Clear();
        currentRow.Clear();
    }
   

    private IEnumerator AnimaitonTime()
    {
        GameObject box = Instantiate(boxAnim, animPosition.transform.position, Quaternion.identity);
        boxAnim.GetComponent<Animator>().SetTrigger("Box");
        yield return new WaitForSeconds(1.033f);
       
        Destroy(box);
    }

    public void GachaRoll() //The entirety of the gacha system
    {
        if(money.moneyAmount >= gachaCost)
        {
            
            money.moneyAmount -= gachaCost;
            Debug.Log("you rolled gacha");
            int randomNumber = Random.Range(0, 101); //1-100
            itemDropped = false;
            if(tenRoll == false)
            {
                StartCoroutine(AnimaitonTime());
                spriteRows.Add(currentRow);
            }
            
            

            if (randomNumber <= dropChanceOSSSHI && !itemDropped) //1 out of 100 dropchance
            {
                // put VFX stuff here, so like first animation, and once animation is done, do the stuff below

                int randomIndex = Random.Range(0, tableOSSSHI.Length); //pick a random object in this array of game objects
                GameObject newPrefab = Instantiate(tableOSSSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity); //spawns random object from the list
                SpriteRenderer spriteRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();

                if(spriteRenderer != null)
                {
                    // Create a new UI Image GameObject
                    GameObject spriteCopy = new GameObject("SpriteCopy");
                    spriteCopy.transform.SetParent(canvas.transform);

                    // Add Image component and set the sprite
                    Image copyImage = spriteCopy.AddComponent<Image>();
                    copyImage.sprite = spriteRenderer.sprite;

                    // Set the position and size
                    RectTransform rectTransform = spriteCopy.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(spriteRenderer.sprite.bounds.size.x * spritesize, spriteRenderer.sprite.bounds.size.y * spritesize); // Adjust size as needed

                    // Add the sprite copy to the current row
                    currentRow.Add(spriteCopy);

                    // Check if the current row exceeds the limit
                    if (currentRow.Count == 5)
                    {
                        // Move to a new row
                        spriteRows.Add(currentRow);
                        currentRow = new List<GameObject>();
                        
                    }
                    //else
                    //{
                    //    spriteRows.Add(currentRow);
                    //}

                }

                if (IsDuplicate(newPrefab)) //if its a dupe, buff original
                {
                    GameObject originalItem = GetOriginalItem(newPrefab);
                    scriptCheck(originalItem);
                    Destroy(newPrefab);
                }
                else //else, spawn it
                {
                    gachaPulls.Add(newPrefab);
                }

                itemDropped = true;
            }
            else if (randomNumber <= dropChanceOSHI && randomNumber > 1 && !itemDropped) //30 out of 100 dropchance
            {
                // put VFX stuff here, so like first animation, and once animation is done, do the stuff below

                int randomIndex = Random.Range(0, tableOSHI.Length);
                GameObject newPrefab = Instantiate(tableOSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity);
                SpriteRenderer spriteRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Create a new UI Image GameObject
                    GameObject spriteCopy = new GameObject("SpriteCopy");
                    spriteCopy.transform.SetParent(canvas.transform);

                    // Add Image component and set the sprite
                    Image copyImage = spriteCopy.AddComponent<Image>();
                    copyImage.sprite = spriteRenderer.sprite;

                    // Set the position and size
                    RectTransform rectTransform = spriteCopy.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(spriteRenderer.sprite.bounds.size.x * spritesize, spriteRenderer.sprite.bounds.size.y * spritesize); // Adjust size as needed

                    // Add the sprite copy to the current row
                    currentRow.Add(spriteCopy);

                    // Check if the current row exceeds the limit
                    if (currentRow.Count == 5)
                    {
                        // Move to a new row
                        spriteRows.Add(currentRow);
                        currentRow = new List<GameObject>();
                        
                    }
                    //else
                    //{
                    //    spriteRows.Add(currentRow);
                    //}

                }

                if (IsDuplicate(newPrefab))
                {
                    GameObject originalItem = GetOriginalItem(newPrefab);
                    scriptCheck(originalItem);
                    Destroy(newPrefab);
                }
                else
                {
                    gachaPulls.Add(newPrefab);
                }

                itemDropped = true;
            }
            else if (!itemDropped) //100 out of 100 dropchance
            {
                // put VFX stuff here, so like first animation, and once animation is done, do the stuff below

                int randomIndex = Random.Range(0, tableOshit.Length);
                GameObject newPrefab = Instantiate(tableOshit[randomIndex], spawnPoint.transform.position, Quaternion.identity);
                SpriteRenderer spriteRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Create a new UI Image GameObject
                    GameObject spriteCopy = new GameObject("SpriteCopy");
                    spriteCopy.transform.SetParent(canvas.transform);

                    // Add Image component and set the sprite
                    Image copyImage = spriteCopy.AddComponent<Image>();
                    copyImage.sprite = spriteRenderer.sprite;

                    // Set the position and size
                    RectTransform rectTransform = spriteCopy.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(spriteRenderer.sprite.bounds.size.x * spritesize, spriteRenderer.sprite.bounds.size.y * spritesize); // Adjust size as needed

                    // Add the sprite copy to the current row
                    currentRow.Add(spriteCopy);

                    // Check if the current row exceeds the limit
                    if (currentRow.Count == 5)
                    {
                        // Move to a new row
                        spriteRows.Add(currentRow);
                        currentRow = new List<GameObject>();
                        
                    }
                    //else
                    //{
                    //    spriteRows.Add(currentRow);
                    //}

                }

                if (IsDuplicate(newPrefab))
                {
                    GameObject originalItem = GetOriginalItem(newPrefab);
                    scriptCheck(originalItem);
                    Destroy(newPrefab);

                }
                else
                {
                    gachaPulls.Add(newPrefab);
                }

                itemDropped = true;
            }

            bool IsDuplicate(GameObject prefab) //checks if what you got is a dupe or not
            {
                Debug.Log(prefab.name);

                foreach (GameObject newPrefab in gachaPulls)
                {
                    Debug.Log(newPrefab.name);
                    if (prefab.name == newPrefab.name)
                    {

                        return true;
                    }
                }
                return false;
            }


            
        }

        if(tenRoll == false)
        {
            
            CenterSprites();
        }
            

    }

    

    public void CenterSprites()
{
    float startY = 0;
    for (int rowIndex = 0; rowIndex < spriteRows.Count; rowIndex++)
    {
        List<GameObject> row = spriteRows[rowIndex];
        float totalWidth = (row.Count - 1) * xOffset;
        float startX = -totalWidth / 2;

        for (int i = 0; i < row.Count; i++)
        {
            GameObject spriteCopy = row[i];
            RectTransform rectTransform = spriteCopy.GetComponent<RectTransform>();
            float xPos = row.Count > 1 ? startX + i * xOffset : 0; // Adjust for single sprite case
            rectTransform.anchoredPosition = new Vector3(xPos, startY - rowIndex * yOffset, 0);
        }
    }
}

    public void RepeatGachaRoll()
    {
        if(money.moneyAmount >= gachaCost * 10)
        {
            tenRoll = true;
            StartCoroutine(AnimaitonTime());
            StartCoroutine(RepeatGachaRollCoroutine());
            
        }
        
    }

    private IEnumerator RepeatGachaRollCoroutine()
    {
        for(int i = 0; i < 10; i++)
        {
            GachaRoll();
            
            yield return new WaitForSeconds(0.1f);
            
        }
        tenRoll = false;
        CenterSprites();
    }

    public void scriptCheck(GameObject gameObject) //applies buff to gachaitem if you get dupe
    {
        if (gameObject.GetComponent<OSHI>() != null)
        {
            OSHI oshi = gameObject.GetComponent<OSHI>();
            oshi.DuplicateBuff();

        }
        if (gameObject.GetComponent<OSSSHI>() != null)
        {
            OSSSHI ossshi = gameObject.GetComponent<OSSSHI>();
            ossshi.DuplicateBuff();
        }
        if (gameObject.GetComponent<Oshit>() != null)
        {
            Oshit oshit = gameObject.GetComponent<Oshit>();
            oshit.DuplicateBuff();
        }
    }

    public GameObject GetOriginalItem(GameObject orignalItem) //retains the original of a gachaitem (i think lmao)
    {

        foreach (GameObject newPrefab in gachaPulls)
        {
            if (newPrefab.name == orignalItem.name)
            {
                return newPrefab;
            }
        }
        return null;
    }

    
}
