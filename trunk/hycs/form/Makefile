#
#
#
#
#
SHELL = cmd.exe

#
CSC = csc.exe

#
BINDIR = ../bin

#
CS_FLAGS = /nologo /target:winexe

#
SOURCES = \
    helloForm.cs \
    screensave.cs \
    checkbox.cs

TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(TARGETS)

