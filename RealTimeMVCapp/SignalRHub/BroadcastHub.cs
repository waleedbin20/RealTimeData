using Microsoft.AspNetCore.SignalR;
using RealTimeMVCapp.Data.Entities;
using RealTimeMVCapp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.SignalRHub
{

    // we will use this to broadcast message to connected clients
    public class BroadcastHub : Hub<IHubClient>
    {

    }
}
