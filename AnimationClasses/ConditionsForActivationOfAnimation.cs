
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
