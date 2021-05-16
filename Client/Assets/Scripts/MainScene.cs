using UnityEngine;
using Grpc.Core;

public class MainScene : MonoBehaviour
{
    Channel m_Channel;

    void Start()
    {
        Connect();
    }

    void Connect()
    {
        try
        {
            m_Channel = new Channel("localhost", 5000, ChannelCredentials.Insecure);
            m_Channel.ConnectAsync();

        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    void Update()
    {
        if (m_Channel == null) return;
        Debug.Log($"Channel State: {m_Channel.State}");
    }

    public void OnClick() => Debug.Log("haha");
}
