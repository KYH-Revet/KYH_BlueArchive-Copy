using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharaterScene : MonoBehaviour
{
    [Header("Test Character")]
    public Transform testCharacterParent;
    TestAnimCharacter testTarget;
    TestAnimCharacter.State state = TestAnimCharacter.State.IDLE;

    [Header("UI")]
    public Text stateText;
    [Space]
    public Slider timeSlider;
    [Range(0f, 1f)] public float timeScale = 1f;

    void Start()
    {
        if(testCharacterParent != null)
        {
            testTarget = testCharacterParent.GetChild(0).GetComponent<TestAnimCharacter>();

            if(testTarget != null)
            {
                state = testTarget.state;
                stateText.text = "State : " + state;
            }
        }
    }

    void Update()
    {
        if (Time.timeScale != timeScale)
        {
            timeSlider.value = timeScale;
            Time.timeScale = timeScale;
        }
        
        if(testTarget != null && testTarget.state != state)
        {
            state = testTarget.state;
            stateText.text = "State : " + state;
        }
    }

    //Slider Function
    public void TimeSlide()
    {
        timeScale = timeSlider.value;
        Time.timeScale = timeScale;
    }
}
