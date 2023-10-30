using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


namespace TTTEnhanced.Models;

public class SocketCommunicationModel
{
    public static void Send(ObservableCollection<ObservableCollection<char?>> chessboard, PlayerType playerType,
        int[]? nextMove = null)
    {
        string cb = JsonSerializer.Serialize(chessboard);
        var jsonData = new {
            chessboard = cb,
            nextPlayer = playerType == PlayerType.Ai ? "Ai" : "Player",
            nextMove = nextMove
        };
        string json = JsonSerializer.Serialize(jsonData);

        Socket s = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11451));

        NetworkStream ns = new(s);
        byte[] data;
        byte[] header = Encoding.UTF8.GetBytes((data = Encoding.UTF8.GetBytes(json)).Length.ToString("D8"));
        ns.Write(header, 0, header.Length);
        ns.Write(data, 0, data.Length);
        
        s.Close();
    }
}