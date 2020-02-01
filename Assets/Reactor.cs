using UnityEngine;

public class Reactor : MonoBehaviour
{
    [SerializeField] private Meter meter;

    /// <summary>
    /// Good temperature is between 0 and 20. Bad temperature is between 80 and 100
    /// </summary>
    public float temperatureLevel { get { return m_temperatureLevel; } private set { m_temperatureLevel = value; } }
    [SerializeField] private float m_temperatureLevel;

    /// <summary>
    /// Increase min -1 and max 1
    /// </summary>
    public float temperatureIncrease { get; private set; }


    /// <summary>
    /// Above 10, reactor is cooled
    /// </summary>
    public float waterLevel { get { return m_waterLevel; } private set { m_waterLevel = value > 0 ? value : 0; } }
    [SerializeField] private float m_waterLevel;


    // Start is called before the first frame update
    void Start()
    {
        temperatureLevel = 25;
        temperatureIncrease = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float neededWater = Time.deltaTime;

        if (waterLevel < neededWater)
        {
            //temperature rise because do not get necessary water
            temperatureIncrease += neededWater / 2;
            if (temperatureIncrease > 1) temperatureIncrease = 1;
        }
         else
        {
            waterLevel = waterLevel - neededWater;
            temperatureIncrease -= neededWater / 2;
            if (temperatureIncrease < -1) temperatureIncrease = -1;
        }

        temperatureLevel += Time.deltaTime * temperatureIncrease * 1;


        if (temperatureLevel < 10)
        {
            if (temperatureLevel < 0) temperatureLevel = 0;
        }
        else if (temperatureLevel > 100)
        {
            Debug.LogWarning("Game over");
        }

        meter.SetMeter(temperatureLevel);
    }
}
