from functools import cache

@cache
def fib(n):
    if n <= 1:
        return n
    return fib(n-1) + fib(n-2)

b = 0
for i in range(1, 34):
    a = fib(i)
    if a%2 == 0:
        b += a

print(b)