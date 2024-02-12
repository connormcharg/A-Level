"""
b has to be odd
"""
from functools import cache
from math import prod

@cache
def is_prime(n):
    if n <= 1:
        return False
    if n == 2:
        return True
    for i in range(2, n):
        if n % i == 0:
            return False
    return True

max_c = 0
best_ab = (0, 0)

for a in range(-999, 1000):
    for b in range(-999, 1001, 2):
        if not is_prime(b):
            continue
        if (a**2 - 4*b) > 0:
            continue
        f = True
        n = 1
        c = 0
        f = is_prime(((n*n) + (a*n) + b))
        while f:
            c += 1
            n += 1
            f = is_prime(((n*n) + (a*n) + b))
        if c > max_c:
            max_c = c
            best_ab = (a, b)

print(best_ab, prod(best_ab))