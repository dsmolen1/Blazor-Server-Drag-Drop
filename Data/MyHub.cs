using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDragDrop.Data
{
    public class MyHub : Hub
    {
        // this list holds the ids of the cards in the current order - this is the state of the app
        private static List<string> cards = new List<string>();

        // when this method is called, the app is initialized
        public async Task State()
        {
            cards = new List<string>() { "AS", "KH", "QC", "JD", "TS" };
            await Clients.Caller.SendAsync(MessageType.STATE, new StateMessage() { Cards = cards });
        }

        // this method changes the state of the app to reflect the drag/drop and then sends the new state to the client
        public async Task CardMoved(string src, string dest)
        {
            cards.Remove(src);
            cards.Insert(cards.IndexOf(dest), src);
            await Clients.Caller.SendAsync(MessageType.STATE, new StateMessage() { Cards = cards });
        }
    }

    // using these strings is preferable to hard-coding the method names in the calls
    public static class MessageType
    {
        public static string CARD_MOVED = "CardMoved";
        public static string STATE = "State";
    }

    // this message conveys the state of the game to the browser
    public class StateMessage
    {
        public List<string> Cards { get; set; }
    }
}
