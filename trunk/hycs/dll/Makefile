#
#
#
#
#
include ../make.inc

#
BINDIR = ../bin

#
CS_FLAGS += /reference:helloDLL.dll
LIB_FLAGS = /nologo /target:library

#
LIB_SOURCES = \
    helloDLL.cs

LIBRARIES = $(LIB_SOURCES:.cs=.dll)

SOURCES = \
    testDLL.cs

EXECUTIVES = $(SOURCES:.cs=.exe)

default : $(LIBRARIES) $(EXECUTIVES)

%.dll: %.cs
	$(CSC) $(LIB_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

%.exe: %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(EXECUTIVES) $(LIBRARIES)

