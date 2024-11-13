using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Microsoft.MixedReality.Toolkit.UI;

public class TrafficLight : MonoBehaviour
{
    [SerializeField]
    public PinchSlider redSlider;

    [SerializeField]
    public PinchSlider yellowSlider;

    [SerializeField]
    public PinchSlider greenSlider;

    [Header("Lights")]
    [SerializeField]
    private GameObject _redLight;
    [SerializeField]
    private GameObject _yellowLight;
    [SerializeField]
    private GameObject _greenLight;

    private enum LightState
    {
        Red,
        Yellow,
        Green
    }

    private LightState currentLightState;

    [SerializeField]
    private bool isTimeStopped = false;

    void Start()
    {
        redSlider.SliderValue = 0.5f;
        yellowSlider.SliderValue = 0.2f;
        greenSlider.SliderValue = 1f;

        currentLightState = (LightState)Random.Range(0, 3);
        StartCoroutine(TrafficLightController());
    }

    IEnumerator TrafficLightController()
    {
        while (true)
        {
            if (!isTimeStopped)
            {
                switch (currentLightState)
                {
                    case LightState.Red:
                        //GetComponent<Renderer>().material.color = Color.red;
                        _redLight.SetActive(true);
                        _yellowLight.SetActive(false);
                        _greenLight.SetActive(false);
                        yield return new WaitForSeconds(redSlider.SliderValue * 10);
                        break;

                    case LightState.Yellow:
                        //GetComponent<Renderer>().material.color = Color.yellow;
                        _redLight.SetActive(false);
                        _yellowLight.SetActive(true);
                        _greenLight.SetActive(false);
                        yield return new WaitForSeconds(yellowSlider.SliderValue * 10);
                        break;

                    case LightState.Green:
                        //GetComponent<Renderer>().material.color = Color.green;
                        _redLight.SetActive(false);
                        _yellowLight.SetActive(false);
                        _greenLight.SetActive(true);
                        yield return new WaitForSeconds(greenSlider.SliderValue * 10);
                        break;
                }
            }
            else
            {
                yield return null;
            }

            SwitchLightState();
        }
    }

    void SwitchLightState()
    {
        switch (currentLightState)
        {
            case LightState.Red:
                currentLightState = LightState.Green;
                break;

            case LightState.Yellow:
                currentLightState = LightState.Red;
                break;

            case LightState.Green:
                currentLightState = LightState.Yellow;
                break;
        }
    }

    public void ToggleTimeStopped()
    {
        isTimeStopped = !isTimeStopped;
    }

    public void SetRedSlider(PinchSlider slider)
    {
        redSlider = slider;
    }

    public void SetYellowSlider(PinchSlider slider)
    {
        yellowSlider = slider;
    }

    public void SetGreenSlider(PinchSlider slider)
    {
        greenSlider = slider;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car") && (currentLightState == LightState.Red || currentLightState == LightState.Yellow))
        {
            other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            other.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

        if (other.gameObject.CompareTag("Car"))
        {
            other.gameObject.GetComponent<CarAI>()._limitOnCar = false;
        }
    }
}
