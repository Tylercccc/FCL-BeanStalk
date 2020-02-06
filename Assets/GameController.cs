using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Xml.Linq;

namespace TylerCauthen
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] Bean;
        public TextMeshPro Score, Combo;
        public GameObject ComboText;
        public Animator currentAnim;
        public List<BeanClass> beans = new List<BeanClass>();
        public int RedCount, BlueCount, PinkCount, YellowCount;

        float cycleTime = 2;
        int beanNum = 0;
        public int currentBean = 0;
        bool pauseCycle = false;
        bool acceptInput = true;
        int combo = 0;
        public string previousColor = null;

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
                acceptInput = false;
                PlaceBean();
                ComboOnOff();
            }
        }
        public void RestartCycle()
        {
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
            Bean[currentBean].transform.rotation = Quaternion.identity;

            string _color = Bean[currentBean].GetComponent<Bean>().beanColor.ToString();
            beans.Add(new BeanClass(_color,1));
            beans.Sort();
            FindAllBeans();
        }

        IEnumerator CycleBeans(float waitTime, bool reset)
        {
            yield return new WaitForSeconds(waitTime);
            if (reset == true)
            {
                Bean[currentBean].SetActive(false);
             
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
                acceptInput = true;
            }
            else
            {
                Bean[currentBean].SetActive(true);             
            }
        }
        public void FindAllBeans()
        {
            print("------------------------------------");
            List<BeanClass> results = beans.FindAll(
                delegate (BeanClass bn)
                {
                    return bn.BeanColor == "Red" || bn.BeanColor == "Blue" || bn.BeanColor == "Pink" || bn.BeanColor == "Yellow";
                }
                );
            if (results.Count != 0)
            {
                DisplayResults(results, "Red");
            }
            else
            {
                print("\nNo beans found.");
            }
        }
        public void DisplayResults(List<BeanClass> results, string color)
        {
            
            int _red = 0;
            int _blue = 0;
            int _pink = 0;
            int _yellow = 0;

            foreach (BeanClass b in results)
            {
                print(b.BeanColor);
                if (b.BeanColor == "Red")
                {
                    _red++;
                    //CheckCombo();
                }
                if (b.BeanColor == "Blue")
                {
                    _blue++;
                }
                if (b.BeanColor == "Pink")
                {
                    _pink++;
                }
                if (b.BeanColor == "Yellow")
                {
                    _yellow++;
                }
            }
            print("Number of Red: " + _red + ", " + "Blue: " + _blue + ", " + "Pink: " + _pink + ", " + "Yellow: " + _yellow);
        }
        void ComboOnOff()
        {
            if (previousColor != null)
            {
                if (Bean[currentBean].GetComponent<Bean>().beanColor.ToString() == previousColor)
                {
                    combo++;
                }
                else
                    combo = 0;
            }
            previousColor = Bean[currentBean].GetComponent<Bean>().beanColor.ToString();
            if (combo > 0)
            {
                ComboText.SetActive(true);
            }
            else
            {
                ComboText.SetActive(false);
            }
            print("Combo " + combo);
        }
    }
}
