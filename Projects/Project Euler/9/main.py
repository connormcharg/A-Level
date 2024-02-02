for a in range(1, 500):
    for b in range(1, 500):
        for c in range(1, 500):
            if a ** 2 + b ** 2 == c ** 2 and a + b + c == 1000:
                print(a)
                print(b)
                print(c)
                d = a * b * c
                print(f"Product of {a}, {b} and {c} is: {d}")