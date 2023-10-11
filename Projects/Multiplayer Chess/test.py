import requests as r
import json
import uuid

url = "http://127.0.0.1:5000/"

def printarray(array):
    for i in array:
        print(i)

code = str(input("code: "))


userid = str(uuid.uuid4())
xtra = "setup/" + code + "/" + userid
code = str(r.put(url + xtra).json()["code"])

xtra = "board/" + code + "/" + userid + "/black"
board = r.get(url + xtra).json()["board"]
printarray(board)

