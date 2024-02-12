def sum_factors(n):
    i = 1
    f = []
    while i*i < n:
        if n % i == 0:
            f.append(i)
            f.append(n // i)
        i += 1
    if n in f:
        f.remove(n)
    return sum(f)

sums = [0 for i in range(10001)]
t = 0

for i in range(2, 10001):
    x = sum_factors(i)
    if x > 10000:
        continue
    else:
        sums[i] = x

for i in range(2, 10001):
    if i == sums[sums[i]]:
        if i != sums[i]:
            t += i

print(t)