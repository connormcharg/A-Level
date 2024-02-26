def primes(n):
    prime = [True for i in range(n+1)]
    p = 2
    while(p * p <= n):
        if (prime[p] == True):
            for i in range(p * p, n + 1, p):
                prime[i] = False
        p += 1
    return prime

p = primes(1_000_000)

def is_prime(n):
    return p[n]
    

def shift(x):
    return int(str(x)[-1] + str(x)[:-1])

def get_rotations(x):
    # 012, 201, 120
    result = []
    for i in range(len(str(x))):
        result.append(x)
        x = shift(x)
    return result

def is_circular(x):
    y = get_rotations(x)
    for z in y:
        if not is_prime(z):
            return False
    return True

t = 1

for i in range(3, 1_000_000, 2):
    if is_circular(i):
        print(i)
        t += 1

print(t)