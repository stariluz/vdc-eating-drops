using UnityEngine;

namespace Stariluz.GameLoop
{
    public enum UpdateFunctionsEnum
    {
        RUN,
        PAUSE,
    }
    public abstract class GameElementUpdate : MonoBehaviour
    {

        protected delegate void UpdateFunction();
        protected UpdateFunction ExecuteUpdate;
        protected abstract void RunningUpdate();
        protected abstract void PausedUpdate();
        public virtual void Start(){
            ExecuteUpdate=DisabledUpdate;
        }
        public virtual void Update(){
            ExecuteUpdate();
        }
        protected virtual void DisabledUpdate(){

        }
        
        void SetUpdateFunction(UpdateFunctionsEnum updateFunctionEnum)
        {
            if (updateFunctionEnum == UpdateFunctionsEnum.RUN)
            {
                ExecuteUpdate = RunningUpdate;
            }
            else
            {
                ExecuteUpdate = PausedUpdate;
            }
        }
    }
}