using System.Net.WebSockets;
using System.Text;

public class WebSocketManager
{
    private readonly List<WebSocket> _clients = new();

    public async Task AddClient(WebSocket socket)
    {
        _clients.Add(socket);
        await ReceiveLoop(socket);
    }

    public async Task Broadcast(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);

        foreach (var client in _clients.Where(c => c.State == WebSocketState.Open))
        {
            await client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }

    private async Task ReceiveLoop(WebSocket socket)
    {
        var buffer = new byte[1024];
        while (socket.State == WebSocketState.Open)
        {
            await socket.ReceiveAsync(buffer, CancellationToken.None);
        }
    }
}
