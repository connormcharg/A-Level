t = 0
n = 2
while True:
    x = sum([int(i) ** 5 for i in str(n)])
    print(n, x)
    if x == n:
        t += n
    if n > 1000000:
        break
    n += 1

print(t)