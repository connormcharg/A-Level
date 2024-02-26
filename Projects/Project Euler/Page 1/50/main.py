import json

with open("c:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/primes_million.json", "r") as f:
    primes = json.loads(f.read())["primes"]

max_length = 0
max_prime = 0

# primes = primes[:5]
# print(primes)

prime_set = set(primes)

n = 1000

# print(sum(primes[3:24]))

for i in range(0, n): # for every starting point
    for j in range(1, n-i): # for every length of run
        s = sum(primes[i:i+j+1])
        if s in prime_set:
            if j > max_length:
                max_length = j
                max_prime = s

print(max_prime, max_length)