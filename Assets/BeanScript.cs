using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TylerCauthen
{
    public class BeanScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public enum BeanColor { Red, Blue, Green, Yellow };
        GameController gameController;
        int BeanPoints = 1;

        void Awake()
        {
            gameController = FindObjectOfType<GameController>();
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Reset()
        {
            gameController.RestartCycle();           
        }
    }
}
