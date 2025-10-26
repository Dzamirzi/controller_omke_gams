using UnityEngine;
using System.IO.Ports;

public class ArduinoShooterBridge : MonoBehaviour
{
    public Shooter2D shooter;          // Drag your Shooter2D object here
    public string portName = "COM2";   // Use the same port as Proteus (COM2)
    public int baudRate = 9600;

    private SerialPort serialPort;

    void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
            Debug.Log("Connected to Arduino on " + portName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Could not open serial port: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                data = data.Trim();

                if (data == "1")
                {
                    shooter.SendMessage("Shoot");
                }
            }
            catch (System.TimeoutException)
            {
                // ignore timeouts
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
