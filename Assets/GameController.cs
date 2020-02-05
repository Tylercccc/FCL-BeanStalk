using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] Bean;
    public TextMeshPro Score, Combo;

    float cycleTime = 2;
    int beanNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CycleBeans(0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlaceBean();
        }
    }
    void CycleBeans()
    {

    }
    void PlaceBean()
    {

    }

    IEnumerator CycleBeans(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (beanNum != 0)
            Bean[beanNum - 1].SetActive(false);
        else if (beanNum == 0)
            Bean[3].SetActive(false);
        
        Bean[beanNum].SetActive(true);

        if (beanNum < 3)
            beanNum++;
        else
            beanNum = 0;

        StartCoroutine(CycleBeans(cycleTime));
    }
}
