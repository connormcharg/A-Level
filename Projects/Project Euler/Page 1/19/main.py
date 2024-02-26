day = 0 # 0 is monday
year = 1900

months = {
    1: 31, 2: 28, 3: 31, 4: 30, 5: 31, 6: 30, 7: 31, 8: 31, 9: 30, 10: 31, 11: 30, 12: 31 
} # days in each month

def is_leap(n):
    if n % 100 == 0:
        return n % 400 == 0
    return n % 4 == 0

days = sum([months[i] for i in range(1, 13)])

day = (days if not is_leap(year) else days + 1) % 7 # day on 1st jan 1901
year += 1

sundays = 0
curr_month = 1

while year < 2001:
    if day == 6:
        sundays += 1
    
    if curr_month == 2:
        if is_leap(year):
            days += months[curr_month] + 1
    
    days += months[curr_month]
    day = days % 7

    curr_month += 1
    if curr_month == 13:
        curr_month = 1
        year += 1

print(sundays)