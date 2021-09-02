import argparse
from collections import defaultdict
import csv
import random

DEFAULT_DENOMINATIONS = {
	'penny': 1,
	'nickel': 5,
	'dime': 10,
	'quarter': 25,
	'dollar': 100,
}

DEFAULT_PLURALS = {
	'penny': 'pennies',
	'nickel': 'nickels',
	'dime': 'dimes',
	'quarter': 'quarters',
	'dollar': 'dollars'
}

def main(args):
	with open(args.input, 'r') as infile, open(args.output, 'w') as outfile:
		reader = csv.reader(infile)
		for row in reader:
			change = changemake(float(row[0]), float(row[1]))
			outfile.write((stringify_change(change) if change else '-') + '\n')


def changemake(due: float,
	paid: float
) -> dict[str, int]:
	amt = round(100*(paid-due))
	if amt <= 0:
		return None
	else:
		return efficient_changemake(amt) if amt % 3 else random_changemake(amt)


def efficient_changemake(n: int,
	denominations: dict[str, int]=DEFAULT_DENOMINATIONS
) -> dict[str, int]:
	eff_cnts = [0]
	eff_cmps = [[]]

	for i in range(1, n+1):
		ideal_cnt = 1E10
		ideal_cmp = None
		for k,v in denominations.items():
			if i >= v and eff_cnts[i-v] + 1 < ideal_cnt:
				ideal_cnt = eff_cnts[i-v] + 1
				ideal_cmp = eff_cmps[i-v] + [k]

		eff_cnts.append(ideal_cnt)
		eff_cmps.append(ideal_cmp)

	change = defaultdict(int)
	for k in eff_cmps[n]:
		change[k] = change[k]+1

	return change


def random_changemake(n: int,
	denominations: dict[str, int]=DEFAULT_DENOMINATIONS
) -> dict[str, int]:
	change = defaultdict(int)
	allowed_dnms = [(k,v) for k,v in denominations.items()]
	while n > 0:
		x = random.choice(allowed_dnms)
		if x[1] <= n:
			change[x[0]] = change[x[0]] + 1
			n = n - x[1]
		else:
			allowed_dnms.remove(x)

	return {k:v for k,v in sorted(change.items(), key=lambda x: denominations[x[0]], reverse=True)}


def stringify_change(change: dict[str, int],
	denominations: dict[str, int]=DEFAULT_DENOMINATIONS,
	plurals: dict[str, str]=DEFAULT_PLURALS
) -> str:
	return ','.join([f'{v} {k if v==1 else plurals[k]}' for k,v in change.items()])


if __name__ == '__main__':
	parser = argparse.ArgumentParser()
	parser.add_argument('input', type=str)
	parser.add_argument('output', type=str)
	args = parser.parse_args()
	main(args)