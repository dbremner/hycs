#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /target:winexe

#
SOURCES = \
    helloImage.cs \
    ruler.cs      \
    scribble.cs   \

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS)

