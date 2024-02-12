def is_palindrome(x):
    return str(x) == str(x)[::-1]

t = 0
for i in range(1_000_000):
    if is_palindrome(i) and is_palindrome(bin(i)[2:]):
        t += i

print(t)