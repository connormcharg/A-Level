from itertools import permutations

def prime_factors(n):
    i = 2
    factors = []
    while i * i <= n:
        if n % i:
            i += 1
        else:
            n //= i
            factors.append(i)
    if n > 1:
        factors.append(n)
    return factors

for i in range(1000, 10_000):
    p = []
    for j in list(permutations(str(i))):
        if len(prime_factors(int(''.join(j)))) == 1:
            s = ''.join(j)
            if s[0] != "0":
                p.append(int(s))
    p = list(set(p))
    if len(p) > 2:
        for x in range(1, len(p)):
            for y in range(x+1, len(p)):
                if (p[y] - p[x]) == (p[x] - p[0]) != 0:
                    p.sort()
                    print(p)
                    print(''.join([str(x) for x in p]), "\n")
                    quit()
                    