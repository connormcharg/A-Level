with open("A-Level/Projects/Project Euler/67/tree.txt") as f:
    tree = [[int(i) for i in line.split()] for line in f.readlines()]

maximums = {hash((i, len(tree)-1)): tree[-1][i] for i in range(len(tree[-1]))}
iterations = 0


def max_path(x, y) -> int:
    global iterations
    iterations += 1
    
    if hash((x, y)) in maximums:
        return maximums[hash((x, y))]
    
    left = max_path(x, y+1)
    right = max_path(x+1, y+1)
    
    if left >= right:
        maximums[hash((x,y))] = left + tree[y][x]
        return maximums[hash((x, y))]
    else:
        maximums[hash((x,y))] = right + tree[y][x]
        return maximums[hash((x, y))]

print(max_path(0, 0))
print(iterations)