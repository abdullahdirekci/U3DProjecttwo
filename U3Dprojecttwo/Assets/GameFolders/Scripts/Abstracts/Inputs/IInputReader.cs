using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U3Dprojecttwo.Abstracts.Inputs
{
    public interface IInputReader
    {
        float Horizontal { get; }
        bool isJump { get; }
    }
}
