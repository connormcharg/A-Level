import math

def find_triples(n):
    sols = 0
    for c in range(1, n):
        for b in range(1, c):
            x = c**2 - b**2
            a = math.sqrt(x)
            if a + b + c == n:
                sols += 1
    return sols

max_sols = 0
max_n = 0
for i in range(1, 1001):
    sols = find_triples(i)
    if sols > max_sols:
        max_sols = sols
        max_n = i
        print(i, "MAX")
    else:
        print(i)

print(max_n, max_sols)