using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.Utilities.Results
{
    public class SuccessResult: Result
    {
        public SuccessResult(string message) : base(true, message)
        {
            if (message != null)
                Debug.Log(message);
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
