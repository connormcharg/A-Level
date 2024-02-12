from itertools import permutations

a = list(permutations([x for x in range(10)]))
a.sort()

print(a[999999])

## Do this w/o itertools