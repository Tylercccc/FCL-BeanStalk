using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TylerCauthen
{
    public class Bean : MonoBehaviour
    {
        // Start is called before the first frame update
        public enum BeanColor { Red, Blue, Pink, Yellow };
        public BeanColor beanColor;
        public string color;
        public int order;
        GameController gameController;
        int BeanPoints = 1;

        void Awake()
        {
            gameController = FindObjectOfType<GameController>();
        }
        void OnEnable()
        {
            GetComponent<Animator>().enabled = false;
            transform.localPosition = new Vector3(0, 0, 0);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play("Idle", -1, 0.1f);
        }
        public void Reset()
        {
            gameController.RestartCycle();           
        }
    }
}
