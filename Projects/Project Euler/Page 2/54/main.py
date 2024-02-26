games = []

def evaluate(card):
    card_values = {
        "A": 14,
        "K": 13,
        "Q": 12,
        "J": 11,
        "T": 10,
        "9": 9,
        "8": 8,
        "7": 7,
        "6": 6,
        "5": 5,
        "4": 4,
        "3": 3,
        "2": 2
    }

    return card_values[card[0]], card[1]

with open("C:/Users/conno/Onedrive/Documents/Github/A-Level/Projects/Project Euler/54/poker.txt", "r") as f:
    x = f.readlines()
    for line in x:
        y = line[:-1].split(" ")
        a = [evaluate(z) for z in y[:5]]
        a.sort()
        b = [evaluate(z) for z in y[5:]]
        b.sort()
        w = [a, b]
        games.append(w)

def get_hand(hand: list[tuple[int, str]]):
    # Check for Royal Flush ensuring same suit
    suits = set(card[1] for card in hand)
    if len(suits) == 1:  # Same suit
        values = set(card[0] for card in hand)
        if values == {10, 11, 12, 13, 14}:  # Royal values
            return 9, sum(card[0] for card in hand)  # Total all card values
    # Check for Straight Flush ensuring same suit
    if len(suits) == 1:  # Same suit
        values = [card[0] for card in hand]
        values.sort()
        if all(values[i] == values[i-1] + 1 for i in range(1, len(values))):  # Consecutive values
            return 8, sum(card[0] for card in hand)  # Total all card values
    # Check for Four of a Kind
    values = [card[0] for card in hand]
    value_counts = {value: values.count(value) for value in values}
    if 4 in value_counts.values():
        for k, v in value_counts.items():
            if v == 4:
                return 7, 4*k  # Only total the values of the four cards
    # Check for Full House
    if 3 in value_counts.values() and 2 in value_counts.values():
        return 6, sum(card[0] for card in hand)  # Total all card values
    # Check for Flush ensuring same suit
    if len(suits) == 1:  # Same suit
        return 5, sum(card[0] for card in hand)  # Total all card values
    # Check for Straight
    values.sort()
    if all(values[i] == values[i-1] + 1 for i in range(1, len(values))):  # Consecutive values
        return 4, sum(card[0] for card in hand)  # Total all card values
    # Check for Three of a Kind
    if 3 in value_counts.values():
        return 3, 3*max(value_counts, key=lambda k: value_counts[k])  # Only total the value of the three cards
    # Check for Two Pairs
    if list(value_counts.values()).count(2) == 2:
        pairs = [k for k, v in value_counts.items() if v == 2]
        return 2, 2*max(pairs, key=lambda k: value_counts[k]) + 2*min(pairs, key=lambda k: value_counts[k])  # Only total the values of the two pairs
    # Check for One Pair
    if 2 in value_counts.values():
        pair = max(value_counts, key=lambda k: value_counts[k])
        return 1, 2*pair  # Only total the value of the pair
    # Check for High Card
    return 0, max(card[0] for card in hand)  # Only total the value of the highest card

def find_winner(a, b):
    for i in range(4, -1, -1):
        if a[i][0] > b[i][0]:
            return 1
        elif a[i][0] < b[i][0]:
            return 2

t = 0

for g in games:
    a, b = get_hand(g[0]), get_hand(g[1])

    if a[0] > b[0]:
        t += 1
    elif a[0] == b[0]:
        if a[1] > b[1]:
            t += 1
        if a[1] == b[1]:
            if find_winner(g[0], g[1]) == 1:
                t += 1

print(t)