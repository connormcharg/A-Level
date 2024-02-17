champernowne = []
for i in range(500000):
    champernowne.extend(list(str(i)))

print(int(champernowne[1])*int(champernowne[10])*int(champernowne[100])*int(champernowne[1000])*int(champernowne[10000])*int(champernowne[100000])*int(champernowne[1000000]))