i = 0
while True:
    i += 1
    if (set(str(i)) == set(str(2*i)) and
        set(str(i)) == set(str(3*i)) and
        set(str(i)) == set(str(4*i)) and
        set(str(i)) == set(str(5*i)) and
        set(str(i)) == set(str(6*i))):
        print(i)
        exit(0)