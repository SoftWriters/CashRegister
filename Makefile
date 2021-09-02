.PHONY: test

INPUT = input.txt
OUTPUT = output.txt

init:
	python3 -m pip install -r requirements.txt

test: init
	python3 -m unittest discover -vs test

run: init
	python3 register/register.py ${INPUT} ${OUTPUT}