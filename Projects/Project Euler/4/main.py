a = 0

def palindrome(n):
    return str(n) == str(n)[::-1]

for i in range(1, 1000):
    for j in range(1, 1000):
        b = i*j
        if palindrome(b):
            if b > a:
                a = b

print(a)
