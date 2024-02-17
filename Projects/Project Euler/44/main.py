import math

def pent(n):
    return int((n * ((3 * n) - 1))//2)

pents = []

for i in range(1, 3_000):
    pents.append(pent(i))

pents_set = set(pents)

for x in range(len(pents)):
    for y in range(0, x):
        i = pents[x]
        j = pents[y]
        if i != j:
            if (i + j) in pents_set and (i - j) in pents_set:
                d = abs(i - j)
                print(d)
                exit(0)
