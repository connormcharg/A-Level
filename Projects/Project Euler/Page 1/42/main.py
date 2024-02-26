from string import ascii_uppercase

with open("C:/Users/conno/OneDrive/Documents/GitHub/A-Level/Projects/Project Euler/42/words.txt") as f:
    words = [x[1:-1] for x in f.read().split(",")]

letters = list(ascii_uppercase)
letters = dict(enumerate(letters, start=1))
letters = {v: k for k, v in letters.items()}
triangle_nums = {}

def gen_triangle(n):
    if n not in triangle_nums:
        triangle_nums[n] = int(0.5 * n * (n + 1))
    return triangle_nums[n]

for i in range(1, 1_000_000):
    gen_triangle(i)

t = 0
for word in words:
    y = sum([letters[x] for x in word])
    if y in triangle_nums.values():
        t += 1

print(t)