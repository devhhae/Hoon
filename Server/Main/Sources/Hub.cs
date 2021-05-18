using System.Threading.Tasks;
using Shared;
using MagicOnion.Server.Hubs;
using System;

public class fdsjfslkdf : StreamingHubBase<IHub, IHubReceiver>, IHub
{
    Task IHub.Send(string id)
    {
        Console.WriteLine(id);

        using(var db = new MyContext())
        {
            var u = new UserData();
            u.DeviceKey = id;
            u.LogTime = System.DateTime.UtcNow;
            db.Add(u);
            db.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }
}