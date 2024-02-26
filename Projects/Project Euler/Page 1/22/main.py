with open("A-Level/Projects/Project Euler/22/names.txt", "r") as f:
    x = f.readline().split(",")

x = [y[1:-1] for y in x]
x.sort()

t = 0

for i in range(len(x)):
    t += sum([ord(z) - 64 for z in x[i]]) * (i + 1)

print(t)
