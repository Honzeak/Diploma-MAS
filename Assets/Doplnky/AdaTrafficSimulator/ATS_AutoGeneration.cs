using UnityEngine;

public class ATS_AutoGeneration : MonoBehaviour
{
    [Header("AutoGeneration")]
    public ATS_Trajektorie Trajetory;
    public GameObject[] Vehicles;


    public Vector3 Offset;
    private int MaxVehicles;
    [Header("Generation Parametrs")]
    public bool DestroyAtEnd;
    public bool GenerateOnStart = false;
    public bool GenerateInGame = true;
    public float Intensity = 1200;
    public float speed;
    private int randID;
    private float helpTime;
    public float randIntensity;

    private void Start()
    {
        MaxVehicles = Vehicles.Length-1;
        if (GenerateOnStart == true)
        {
            float length = Trajetory.lines.Length * 2;
            float hustota = 3600 / Intensity;
            float randPosition = 0;

            do
            {
                randID = Random.Range(0, MaxVehicles);
                GenerateVehicle(randID, randPosition);
                randPosition = randPosition + speed * Random.Range(1, 2 * hustota - 1);
            } while (randPosition < length);

        }
    }

    public void GenerateVehicle(int ID, float Position)
    {
        GameObject car = Object.Instantiate(Vehicles[ID]);
        car.GetComponent<ATS_VehicleManager>().Trajektory = Trajetory;
        car.GetComponent<ATS_VehicleManager>().speed = speed;
        car.GetComponent<ATS_VehicleManager>().Offset = Offset;
        car.GetComponent<ATS_VehicleManager>().MyPosition = Position;
            car.GetComponent<ATS_VehicleManager>().EndDestroy = DestroyAtEnd;

    }
    // Update is called once per frame
    void Update()
    {
        if (GenerateInGame == true)
        {
            helpTime += Time.deltaTime;
            if (helpTime > randIntensity)
            {
                randID = Random.Range(0, MaxVehicles);
                GenerateVehicle(randID, 0);
                helpTime = 0;
                if (Intensity > 3600)
                {
                    Intensity = 3600;
                }
                randIntensity = Random.Range(1, 1 + 2 * ((3600 / Intensity) - 1));
            }
        }

    }
}
