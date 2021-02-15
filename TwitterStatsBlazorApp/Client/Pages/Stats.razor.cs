using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using TwitterStatsBlazorApp.Shared;

namespace TwitterStatsBlazorApp.Client.Pages
{
    public partial class Stats : IDisposable
    {
        private Counters counters;
        private HubConnection hubConnection;

        protected override async Task OnInitializedAsync()
        {

            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/broadcastHub")
                .Build();

            hubConnection.On<Counters>("ReceiveMessage", c =>
            {
                counters = c;
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        public void Dispose()
        {

        }
    }
}
