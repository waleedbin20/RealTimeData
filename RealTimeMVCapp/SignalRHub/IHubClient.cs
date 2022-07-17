using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.SignalRHub
{

    // notify the client if any change happens
    public interface IHubClient
    {
        Task BroadcastMessage(int materialId, int materialYflag);

        Task BroadcastMaterialItem(int materialId, string materialitems);
    }
}
