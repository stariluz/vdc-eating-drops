using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public delegate void TransitionEvent();
    public TransitionEvent AfterExitTransitionEvent;
    public TransitionEvent AfterEntryTransitionEvent;
    public TransitionEvent OnExitTransitionEvent;
    public TransitionEvent OnEntryTransitionEvent;

    // public RangeField exitLayers;
    // public RangeField entryLayers;
    public Animator animator;
    public void PlayExitTransition(TransitionTypesEnum transitionType)
    {
        animator.SetTrigger("hide");
    }

    public void OnExitTransition()
    {
        OnExitTransitionEvent?.Invoke();
    }

    public void AfterExitTransition()
    {
        AfterExitTransitionEvent?.Invoke();
    }
    public void PlayEntryTransition(TransitionTypesEnum transitionType)
    {
        animator.SetTrigger("show");
    }

    public void OnEntryTransition()
    {
        OnEntryTransitionEvent?.Invoke();
    }

    public void AfterEntryTransition()
    {
        AfterEntryTransitionEvent?.Invoke();
    }
}
