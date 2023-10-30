import json
import socket

board = None
next_move = None
next_player = None


def receive():
    global board
    global next_move
    global next_player
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect(('127.0.0.1', 11451))
    length = s.recv(8)
    length = length.decode('utf-8')
    data = s.recv(int(length))
    s.close()
    data = data.decode('utf-8')
    data = json.loads(data)
    board = data['chessboard']
    