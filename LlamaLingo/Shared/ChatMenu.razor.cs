using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using LlamaLingo.Models;

namespace LlamaLingo.Shared
{
    public partial class ChatMenu
    {
        private HubConnection hubConnection;
        private List<UserMessage> userMessages = new();
        private string usernameInput;
        private string messageInput;
        private bool isUserReadonly = false;
        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            try
            {            
                hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/chathub")).Build();
                hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
                {
                    InvokeAsync(() =>
                    {
                        userMessages.Add(new UserMessage { Username = user, Message = message, CurrentUser = user == usernameInput, DateSent = DateTime.Now });
                        StateHasChanged();
                    });
                });
                await hubConnection.StartAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

        private async System.Threading.Tasks.Task Send()
        {
            try 
            { 
            // Verify that the user has entered a username and a message.
                if (!string.IsNullOrEmpty(usernameInput) && !string.IsNullOrEmpty(messageInput))
                {
                    await hubConnection.SendAsync("SendMessage", usernameInput, messageInput);
                    isUserReadonly = true;
                    messageInput = string.Empty;
                }
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

        public async ValueTask DisposeAsync()
        {
            try
            {
			    if (hubConnection is not null)
                {
                    await hubConnection.DisposeAsync();
                }
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
        }
    }
}