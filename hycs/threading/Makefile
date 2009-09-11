#
#
#
#
#
include ../make.inc

#
BINDIR = ../bin

#
CS_FLAGS +=

#
SOURCES = \
    helloThread.cs

TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(TARGETS) *.txt

