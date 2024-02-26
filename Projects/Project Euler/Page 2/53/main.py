from math import factorial as f

t = 0

for n in range(1, 101):
    for r in range(1, n+1):
        if ((f(n))/(f(r)*f(n-r))) > 1_000_000:
            t += 1

print(t)