from math import factorial

def is_curious(x):
    if sum([factorial(int(y)) for y in str(x)]) == x:
        return True
    return False

t = 0

count_since_last = 0
i = 3
while True:
    if is_curious(i):
        t += i
        count_since_last = 0
    else:
        count_since_last += 1
    i += 1
    if count_since_last > 1000000:
        break

print(t)