def sum_factors(n):
    if n == 0:
        return 0
    if n == 1:
        return 0
    i = 1
    f = []
    while i*i <= n:
        if n % i == 0:
            if i == n // i:
                f.append(i)
            else:
                f.append(i)
                f.append(n // i)
        i += 1
    if n in f:
        f.remove(n)
    return sum(f)

a = [sum_factors(i) for i in range(0, 28124)]
b = []
for i in range(0, 28124):
    if a[i] > i:
        b.append(i)

sums = set()
for i in b:
    for x in b:
        if i+x < 28124:
            sums.add(i+x)

nums = set([x for x in range(28124)])

print(sum(list(nums-sums)))