from math import gcd, prod

fractions = []

def common_digit(a, b):
    i = set(str(a)).intersection(set(str(b)))
    if len(i) != 0:
        return str(int(i.pop()))
    return ""

def cancel_digit(x, d):
    p = str(x).find(d)
    if p == 0:
        return str(x)[1]
    else:
        return str(x)[0]

def is_trivial(a, b):
    d = common_digit(a, b)
    if d == "":
        return True
    if d == "0":
        return True
    a2, b2 = int(cancel_digit(a, d)), int(cancel_digit(b, d))
    if b2 == 0:
        return True
    if (a2 / b2 == a / b):
        print(a, b, a2, b2)
        return False
    return True

def simplify(a, b):
    d = gcd(a, b)
    return (a//d, b//d)

for i in range(10, 100):
    for j in range(10, 100):
        if (i < j):
            if not is_trivial(i, j):
                fractions.append((i, j))

ans = [prod(fractions[i][0] for i in range(4)), prod(fractions[i][1] for i in range(4))]

ans = list(simplify(ans[0], ans[1]))

print(ans)