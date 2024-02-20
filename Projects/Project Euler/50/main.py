import json
import math

with open("c:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/primes_million.json", "r") as f:
    primes = json.loads(f.read())["primes"]

max_length = 0
max_prime = 0

prime_set = set(primes)

print(sum(primes[3:24]))


for j in range(0, len(primes)):
    for k in range(1, len(primes)-j-1):
        if sum(primes[j:j+k+1]) in prime_set:
            if k+1 > max_length:
                max_length = k+1
                max_prime = sum(primes[j:j+k+1])
                print(max_prime, max_length)

print(max_prime, max_length)