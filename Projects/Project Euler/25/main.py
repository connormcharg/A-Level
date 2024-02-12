from functools import cache

@cache
def fib(n):
    if n <= 1:
        return n
    return fib(n-1) + fib(n-2)

i = 1
while len(str(fib(i))) < 1000:
    i += 1

print(i)