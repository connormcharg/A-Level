import json
import math

with open("c:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/primes_million.json", "r") as f:
    primes = json.loads(f.read())["primes"]

for i in range(9, 1_000_000, 2):
    if i in primes:
        continue
    x = 0
    f = False
    while primes[x] < i:
        t = i - primes[x]
        if t % 2 != 0:
            x += 1
            continue
        t = t // 2
        if math.isqrt(t) == math.sqrt(t):
            f = True
        x += 1
    if not f:
        print(i)
        exit(0)