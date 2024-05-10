using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix_911.Server
{
    public class ServerMain : BaseScript
    {
        private readonly HashSet<int> validLeoDepartmentIds = new HashSet<int> { 1, 2, 3, 5 };

        public ServerMain()
        {
            EventHandlers["Send911ToLeo"] += new Action<Player, string, Vector3>((player, message, location) =>
            {
                string postalCode = GetPostalCode(location);

                foreach (Player p in GetLeoPlayers())
                {
                    try
                    {
                        p.TriggerEvent("Get911Message", message, postalCode);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error sending 911 message to LEO {p.Handle}: {ex.Message}");
                    }
                }
            });
        }

        private IEnumerable<Player> GetLeoPlayers()
        {
            return Players.Where(p => p.State != null &&
                                      p.State["DepartmentId"] is int departmentId &&
                                      validLeoDepartmentIds.Contains(departmentId));
        }

        private string GetPostalCode(Vector3 location)
        {
            dynamic postalData = Exports["nearest-postal"].getPostalServer(location);
            return postalData?.code ?? "Unknown";
        }
    }
}