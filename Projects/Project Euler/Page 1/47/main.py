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

i = 2
while True:
    if len(set(prime_factors(i))) == len(set(prime_factors(i+1))) == len(set(prime_factors(i+2))) == len(set(prime_factors(i+3))) == 4:
        print(i)
        exit(0)
    i += 1