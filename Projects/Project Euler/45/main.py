def pentagle(n):
    return int(n*((3*n)-1)*0.5)

def hexagle(n):
    return int(n*(2*n - 1))

pents = []
hexes = []

for i in range(166, 50_000):
    pents.append(pentagle(i))
    hexes.append(hexagle(i))

for i in range(len(pents)):
    if pents[i] in hexes:
        print(i, pents[i])
        exit()