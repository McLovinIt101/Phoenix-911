using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix_911.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            API.RegisterCommand("911", new Action<int, List<object>, string>((source, args, rawCommand) =>
            {
                SendMessage(args);
            }), false);

            EventHandlers["Get911Message"] += new Action<string, string>((message, postal) =>
            {
                DisplayCall(message, postal);
            });
        }

        private void SendMessage(List<object> args)
        {
            var playerLocation = Game.PlayerPed.Position;
            var message = string.Join(" ", args);

            TriggerServerEvent("Send911ToLeo", message, playerLocation);
            NotifyCallSent();
        }

        private void DisplayCall(string message, string postal)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 }, 
                multiline = false,
                args = new[] { "911 Call", $" (Postal: {postal}) {message}" }
            });
        }

        private void NotifyCallSent()
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                multiline = false,
                args = new[] { "911 System", "Your 911 call is being processed. Law enforcement has been dispatched." }
            });
        }
    }
}