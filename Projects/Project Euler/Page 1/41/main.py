import json

with open("c:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/primes_10_million.json", "r+") as f:
    prime_list = json.loads(f.read())["primes"]

print("IMPORTED PRIMES")

def is_pandigital(n):
    n_digits = set([int(i) for i in str(n)])
    digits = set([i for i in range(1, len(str(n))+1)])
    # print(digits, n_digits)
    if digits == n_digits and "0" not in n_digits:
        return True
    return False

for i in prime_list[::-1]:
    if is_pandigital(i):
        print(i, "PANDIGITAL")
        exit(0)