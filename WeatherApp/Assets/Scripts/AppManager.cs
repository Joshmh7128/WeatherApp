using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class AppManager : MonoBehaviour
{
    // main variables
    public string location; // where is the user getting info from?
    public string outputInfo; // output info

    // text objects
    [SerializeField] TextMeshProUGUI mainTemp; // our main tempature

    // app data
    // Start is called before the first frame update
    void Start()
    {
        // start the test function
        StartCoroutine(GetWeather());

        // test function
        IEnumerator GetWeather()
        {
            Debug.Log("Getting weather data for you now.");
            UnityWebRequest request = UnityWebRequest.Get("api.openweathermap.org/data/2.5/weather?q=" + location + "&units=imperial&appid=dacc70f6422ca55a2fd70a8a7e62b657");
            //UnityWebRequest request2 = UnityWebRequest.Get("pro.openweathermap.org/data/2.5/forecast/hourly?q=" + location + "&appid==dacc70f6422ca55a2fd70a8a7e62b657");

            yield return request.SendWebRequest();

            if (request.error == null)
            {
                // outputInfo = request.downloadHandler.text;
                outputInfo = request.downloadHandler.text;
                // weather data json parse
                WeatherData weatherData = WeatherData.CreateFromJSON(outputInfo);
                Debug.Log(weatherData.coord.lon);

                // setting text object
                mainTemp.text = weatherData.main.temp.ToString() + "°";
            }
            else
            {
                Debug.Log(request.error);
            }
        }

        // get our weather data


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
