// Server -> Client definition
using System.Threading.Tasks;
using MagicOnion;

public interface IHubReceiver
{
}
 
// Client -> Server definition
// implements `IStreamingHub<TSelf, TReceiver>`  and share this type between server and client.
public interface IHub : IStreamingHub<IHub, IHubReceiver>
{
    Task Send(string id);
}
 