using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyRTS.AnimationClasses
{
    public class ConditionsForActivationOfAnimation
    {
        protected Animation puppet;
        public ConditionsForActivationOfAnimation()
        {

        }
        protected void Attach(Animation puppet)
        {
            this.puppet = puppet;
        }
    }
}
