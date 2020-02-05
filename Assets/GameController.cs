using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TylerCauthen
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] Bean;
        public TextMeshPro Score, Combo;
        public Animator currentAnim;

        float cycleTime = 2;
        int beanNum = 0;
        public int currentBean = 0;
        bool pauseCycle = false;
        bool acceptInput = true;
        Coroutine lastRoutine = null;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CycleBeans(0, false));
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && acceptInput == true)
            {
                PlaceBean();
                acceptInput = false;
            }
        }
        public void RestartCycle()
        {
            //StopCoroutine(lastRoutine);
            Bean[currentBean].GetComponent<Animator>().SetBool("Toss", false);
            beanNum = 0;
            pauseCycle = false;
            StartCoroutine(CycleBeans(cycleTime, true));
        }
        void PlaceBean()
        {
            pauseCycle = true;
            StopCoroutine(lastRoutine);
            cycleTime = cycleTime - 0.25f;
            currentAnim = Bean[currentBean].GetComponent<Animator>();
            Bean[currentBean].GetComponent<Animator>().SetBool("Toss", true);
        }

        IEnumerator CycleBeans(float waitTime, bool reset)
        {

            yield return new WaitForSeconds(waitTime);
            if (reset == true)
            {
                Bean[currentBean].SetActive(false);
                acceptInput = true;
            }
            if (pauseCycle == false)
            {
                if (beanNum != 0)
                    Bean[beanNum - 1].SetActive(false);
                else if (beanNum == 0)
                    Bean[3].SetActive(false);

                Bean[beanNum].SetActive(true);
                currentBean = beanNum;

                if (beanNum < 3)
                    beanNum++;
                else
                    beanNum = 0;

                lastRoutine=StartCoroutine(CycleBeans(cycleTime, false));
            }
            else
            {
                Bean[currentBean].SetActive(true);             
            }
        }
    }
}
