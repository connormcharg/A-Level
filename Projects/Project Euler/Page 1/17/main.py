large_numbers = {
    0: "", 1: "onehundred", 2: "twohundred", 3: "threehundred", 4: "fourhundred", 5: "fivehundred",
    6: "sixhundred", 7: "sevenhundred", 8: "eighthundred", 9: "ninehundred"
}
med_numbers = {
    0: "", 2: "twenty", 3: "thirty", 4: "forty", 5: "fifty", 6: "sixty", 7: "seventy",
    8: "eighty", 9: "ninety"
}
small_numbers = {
    0: "", 1: "one", 2: "two" , 3: "three", 4: "four", 5: "five", 6: "six", 7: "seven", 8: "eight", 
    9: "nine", 10: "ten", 11: "eleven", 12: "twelve", 13: "thirteen", 14: "fourteen", 15: "fifteen",
    16: "sixteen", 17: "seventeen", 18: "eighteen", 19: "nineteen"
}
thou = "onethousand"

def find_chars(n):
    string = ""
    if 0 < n < 20:
        string += small_numbers[int(str(n))]
    if 19 < n < 100:
        string += med_numbers[int(str(n)[0])]
        string += small_numbers[int(str(n)[1])]
    if 99 < n < 1000:
        string += large_numbers[int(str(n)[0])] + "and"
        string += find_chars(int(str(n)[1:]))
    if 999 < n:
        string += thou
    return string

b = 0
for i in range(1, 1001):
    print(i, find_chars(i))
    b += len(find_chars(i))

b -= 27
print(b)