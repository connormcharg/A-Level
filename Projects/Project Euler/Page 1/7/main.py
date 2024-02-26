from functools import cache

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

def find_next_prime(n):
    m = n + 1
    while not is_prime(m):
        m += 1
    return m

def find_nth_prime(n):
    m = 2
    for i in range(n-1):
        m = find_next_prime(m)
    return m

print(find_nth_prime(10001))