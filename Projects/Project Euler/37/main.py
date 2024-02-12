def primes(n):
    prime = [True for i in range(n+1)]
    prime[0] = False
    prime[1] = False
    p = 2
    while(p * p <= n):
        if (prime[p] == True):
            for i in range(p * p, n + 1, p):
                prime[i] = False
        p += 1
    return prime

p = primes(1_000_000)

def is_truncatable_prime(x):
    for i in range(len(str(x))):
        if not p[int(str(x)[i:])]:
            return False
        if not p[int(str(x)[::-1][i:][::-1])]:
            return False
    return True

t = 0
for i in range(13, 1_000_000, 2):
    if p[i]:
        if is_truncatable_prime(i):
            t += i

print(t)