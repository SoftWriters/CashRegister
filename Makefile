.PHONY: test

INPUT = input.txt
OUTPUT = output.txt

init:
	python3 -m pip install -r requirements.txt

test:
	python3 -m unittest discover -vs test

run:
	python3 register/register.py ${INPUT} ${OUTPUT}