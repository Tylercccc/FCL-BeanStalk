using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TylerCauthen
{
    public class BeanClass : IComparable<BeanClass>
    {
        public string BeanColor;
        public int BeanOrder;
        public BeanClass(string _newColor, int _newOrder)
        {
            BeanColor = _newColor;
            BeanOrder = _newOrder;
        }
        public int CompareTo(BeanClass other)
        {
            if (other == null)
            {
                return 1;
            }
            return BeanOrder - other.BeanOrder;
        }
    }
}
