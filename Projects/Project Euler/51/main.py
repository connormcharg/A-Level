import time

def gen_wildcards(s, i):
    if i > 0 and s not in searched:
        wildcards.append(s)
        searched.add(s)
    for x in range(i, len(s)):
        gen_wildcards(create_placeholder(s, x), x+1)

def create_placeholder(s, i):
    return s[0:i] + "*" + s[i+1:]

start = time.time()
primes = [2]
searched = set()

for x in range(3, 1_000_000):
    f = False
    for i in range(0, len(primes)):
        if x % primes[i] == 0:
            f = True
            break
        if primes[i] * primes[i] > x:
            break
    if not f:
        primes.append(x)
        
prime_set = set(primes)

for x in range(len(primes)):
    wildcards = []
    gen_wildcards(str(primes[x]), 0)
    for y in range(1, len(wildcards)):
        c = 0
        for z in range(10):
            n = int(wildcards[y].replace("*", str(z)))

            if len(str(n)) < len(wildcards[y]):
                continue
            if n in prime_set:
                c += 1
        if c >= 8:
            print(primes[x])
            print(wildcards[y])
            print("time: " + str(time.time() - start))
            exit(0)