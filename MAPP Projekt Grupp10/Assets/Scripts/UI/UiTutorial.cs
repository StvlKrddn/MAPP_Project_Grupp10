using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTutorial : MonoBehaviour
{

    public Animator tutorialAnimator;

    public GameObject jumpTutorial;
    public GameObject throwTutorial;

    [SerializeField] private float animationTime = 3f;

    private void Start()
    {
    }

    private void Update()
    {
    }

    IEnumerator TutorialAnimation()
    {
        jumpTutorial.SetActive(true);
        tutorialAnimator.SetTrigger("JumpTutorial");
        yield return new WaitForSeconds(animationTime);
        tutorialAnimator.SetTrigger("ThrowTutorial");
        yield return new WaitForSeconds(animationTime);
        tutorialAnimator.SetTrigger("QuitTutorial");

    }

    public void StartTutorial()
    {
        StartCoroutine("TutorialAnimation");
    }

    public void EnableThrowTutorial()
    {
        throwTutorial.SetActive(true);
    }

}
