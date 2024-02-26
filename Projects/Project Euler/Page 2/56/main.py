max_sum = 0

for a in range(1, 100):
    for b in range(1, 100):
        s = sum([int(x) for x in str(a**b)])
        if s > max_sum:
            max_sum = s

print(max_sum)