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
    property.cs \
    datatype.cs \
    indexer.cs  \
    array.cs    \
    struct.cs   \
    generic.cs  \
    types.cs    \
    boxing.cs   \
    operator.cs \
    

TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(TARGETS)

