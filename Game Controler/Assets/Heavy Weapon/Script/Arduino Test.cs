using System;
using System.IO.Ports;          // <-- for SerialPort
using System.Threading;
using UnityEngine;
using UnityEngine.Events;        // <-- for UnityEvent

public class ArduinoSerialReader : MonoBehaviour
{
    [Header("Serial Port Settings")]
    public string portName = "COM6";
    public int baudRate = 9600;

    [Header("Unity Events")]
    public UnityEvent onButtonPressed;
    public UnityEvent onButtonReleased;

    private SerialPort serialPort;
    private Thread readThread;
    private bool keepReading = false;
    private string latestMessage = "";

    void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.ReadTimeout = 100;
            serialPort.Open();

            keepReading = true;
            readThread = new Thread(ReadSerial);
            readThread.Start();

            Debug.Log($"✅ Connected to {portName} at {baudRate} baud.");
        }
        catch (Exception e)
        {
            Debug.LogError($"❌ Serial connection error: {e.Message}");
        }
    }

    void Update()
    {
        if (string.IsNullOrEmpty(latestMessage)) return;

        string msg = latestMessage.Trim();
        latestMessage = "";

        if (msg == "1") onButtonPressed?.Invoke();
        else if (msg == "0") onButtonReleased?.Invoke();
    }

    void ReadSerial()
    {
        while (keepReading)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    string message = serialPort.ReadLine();
                    latestMessage = message;
                }
            }
            catch (TimeoutException) { }
            catch (Exception e)
            {
                Debug.LogWarning($"Serial read error: {e.Message}");
            }
        }
    }

    void OnApplicationQuit()
    {
        keepReading = false;
        Thread.Sleep(100);
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}
