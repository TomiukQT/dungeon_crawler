using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

namespace Items
{
    [System.Serializable]
    public class LootTable
    {
        public List<ProbabilityValue<ItemData>> DropChances;
    }
}
