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

sum = 2
a = find_next_prime(2)
while a < 2_000_000:
    sum += a
    print(a)
    a = find_next_prime(a)

print(sum)
    