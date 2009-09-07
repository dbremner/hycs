#
#
#
#
#
include ../make.inc

#
BINDIR = ../bin

#
CS_FLAGS += /target:winexe

#
SOURCES = \
    helloDXForm.cs

TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(TARGETS)

