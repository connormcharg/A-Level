from fractions import Fraction

a = Fraction(1, 2)
b = Fraction(1, 1)
t = 0

for i in range(999):
    if len(str((a+b).numerator)) > len(str((a+b).denominator)):
        t += 1
    a = Fraction(1, (2+a))

print(t)