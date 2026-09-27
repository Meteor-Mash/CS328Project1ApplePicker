using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public GameObject restartButtonPrefab;
    public RoundTracker roundTracker;
    public AppleTree appleTree;
    public Transform canvasTransform;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        GameObject roundTrackerGO = GameObject.Find("RoundTracker");
        roundTracker = roundTrackerGO.GetComponent<RoundTracker>();
        GameObject appleTreeGO = GameObject.Find("AppleTree");
        appleTree = appleTreeGO.GetComponent<AppleTree>();
        for (int i = 0; i < numBaskets; ++i)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        if (!(roundTracker.UpdateRound()))
        {
            GameOver();
            return;
        }
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
    }

    public void GameOver()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
        GameObject[] bombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tempGO in bombArray)
        {
            Destroy(tempGO);
        }
        appleTree.pause = true;
        roundTracker.GameOver();
        foreach (GameObject tempBasket in basketList)
        {
            Destroy(tempBasket);
        }
        GameObject restartButtonGO = Instantiate(restartButtonPrefab, canvasTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
