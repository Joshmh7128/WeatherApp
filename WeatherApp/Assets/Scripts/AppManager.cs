using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class AppManager : MonoBehaviour
{
    // main variables
    public string location; // where is the user getting info from?
    public string outputInfo; // output info

    // app data
    int maintemp; // our main tempature
    int mintemp;
    int maxtemp;
    int humid;
    int precip;
    int wind;


    // Start is called before the first frame update
    void Start()
    {
        // start the test function

        // GetWeather();

        StartCoroutine(GetWeather());

        IEnumerator GetWeather()
        {
            Debug.Log("Getting weather data for you now.");
            UnityWebRequest request = UnityWebRequest.Get("api.openweathermap.org/data/2.5/weather?q=" + location + "&appid=dacc70f6422ca55a2fd70a8a7e62b657");
            //UnityWebRequest request2 = UnityWebRequest.Get("pro.openweathermap.org/data/2.5/forecast/hourly?q=" + location + "&appid==dacc70f6422ca55a2fd70a8a7e62b657");

            yield return request.SendWebRequest();
            //yield return request2.SendWebRequest();

            if (request.error == null)
            {
                // outputInfo = request.downloadHandler.text;
                outputInfo = request.downloadHandler.text;
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
