import json

def primes(n):
    prime = [True for i in range(n+1)]
    p = 2
    while(p * p <= n):
        if (prime[p] == True):
            for i in range(p * p, n + 1, p):
                prime[i] = False
        p += 1
    prime_list = []
    for i in range(2, len(prime)):
        if prime[i]:
            prime_list.append(i)
    return prime_list

with open("c:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/primes_million.json", "w+") as f:
    f.write(json.dumps({"primes": primes(1_000_000)}))

