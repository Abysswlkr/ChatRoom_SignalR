using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR
{
    //Se crea la clase ChatHub y su padre será Hub, que viene desde la biblioteca de SignalR
    public class ChatHub : Hub
    {
        //Metodo para mandar mensaje, se solicita la sala, usuario y mensaje
        public async Task SendMessage(string room, string user, string message)
        {
            await Clients.Group(room).SendAsync("ReceiveMessage",user, message);
        }

        //Metodo para añadir a un grupo, se solicita la sala
        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendAsync("ShowWho", $"Alguien se conectó {Context.ConnectionId}"); //Context.ConnectionId es el identificador unico en tu conexión de signalR
        }
    }
}
