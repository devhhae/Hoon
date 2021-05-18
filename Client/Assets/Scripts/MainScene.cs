using UnityEngine;
using Grpc.Core;
using System.Threading.Tasks;
using MagicOnion.Client;
using System.Threading;

public class MainScene : MonoBehaviour
{
    Channel m_Channel;
    HubClient m_Client = default;
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
            m_Client = new HubClient();
            var _ = m_Client.ConnectAsync(m_Channel);

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

    public void OnClick()
    {
        m_Client.Send(SystemInfo.deviceUniqueIdentifier);
    }
}

public class HubClient : IHubReceiver
{
    IHub m_Client = default;

    public async Task ConnectAsync(Channel grpcChannel)
    {
        var cancelToken = new CancellationToken();
        var callOptions = new CallOptions();
        // callOptions = callOptions.WithDeadline(System.DateTime.UtcNow.AddSeconds(5));
        callOptions = callOptions.WithCancellationToken(cancellationToken: cancelToken);
        try
        {
            m_Client = await StreamingHubClient.ConnectAsync<IHub, IHubReceiver>(
                grpcChannel, this, string.Empty, callOptions);
            Debug.Log("CommonHubClient connect result: " + (m_Client != null));
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    // You can watch connection state, use this for retry etc.
    public Task WaitForDisconnect()
    {
        return m_Client.WaitForDisconnect();
    }

    // dispose client-connection before channel.ShutDownAsync is important!
    public Task DisposeAsync()
    {
        return m_Client.DisposeAsync();
    }

    public Task Send(string id)
        => m_Client.Send(id);

}