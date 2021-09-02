import random
import unittest

from register import register

class TestRegister(unittest.TestCase):

	def setUp(self):
		random.seed(1)
		self.rnd_state = random.getstate()
		self.change_amts = [0, 1, 80, 99, 100, 101]
		self.eff_cmps = [
			{},
			{'penny':1},
			{'quarter':3,'nickel':1},
			{'quarter':3,'dime':2,'penny':4},
			{'dollar':1},
			{'dollar':1,'penny':1}
		]
		self.rnd_cmps = [
			{},
			{'penny': 1},
			{'quarter': 2, 'dime': 2, 'nickel': 1, 'penny': 5},
			{'quarter': 3, 'dime': 1, 'nickel': 2, 'penny': 4},
			{'quarter': 3, 'dime': 1, 'nickel': 2, 'penny': 5},
			{'quarter': 3, 'dime': 1, 'nickel': 2, 'penny': 6},
		]
		self.change_strs = [
			'',
			'1 penny',
			'3 quarters,1 nickel',
			'3 quarters,2 dimes,4 pennies',
			'1 dollar',
			'1 dollar,1 penny'
		]


	def test_stringify_change(self):
		for change, change_str in zip(self.eff_cmps, self.change_strs):
			self.assertEqual(change_str, register.stringify_change(change))


	def test_efficient_changemake(self):
		for amt, eff_cmp in zip(self.change_amts, self.eff_cmps):
			self.assertEqual(eff_cmp, register.efficient_changemake(amt))


	def test_random_changemake(self):
		for amt, rnd_cmp in zip(self.change_amts, self.rnd_cmps):
			random.setstate(self.rnd_state)
			self.assertEqual(rnd_cmp, register.random_changemake(amt))


	def test_changemake(self):
		self.assertIsNone(register.changemake(2, 1))
		self.assertEqual(register.changemake(.2, 1), self.eff_cmps[2])
		random.setstate(self.rnd_state)
		self.assertTrue(register.changemake(.3, 1.1), self.rnd_cmps[2])


if __name__ == '__main__':
	unittest.main()