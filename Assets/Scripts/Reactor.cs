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
    /// Increase min 0 and max 1
    /// </summary>
    public float waterIncrease { get; private set; }


    /// <summary>
    /// Increase min 0 and max 1
    /// </summary>
    public float PipeIncrease { get; private set; }

    /// <summary>
    /// Above 10, reactor is cooled
    /// </summary>
    public float waterLevel { get { return m_waterLevel; } set { m_waterLevel = value > 0 ? value : 0; } }
    [SerializeField] private float m_waterLevel;


    public bool isPipeBroke;

    // Start is called before the first frame update
    void Start()
    {
        temperatureLevel = 25;
        waterIncrease = 0.5f;
        PipeIncrease = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float neededWater = Time.deltaTime;

        if (waterLevel < neededWater)
        {
            //temperature rise because do not get necessary water
            waterIncrease += neededWater / 2;
        }
        else
        {
            waterLevel = waterLevel - neededWater;
            waterIncrease -= neededWater / 2;
        }


        if (isPipeBroke)
        {
            PipeIncrease += Time.deltaTime * 2;
        }
        else
        {
            PipeIncrease -= Time.deltaTime;
        }


        waterIncrease = Mathf.Clamp01(waterIncrease);
        PipeIncrease = Mathf.Clamp01(PipeIncrease);

        float level = 2f;
        if (GameManager.instance != null)
        {
            if (GameManager.instance.currentLevel == GameManager.Level.easy)
                level = 1.5f;

            if (GameManager.instance.currentLevel == GameManager.Level.normal)
                level = 1f;

            if (GameManager.instance.currentLevel == GameManager.Level.normal)
                level = 0.5f;

        }

        temperatureLevel += Time.deltaTime * (waterIncrease + PipeIncrease - level);


        if (temperatureLevel < 10)
        {
            if (temperatureLevel < 0) temperatureLevel = 0;
        }
        else if (temperatureLevel > 100)
        {
            GameManager.instance.GameOver();
        }

        meter.SetMeter(temperatureLevel);
    }
}
