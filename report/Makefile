show: test.pdf
	open test.pdf
test.pdf: test
	dvipdfmx test
test: test.tex
	uplatex test.tex
clean:
	rm -f test.aux test.log test.dvi
