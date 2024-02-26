def is_lychrel(n):
    for i in range(49):
        n = int(str(n)) + int(str(n)[::-1])
        if str(n) == str(n)[::-1]:
            return False
    return True

t = 0

for i in range(1, 10_000):
    if is_lychrel(i):
        t += 1

print(t)