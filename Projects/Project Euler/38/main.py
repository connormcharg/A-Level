def is_pandigital(n):
    digits = set(n)
    return len(digits) == 9 and len(n) == 9 and '0' not in digits

max_n = 0

for i in range(1, 9328):
    string = ""
    j = 1
    while len(string) < 9:
        string += str(i*j)
        j += 1
    if is_pandigital(string):
        if int(string) > max_n:
            max_n = int(string)
    i += 1

print(max_n)