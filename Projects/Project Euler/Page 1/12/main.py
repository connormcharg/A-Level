def factors(n):
    i = 1
    f = 0
    while i*i < n:
        if n % i == 0:
            f += 2
        i += 1
    return f

a = 1
n = 1
while factors(a) <= 500:
    n += 1
    a = int(0.5*n*(n+1))

print(a)