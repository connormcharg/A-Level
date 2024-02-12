from itertools import permutations

def is_pandigital(a, b, c):
    digits = set(str(a) + str(b) + str(c))
    return len(digits) == 9 and '0' not in digits

products = set()

for a in range(1, 100):
    for b in range(a, 10000 // a):
        c = a * b
        if is_pandigital(a, b, c):
            products.add(c)

sum_of_products = sum(products)
print(sum_of_products)
