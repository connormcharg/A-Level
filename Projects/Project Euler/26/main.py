max_n = 0
max_d = 0

for i in range(11, 1000, 2):
    if i%5 != 0:
        n = 1
        while (10**n) % i != 1:
            n += 1
        if n > max_n:
            max_n = n
            max_d = i

print(max_d, max_n)