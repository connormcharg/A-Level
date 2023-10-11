from flask import Flask
from flask_restful import Api, Resource
import ChessEngine
from random import randint as rand

app = Flask(__name__)
api = Api(app)

games = {}
indexFlip = {
    0: 7,
    1: 6,
    2: 5,
    3: 4,
    4: 3,
    5: 2,
    6: 1,
    7: 0
}

class Board(Resource):
    def get(self, code = 0, userid = "", colour = "white"):
        if code in games:
            if userid in games[code][1]:
                game = games[code][0]
            else:
                return {"board": "uuid not found"}
        else:
            return {"board": "code not found"}
        if colour == "white":
            return {"board": games[code][0].board}
        else:
            board = []
            for i in reversed(games[code][0].board):
                board.append(list(reversed(i)))
            return {"board": board}

class Setup(Resource):
    def put(self, code = 0, userid = ""):
        if code == 0:
            code = rand(100000, 999999)
            while code in games:
                code = rand(100000, 999999)
            games[code] = [ChessEngine.GameState(), []]
            games[code][1].append(userid)
            return {"code": code}
        else:
            if code in games:
                if userid in games[code][1]:
                    return {"code": code}
                elif len(games[code][1]) == 2:
                    return {"code": -2}
                else:
                    games[code][1].append(userid)
                    return {"code": code}
            else:
                return {"code": -1}
            
class PreviousMove(Resource):
    def get(self, code = 0, userid = "", colour = "white"):
        if code in games:
            if userid in games[code][1]:
                game = games[code][0]
            else:
                return {"error": "uuid not found"}
        else:
            return {"error": "code not found"}
        prevMove = game.moveLog[-1]
        prevMoveInfo = [prevMove.startRow, prevMove.startCol, prevMove.endRow, prevMove.endCol]
        if colour == "black":
            for i in range(4):
                prevMoveInfo[i] = indexFlip[prevMoveInfo[i]]
        return {"previousmove": prevMoveInfo}
    
class MakeMove(Resource):
    def put(self, code=0, userid="", colour="white", startRow=0, startCol=0, endRow=0, endCol=0):
        if code in games:
            if userid in games[code][1]:
                game = games[code]
            else:
                return {"error": "uuid not found"}
        else:
            return {"error": "code not found"}
        if colour == "black":
            startRow = indexFlip[startRow]
            startCol = indexFlip[startCol]
            endRow = indexFlip[endRow]
            endCol = indexFlip[endCol]
        if len(game) == 2:
            game.append(game[0].getValidMoves())
        else:
            game[2] = game[0].getValidMoves()
        for move in game[2]:
            if move.startRow == startRow and move.startCol == startCol and move.endRow == endRow and move.endCol == endCol:
                game[0].makeMove(move)
                game[2] = []
                return {"error": "none"}
        return {"error": "invalid move"}


api.add_resource(Board, "/board/<int:code>/<string:userid>/<string:colour>")
api.add_resource(Setup, "/setup/<int:code>/<string:userid>")
api.add_resource(PreviousMove, "/previousmove/<int:code>/<string:userid>/<string:colour>")
api.add_resource(MakeMove, "/makemove/<int:code>/<string:userid>/<string:colour>/<int:startRow>/<int:startCol>/<int:endRow>/<int:endCol>")

if __name__ == "__main__":
    app.run(debug=True)