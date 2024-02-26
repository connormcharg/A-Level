a = 0
for i in range(1, 101): a += i
a **= 2

b = 0
for i in range(1, 101): b += i**2

print(abs(a-b))