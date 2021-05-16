// Server -> Client definition
using System.Threading.Tasks;
using MagicOnion;

public interface IGamingHubReceiver
{
}
 
// Client -> Server definition
// implements `IStreamingHub<TSelf, TReceiver>`  and share this type between server and client.
public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
{
    Task fdsjfslkdf(string id);
}
 