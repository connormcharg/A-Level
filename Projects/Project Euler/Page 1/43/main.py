from itertools import permutations
def is_divisible(n):
    return (int(str(n)[1:4]) % 2 == 0
            and int(str(n)[2:5]) % 3 == 0
            and int(str(n)[3:6]) % 5 == 0
            and int(str(n)[4:7]) % 7 == 0
            and int(str(n)[5:8]) % 11 == 0
            and int(str(n)[6:9]) % 13 == 0
            and int(str(n)[7:10]) % 17 == 0)
t = 0
def tuple_to_int(t):
    a = ""
    for x in t:
        a += str(x)
    return int(a)
pandigitals = list([tuple_to_int(x) for x in permutations([1, 2, 3, 4, 5, 6, 7, 8, 9, 0])])
for i in pandigitals:
    if not is_divisible(i):
        continue
    if len(set(str(i))) == 10:
        t += i
    print(i)
print(t)