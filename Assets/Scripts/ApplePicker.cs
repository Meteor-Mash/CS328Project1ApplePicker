using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public RoundTracker roundTracker;
    public AppleTree appleTree;
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
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        if(!(roundTracker.UpdateRound())) {
            appleTree.pause = true;
        }
 /*       if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
 */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
