using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class CustomCarData 
    {
        public ColorType CarColor;
        public AccessoriesType AccessoriesType;


        public List<ColorType> AvailableColors;
        public List<AccessoriesType> AvailableAccessories;
    }
}
